using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Exceptions;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System.Linq.Dynamic.Core;


namespace ridewithme.Service.Services
{
    public class RecenzijaService : BaseCRUDService<Model.Models.Recenzija, RecenzijaSearchObject, Database.Recenzija, RecenzijaUpsertRequest, RecenzijaUpsertRequest>, IRecenzijaService
    {
        public RecenzijaService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<Database.Recenzija> AddFilter(RecenzijaSearchObject searchObject, IQueryable<Database.Recenzija> query)
        {
            if (!string.IsNullOrEmpty(searchObject.KorisnikGTE))
            {
                query = query.Where(x => x.Korisnik.KorisnickoIme.Contains(searchObject.KorisnikGTE) || x.Voznja.Vozac.KorisnickoIme.Contains(searchObject.KorisnikGTE));
            }

            if (searchObject.KorisnikId != null)
            {
                query = query.Where(x => x.KorisnikId == searchObject.KorisnikId);
            }

            if (searchObject.VoznjaId != null)
            {
                query = query.Where(x => x.VoznjaId == searchObject.VoznjaId);
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

            query = query.Include(x=> x.Korisnik).Include(x => x.Voznja).ThenInclude(x => x.GradOd).Include(x => x.Voznja).ThenInclude(x => x.GradDo).Include(x => x.Voznja).ThenInclude(x => x.Vozac);

            return query;
        }

        public override void BeforeInsert(RecenzijaUpsertRequest request, Database.Recenzija entity)
        {
            var recenzijeVoznje = Context.Recenzije.FirstOrDefault(x => x.VoznjaId == request.VoznjaId);

            if (recenzijeVoznje != null)
            {
                throw new UserException("Na ovu vožnju je već ostavljena recenzija.");
            }

            var klijentVoznja = Context.Voznje.FirstOrDefault(x => x.Id == request.VoznjaId && x.KlijentId == request.KorisnikId);

            if (klijentVoznja == null)
            {
                throw new UserException("Niste učestvovali u ovoj vožnji.");
            }

            if (request.Ocjena > 5 || request.Ocjena < 1)
            {
                throw new UserException("Ocjena može biti 5 maksimalno, a namjanje 1.");
            }

            base.BeforeInsert(request, entity);
        }

        public override void AfterInsert(Database.Recenzija entity, RecenzijaUpsertRequest request)
        {
            if(request.Ocjena == 5)
            {
                var numberOfFiveStars = Context.KorisniciDostignuca.FirstOrDefault(x => x.KorisnikId == entity.Voznja.VozacId && x.DostignuceId == 7);

                if (numberOfFiveStars == null)
                {
                    var dostignuce = new Database.KorisniciDostignuca()
                    {
                        DostignuceId = 7,
                        DatumKreiranja = DateTime.Now,
                        KorisnikId = entity.Voznja.VozacId,
                    };

                    Context.Add(dostignuce);

                    Context.SaveChanges();
                }
            }

            base.AfterInsert(entity, request);
        }

        public Model.Models.Recenzija Delete(int id)
        {
            var set = Context.Set<Database.Recenzija>();

            var entity = set.Find(id);

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Recenzija>(entity);
        }
    }
}
