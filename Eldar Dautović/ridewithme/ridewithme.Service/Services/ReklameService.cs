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
    public class ReklameService : BaseCRUDService<Model.Models.Reklame, ReklameSearchObject, Database.Reklame, ReklameInsertRequest, ReklameUpdateRequest>, IReklameService
    {
        public ReklameService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<Database.Reklame> AddFilter(ReklameSearchObject searchObject, IQueryable<Database.Reklame> query)
        {
            if (!string.IsNullOrWhiteSpace(searchObject.NazivKlijentaGTE))
            {
                query = query.Where(x => x.NazivKlijenta.Contains(searchObject.NazivKlijentaGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject.NazivKampanjeGTE))
            {
                query = query.Where(x => x.NazivKampanje.Contains(searchObject.NazivKampanjeGTE));
            }

            return query;
        }

        public Model.Models.Reklame Delete(int id)
        {
            var set = Context.Set<Database.Reklame>();

            var entity = set.Find(id);

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Reklame>(entity);
        }


    }
}
