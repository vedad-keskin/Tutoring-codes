using MapsterMapper;
using ridewithme.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Mapster;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.KuponiStateMachine
{
    public class InitialKuponiState : BaseKuponiState
    {
        ILogger<InitialKuponiState> _logger;
        public InitialKuponiState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<InitialKuponiState> logger) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
        }


        public override Kuponi Insert(KuponiInsertRequest request)
        {

            if (Context.Korisnicis.FirstOrDefault(x => x.Id == request.KorisnikId) == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            if(request.Kod.ToUpper() != request.Kod) {
                throw new UserException("Kod mora da bude napisan velikim slovima, a razmaci sa '-' (npr. TEST-KOD).");
            }

            if(request.Kod.Contains(" "))
            {
                throw new UserException("Kod ne smije sadrzavati razmake.");
            }

            if(request.Popust > 1.0 || request.Popust <= 0)
            {
                throw new UserException("Popust ne moze biti veci od 100% niti manji od 1%.");
            }

            if(request.BrojIskoristivosti <= 0)
            {
                throw new UserException("Broj iskoristivosti koda ne moze biti manji od 1.");
            }

            var kuponiSet = Context.Set<Database.Kuponi>();

            Mapper.Config.Default.IgnoreNullValues(true);

            var entity = Mapper.Map<Database.Kuponi>(request);

            Mapper.Config.Default.IgnoreNullValues(false);

            entity.StateMachine = "draft";

            entity.DatumIzmjene = DateTime.Now;

            kuponiSet.Add(entity);

            Context.SaveChanges();

            _logger.LogInformation($"[+] Kreiran je novi Kupon ID: {entity.Id} | Korisnik ID: {request.KorisnikId}");

            return Mapper.Map<Kuponi>(entity);
        }

        public override List<string> AllowedActions(Database.Kuponi entity)
        {
            return new List<string>() { nameof(Insert) };
        }
    }
}
