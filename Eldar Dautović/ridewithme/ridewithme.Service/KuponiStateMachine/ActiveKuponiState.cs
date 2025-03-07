using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.KuponiStateMachine
{
    public class ActiveKuponiState : BaseKuponiState
    {
        public ActiveKuponiState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }

        public override Model.Models.Kuponi Hide(int id)
        {
            var set = Context.Set<Database.Kuponi>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            entity.DatumIzmjene = DateTime.Now;

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Kuponi>(entity);
        }

        public override List<string> AllowedActions(Database.Kuponi entity)
        {
            return new List<string>() { nameof(Hide)};
        }
    }
}
