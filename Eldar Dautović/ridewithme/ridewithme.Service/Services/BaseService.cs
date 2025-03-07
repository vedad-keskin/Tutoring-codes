using MapsterMapper;
using ridewithme.Model.Helpers;
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
    public abstract class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public RidewithmeContext Context { get; set; }

        public IMapper Mapper { get; set; }
        public BaseService(RidewithmeContext dbContext, IMapper mapper)
        {
            Context = dbContext;
            Mapper = mapper;
        }

        public PagedResult<TModel> GetPaged(TSearch searchObject)
        {

            List<TModel> result = new List<TModel>();

            var query = Context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(searchObject, query);

            int count = query.Count();

            if (searchObject?.Page.HasValue == true && searchObject?.PageSize.HasValue == true)
            {
                int skip = searchObject.Page.Value - 1;
                query = query.Skip(skip * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
            }

            var list = query.ToList();

            result = Mapper.Map(list, result);

            PagedResult<TModel> paged = new PagedResult<TModel>();

            paged.Results = result;
            paged.Count = count;

            return paged;
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch searchObject, IQueryable<TDbEntity> query)
        {
            return query;
        }

        public virtual TModel GetById(int id)
        {
            var entity = Context.Set<TDbEntity>().Find(id);

            if (entity != null)
            {
                return Mapper.Map<TModel>(entity);
            }
            else
            {
                return null;
            }
        }
    }
}
