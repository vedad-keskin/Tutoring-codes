using eCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Responses;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using System.Linq;
using System;
using MapsterMapper;

namespace eCommerce.Services
{
    public abstract class BaseCRUDService<T, TSearch, TEntity, TInsert, TUpdate> 
    : BaseService<T, TSearch, TEntity>, ICRUDService<T, TSearch, TInsert, TUpdate> 
    where T : class where TSearch : BaseSearchObject where TEntity : class, new() where TInsert : class where TUpdate : class
    {
        protected readonly eCommerceDbContext _context;

        public BaseCRUDService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }


        public virtual async Task<T> CreateAsync(TInsert request)
        {
            var entity = new TEntity();
            MapInsertToEntity(entity, request);
            _context.Set<TEntity>().Add(entity);

            await BeforeInsert(entity, request);

            await _context.SaveChangesAsync();
            return MapToResponse(entity);
        }

        protected virtual async Task BeforeInsert(TEntity entity, TInsert request)
        {
            
        }


        protected virtual TEntity MapInsertToEntity(TEntity entity, TInsert request)
        {
            return _mapper.Map(request, entity);
        }

        public virtual async Task<T?> UpdateAsync(int id, TUpdate request)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return null;

            await BeforeUpdate(entity, request);

            MapUpdateToEntity(entity, request);

            await _context.SaveChangesAsync();
            return MapToResponse(entity);
        }

        protected virtual async Task BeforeUpdate(TEntity entity, TUpdate request)
        {

        }

        protected virtual void MapUpdateToEntity(TEntity entity, TUpdate request)
        {
            _mapper.Map(request, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return false;

            await BeforeDelete(entity);

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        protected virtual async Task BeforeDelete(TEntity entity)
        {

        }

        // private ProductTypeResponse MapToResponse(ProductType productType)
        // {
        //     return new ProductTypeResponse
        //     {
        //         Id = productType.Id,
        //         Name = productType.Name,
        //         Description = productType.Description,
        //         IsActive = productType.IsActive,
        //         CreatedAt = productType.CreatedAt,
        //         UpdatedAt = productType.UpdatedAt
        //     };
        // }
    }
} 