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
    public class ActiveZalbeState : BaseZalbeState
    {
        ILogger<ActiveZalbeState> _logger;
        public ActiveZalbeState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<ActiveZalbeState> logger) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
        }

        public override Zalbe Processing(int id, int administratorId)
        {
            var set = Context.Set<Database.Zalbe>();

            var entity = set.Find(id);

            if (entity == null)
            {
                throw new UserException("Zalba sa tim ID-om ne postoji.");
            }

            entity.StateMachine = "processing";

            entity.DatumIzmjene = DateTime.Now;

            entity.DatumPreuzimanja = DateTime.Now;

            entity.AdministratorId = administratorId;

            Context.SaveChanges();

            _logger.LogInformation($"[!] Zalba ID: {entity.Id} je preuzeta od strane Administratora ID: {entity.AdministratorId}");

            //TODO: Dodati notifikaciju/mejl korisniku da mu je zalba u procesu rjesavanja

            return Mapper.Map<Zalbe>(entity);
        }

        public override List<string> AllowedActions(Database.Zalbe entity)
        {
            return new List<string>() { nameof(Processing) };
        }
    }
}
