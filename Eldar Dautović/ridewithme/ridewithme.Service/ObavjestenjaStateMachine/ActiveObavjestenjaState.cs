using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.ObavjestenjaStateMachine
{
    public class ActiveObavjestenjaState : BaseObavjestenjaState
    {
        public ActiveObavjestenjaState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }

        public override Model.Models.Obavjestenja Complete(int id)
        {
            var set = Context.Set<Database.Obavjestenja>();

            var entity = set.Find(id);

            entity.StateMachine = "completed";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Obavjestenja>(entity);
        }

        public override Model.Models.Obavjestenja Hide(int id)
        {
            var set = Context.Set<Database.Obavjestenja>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Obavjestenja>(entity);
        }

        public override List<string> AllowedActions(Database.Obavjestenja entity)
        {
            return new List<string>() { nameof(Hide), nameof(Complete) };
        }
    }
}
