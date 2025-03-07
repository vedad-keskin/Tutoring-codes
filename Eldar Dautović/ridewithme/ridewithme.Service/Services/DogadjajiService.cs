using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using ridewithme.Service.Interfaces;
using ridewithme.Model.Models;

namespace ridewithme.Service.Services
{
    public class DogadjajiService : BaseCRUDService<Model.Models.Dogadjaji, DogadjajiSearchObejct, Database.Dogadjaji, DogadjajiUpsertRequest, DogadjajiUpsertRequest>, IDogadjaji
    {
        public DogadjajiService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<Database.Dogadjaji> AddFilter(DogadjajiSearchObejct searchObject, IQueryable<Database.Dogadjaji> query)
        {

            if (!string.IsNullOrWhiteSpace(searchObject.NazivGTE))
            {
                query = query.Where(x => x.Naziv.Contains(searchObject.NazivGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject.OpisGTE))
            {
                query = query.Where(x => x.Opis.Contains(searchObject.OpisGTE));
            }

            if (searchObject.DatumPocetka.HasValue)
            {
                query = query.Where(x => x.DatumPocetka == searchObject.DatumPocetka.Value);
            }

            if (searchObject.DatumZavrsetka.HasValue)
            {
                query = query.Where(x => x.DatumZavrsetka == searchObject.DatumZavrsetka.Value);
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

        public Model.Models.Dogadjaji Delete(int id)
        {
            var set = Context.Set<Database.Dogadjaji>();

            var entity = set.Find(id);

            var voznjeDogadjaji = Context.Voznje.Where(x => x.DogadjajId == id).ToList();

            foreach (var v in voznjeDogadjaji)
            {
                v.DogadjajId = null;
            }

            Context.SaveChanges();

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Dogadjaji>(entity);
        }

    }
}
