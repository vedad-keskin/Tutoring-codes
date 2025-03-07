using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.VoznjeStateMachine
{
    public class CompletedVoznjeState : BaseVoznjeState
    {
        public CompletedVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }
        public override Model.Models.Voznje Rate(int id, int ocjena)
        {
            return base.Rate(id, ocjena);
        }

        public override Model.Models.Voznje Delete(int id)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override List<string> AllowedActions(Database.Voznje entity)
        {
            return new List<string>() { nameof(Rate), nameof(Delete) };
        }
    }
}
