using MapsterMapper;
using Microsoft.Extensions.Logging;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.ZalbeStateMachine
{
    public class CompletedZalbeState : BaseZalbeState
    {
        ILogger<CompletedZalbeState> _logger;
        public CompletedZalbeState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<CompletedZalbeState> logger) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
        }

        public override Zalbe Delete(int id)
        {
            var set = Context.Set<Database.Zalbe>();

            var entity = set.Find(id);

            if (entity == null)
            {
                throw new UserException("Zalba sa tim ID-om ne postoji.");
            }

            set.Remove(entity);

            Context.SaveChanges();

            _logger.LogInformation($"[-] Zalba ID: {id} je obrisana od strane administratora.");

            return Mapper.Map<Zalbe>(entity);
        }

        public override List<string> AllowedActions(Database.Zalbe entity)
        {
            return new List<string>() { nameof(Delete) };
        }
    }
}
