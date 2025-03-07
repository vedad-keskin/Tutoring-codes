using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System.Linq.Dynamic.Core;

namespace ridewithme.Service.Services
{
    public class FAQService : BaseCRUDService<Model.Models.FAQ, FAQSearchObject, Database.FAQ, FAQInsertRequest, FAQUpdateRequest>, IFAQService
    {
        public FAQService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<Database.FAQ> AddFilter(FAQSearchObject searchObject, IQueryable<Database.FAQ> query)
        {
            if (!string.IsNullOrWhiteSpace(searchObject.PitanjeGTE))
            {
                query = query.Where(x => x.Pitanje.Contains(searchObject.PitanjeGTE));
            }

            if (searchObject?.IsKorisnikIncluded == true)
            {
                query = query.Include(x => x.Korisnik);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.OrderBy))
            {
                var items = searchObject.OrderBy.Split(' ');
                if (items.Length > 2 || items.Length == 0)
                {
                    throw new ApplicationException("Mozete sortirati samo po dva polja.");
                }
                if (items.Length == 1)
                {
                    query = query.OrderBy("@0", searchObject.OrderBy);
                }
                else
                {
                    query = query.OrderBy(string.Format("{0} {1}", items[0], items[1]));
                }

            }

            return query;
        }

        public Model.Models.FAQ Delete(int id)
        {
            var set = Context.Set<Database.FAQ>();

            var entity = set.Find(id);

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.FAQ>(entity);
        }

    }
}
