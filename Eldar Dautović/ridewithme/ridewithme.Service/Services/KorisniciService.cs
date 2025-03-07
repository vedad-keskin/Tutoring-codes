using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using ridewithme.Service.Interfaces;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.Services
{
    public class KorisniciService : BaseCRUDService<Model.Models.Korisnici, KorisniciSearchObject, Database.Korisnici, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        ILogger<KorisniciService> _logger;
        public KorisniciService(RidewithmeContext dbContext, IMapper mapper, ILogger<KorisniciService> logger) : base(dbContext, mapper)
        {
            _logger = logger;
        }

        public override IQueryable<Database.Korisnici> AddFilter(KorisniciSearchObject searchObject, IQueryable<Database.Korisnici> query)
        {

            query = base.AddFilter(searchObject, query);

            if (searchObject.IsKorisniciIncluded == true)
            {
                query = query.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga);
            }
            if (searchObject.IsDostignucaIncluded == true)
            {
                query = query.Include(x => x.KorisniciDostignuca).ThenInclude(x => x.Dostignuce);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x => x.Ime.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Email))
            {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.Contains(searchObject.KorisnickoIme));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.OrderBy))
            {
                var items = searchObject.OrderBy.Split(' ');
                if (items.Length > 2 || items.Length == 0)
                {
                    throw new ApplicationException("Mozete sortirati samo po dva polja.");
                }
                if (items.Length == 1)
                {
                    query = query.OrderBy("@0", searchObject.OrderBy);
                }
                else
                {
                    query = query.OrderBy(string.Format("{0} {1}", items[0], items[1]));
                }

            }


            query = query.Include(x => x.KorisniciDostignuca).ThenInclude(x => x.Dostignuce);
            query = query.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga);

            return query;
        }

        public override void BeforeInsert(KorisniciInsertRequest request, Database.Korisnici entity)
        {
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda se moraju podudarati.");
            }

            var existingUsername = Context.Korisnicis.FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme);

            if (existingUsername != null)
            {
                throw new UserException("Korisnicko ime je zauzeto.");
            }

            if (!IsValidEmail(request.Email))
            {
                throw new UserException("E-mail adresa nije u validnom formatu.");
            }

            var existingEmail = Context.Korisnicis.FirstOrDefault(x => x.Email == request.Email);

            if (existingEmail != null)
            {
                throw new UserException("E-mail adresa je već iskorištena od nekog korisnika.");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            base.BeforeInsert(request, entity);
        }


        public override void BeforeUpdate(KorisniciUpdateRequest request, Database.Korisnici entity)
        {
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda se moraju podudarati.");
            }

            if (!IsValidEmail(request.Email))
            {
                throw new UserException("E-mail adresa nije u validnom formatu.");
            }

            var existingEmail = Context.Korisnicis.FirstOrDefault(x => x.Email == request.Email);

            if (existingEmail != null && request.Email != entity.Email)
            {
                throw new UserException("E-mail adresa je već iskorištena od nekog korisnika.");
            }

            if (request.Lozinka != null)
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }


            base.BeforeUpdate(request, entity);
        }

        public override Model.Models.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            if(request.UlogaId != null)
            {
                var korisniciUloge = Context.KorisniciUloge.FirstOrDefault(x => x.KorisnikId == id);

                if (korisniciUloge != null)
                {

                    var uloga = Context.Uloge.FirstOrDefault(x => x.Id == request.UlogaId);

                    if(uloga != null)
                    {
                        korisniciUloge.UlogaId = (int)request.UlogaId;

                    }

                }

            }

            return base.Update(id, request);
        }
        public override void AfterInsert(Database.Korisnici entity, KorisniciInsertRequest request)
        {
            var korisnikRole = Context.Uloge.FirstOrDefault(x => x.Naziv == "Korisnik");

            var roleEntity = new Database.KorisniciUloge()
            {
                DatumIzmjene = DateTime.Now,
                Korisnik = entity,
                KorisnikId = entity.Id,
                Uloga = korisnikRole,
                UlogaId = korisnikRole.Id
            };

            Context.Add(roleEntity);
            Context.SaveChanges();

            _logger.LogInformation($"[+] Kreiran je novi korisnik sa korisnickim imenom: {entity.KorisnickoIme}");

            base.AfterInsert(entity, request);
        }

        public static string GenerateSalt()
        {
            var byteArray = RandomNumberGenerator.GetBytes(16);

            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public Model.Models.Korisnici Login(string username, string password)
        {
            var entity = Context.Korisnicis.Include(x => x.KorisniciUloge).ThenInclude(y => y.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<Model.Models.Korisnici>(entity);
        }

        public Model.Models.Korisnici GetLoggedInUser(string username)
        {

            var entity = Context.Korisnicis.Include(x => x.KorisniciUloge).ThenInclude(y => y.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            return Mapper.Map<Model.Models.Korisnici>(entity);
        }

        public PovjerljivVozac Trusted(int vozacId, int klijentId)
        {

            var brojObavljenihVoznjiVozaca = Context.Voznje.Where(x => x.VozacId == vozacId && x.StateMachine == "completed").Count();
            var brojObavljenihVoznjiKlijenta = Context.Voznje.Where(x => x.KlijentId == klijentId && x.StateMachine == "completed").Count();

            return new PovjerljivVozac() { BrojZavrsenihVoznjiVozaca = brojObavljenihVoznjiVozaca, BrojZavrsenihVoznjiKlijenta = brojObavljenihVoznjiKlijenta };
        }

        public List<Model.Models.Korisnici> Popular()
        {

            var topDrivers = Context.Voznje
                 .Include(x => x.Vozac)
                 .GroupBy(r => r.Vozac)
                 .OrderByDescending(u => u.Count())
                 .Select(g => g.First().Vozac) // Vraća listu entiteta vozača
                 .Take(3)
                 .ToList();

            return Mapper.Map<List<Model.Models.Korisnici>>(topDrivers);
        }


        public override Model.Models.Korisnici GetById(int id)
        {
            var entity = Context.Set<Database.Korisnici>().Include(x => x.KorisniciDostignuca).ThenInclude(x => x.Dostignuce).FirstOrDefault( x=> x.Id == id);

            if (entity != null)
            {
                return Mapper.Map<Model.Models.Korisnici>(entity);
            }
            else
            {
                return null;
            }
        }

        public Model.Models.Korisnici Delete(int id)
        {
           //Kaskadno brisanje korisnika

            var korisnik = Context.Korisnicis.FirstOrDefault(x => x.Id == id);


            if(korisnik == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            var korisniciFaq = Context.FAQs.Where(x => x.KorisnikId == id).ToList();

            if (korisniciFaq.Count() > 0)
            {
                foreach (var item in korisniciFaq)
                {
                    Context.Remove(item);
                }
            }

            var korisniciKuponi = Context.Kuponi.Where(x => x.KorisnikId == id).ToList();

            if (korisniciKuponi.Count() > 0)
            {
                foreach (var item in korisniciKuponi)
                {
                    Context.Remove(item);
                }
            }

            var korisniciDostignuca = Context.KorisniciDostignuca.Where(x => x.KorisnikId == id).ToList();

            if (korisniciDostignuca.Count() > 0)
            {
                foreach (var item in korisniciDostignuca)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciUloge = Context.KorisniciUloge.Where(x => x.KorisnikId == id).ToList();

            if (korisniciUloge.Count() > 0)
            {
                foreach (var item in korisniciUloge)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciObavjestenja = Context.Obavjestenja.Where(x => x.KorisnikId == id).ToList();

            if (korisniciObavjestenja.Count() > 0)
            {
                foreach (var item in korisniciObavjestenja)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciRecenzije = Context.Recenzije.Where(x => x.KorisnikId == id).ToList();

            if (korisniciRecenzije.Count() > 0)
            {
                foreach (var item in korisniciRecenzije)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciReklame = Context.Reklame.Where(x => x.KorisnikId == id).ToList();

            if (korisniciReklame.Count() > 0)
            {
                foreach (var item in korisniciReklame)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciVoznje = Context.Voznje.Where(x => x.VozacId == id).ToList();

            if (korisniciVoznje.Count() > 0)
            {
                foreach (var item in korisniciVoznje)
                {
                    Context.Remove(item);
                }
            }
            
            var korisniciVoznjeKlijent = Context.Voznje.Where(x => x.KlijentId == id).ToList();

            if (korisniciVoznjeKlijent.Count() > 0)
            {
                foreach (var item in korisniciVoznjeKlijent)
                {
                    item.KlijentId = null;

                    item.StateMachine = "draft";
                }
            }
            
            var korisniciZalbe = Context.Zalbe.Where(x => x.Id == id).ToList();

            if (korisniciZalbe.Count() > 0)
            {
                foreach (var item in korisniciZalbe)
                {
                    Context.Remove(item);
                }
            }

            Context.SaveChanges();

            Context.Remove(korisnik);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Korisnici>(korisnik);
        }
    }
}
