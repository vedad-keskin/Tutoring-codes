using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.VoznjeStateMachine
{
    public class HiddenVoznjeState : BaseVoznjeState
    {
        public HiddenVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }

        public override Model.Models.Voznje Edit(int id)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            entity.StateMachine = "draft";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override List<string> AllowedActions(Database.Voznje entity)
        {
            return new List<string>() { nameof(Edit) };
        }
    }
}
