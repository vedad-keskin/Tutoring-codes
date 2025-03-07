using MapsterMapper;
using ridewithme.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Mapster;
using Azure.Core;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.ZalbeStateMachine
{
    public class ProcessingZalbeState : BaseZalbeState
    {
        ILogger<ActiveZalbeState> _logger;
        public ProcessingZalbeState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<ActiveZalbeState> logger) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
        }

        public override Zalbe Activate(int id)
        {
            var set = Context.Set<Database.Zalbe>();

            var entity = set.Find(id);

            if (entity == null)
            {
                throw new UserException("Zalba sa tim ID-om ne postoji.");
            }
            
            entity.StateMachine = "active";

            entity.DatumIzmjene = DateTime.Now;

            entity.DatumPreuzimanja = null;

            entity.AdministratorId = null;

            Context.SaveChanges();

            _logger.LogInformation($"[!] Zalba ID: {entity.Id} je vracena u aktivni status od strane Administratora.");

            //TODO: Dodati notifikaciju/mejl za vracanje u aktivni status.

            return Mapper.Map<Zalbe>(entity);
        }

        public override Zalbe Complete(int id, ZalbeCompleteRequest request)
        {
            var set = Context.Set<Database.Zalbe>();

            var entity = set.Find(id);

            if (entity == null)
            {
                throw new UserException("Zalba sa tim ID-om ne postoji.");
            }

            if (string.IsNullOrWhiteSpace(request.OdgovorNaZalbu))
            {
                throw new UserException("Odgovor korisniku ne može biti prazan.");
            }

            entity.StateMachine = "completed";

            entity.OdgovorNaZalbu = request.OdgovorNaZalbu;

            entity.DatumIzmjene = DateTime.Now;

            Context.SaveChanges();

            _logger.LogInformation($"[!] Zalba ID: {entity.Id} je zavrsena od strane Administratora. | Vracam odgovor");

            //TODO: Dodati notifikaciju/mejl za zavrsenu zalbu.

            return Mapper.Map<Zalbe>(entity);
        }




        public override List<string> AllowedActions(Database.Zalbe entity)
        {
            return new List<string>() { nameof(Activate), nameof(Complete) };
        }
    }
}
