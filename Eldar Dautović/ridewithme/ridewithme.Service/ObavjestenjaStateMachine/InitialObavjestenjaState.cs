using MapsterMapper;
using ridewithme.Model.Requests;
using Microsoft.Extensions.Logging;
using Mapster;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.ObavjestenjaStateMachine
{
    public class InitialObavjestenjaState : BaseObavjestenjaState
    {
        ILogger<InitialObavjestenjaState> _logger;
        public InitialObavjestenjaState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<InitialObavjestenjaState> logger) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
        }


        public override Obavjestenja Insert(ObavjestenjaInsertRequest request)
        {

            if (Context.Korisnicis.FirstOrDefault(x => x.Id == request.KorisnikId) == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            var obavjestenjeSet = Context.Set<Database.Obavjestenja>();

            Mapper.Config.Default.IgnoreNullValues(true);

            var entity = Mapper.Map<Database.Obavjestenja>(request);

            Mapper.Config.Default.IgnoreNullValues(false);

            entity.StateMachine = "draft";

            entity.DatumIzmjene = DateTime.Now;

            entity.DatumKreiranja = DateTime.Now;

            obavjestenjeSet.Add(entity);

            Context.SaveChanges();

            _logger.LogInformation($"[+] Kreirano je novo Obavjestenje ID: {entity.Id} | Korisnik ID: {request.KorisnikId}");

            return Mapper.Map<Obavjestenja>(entity);
        }

        public override List<string> AllowedActions(Database.Obavjestenja entity)
        {
            return new List<string>() { nameof(Insert) };
        }
    }
}
