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
    public class HiddenObavjestenjaState : BaseObavjestenjaState
    {
        public HiddenObavjestenjaState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }

        public override Model.Models.Obavjestenja Edit(int id)
        {
            var set = Context.Set<Database.Obavjestenja>();

            var entity = set.Find(id);

            entity.StateMachine = "draft";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Obavjestenja>(entity);
        }

        public override List<string> AllowedActions(Database.Obavjestenja entity)
        {
            return new List<string>() { nameof(Edit) };
        }
    }
}

