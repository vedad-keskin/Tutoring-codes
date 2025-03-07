using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Services
{
    public class VrstaZalbeService : BaseCRUDService<Model.Models.VrstaZalbe, VrstaZalbeSearchObject, Database.VrstaZalbe, VrstaZalbeInsertRequest, VrstaZalbeUpdateRequest>, IVrstaZalbeService
    {
        public VrstaZalbeService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


        public override IQueryable<Database.VrstaZalbe> AddFilter(VrstaZalbeSearchObject searchObject, IQueryable<Database.VrstaZalbe> query)
        {
            if (!string.IsNullOrEmpty(searchObject.NazivGTE))
            {
                query = query.Where(x => x.Naziv.Contains(searchObject.NazivGTE));
            }

            return query;
        }

        public Model.Models.VrstaZalbe Delete(int id)
        {
            var set = Context.Set<Database.VrstaZalbe>();

            var entity = set.Find(id);

            var zalbeVrste = Context.Zalbe.Where(x => x.VrstaZalbeId == id).ToList();

            foreach (var v in zalbeVrste)
            {
                Context.Remove(v);
            }

            Context.SaveChanges();

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.VrstaZalbe>(entity);
        }


    }
}
