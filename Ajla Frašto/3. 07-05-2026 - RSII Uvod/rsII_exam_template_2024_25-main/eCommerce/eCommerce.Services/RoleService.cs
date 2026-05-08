using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class RoleService : BaseCRUDService<RoleResponse, RoleSearchObject, Database.Role, RoleUpsertRequest, RoleUpsertRequest>, IRoleService
    {
        public RoleService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Database.Role> ApplyFilter(IQueryable<Database.Role> query, RoleSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(r => r.Name.Contains(search.Name));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(r => r.Name.Contains(search.FTS) || r.Description.Contains(search.FTS));
            }

            if (search.IsActive.HasValue)
            {
                query = query.Where(r => r.IsActive == search.IsActive.Value);
            }

            return query;
        }

        protected override async Task BeforeInsert(Database.Role entity, RoleUpsertRequest request)
        {
            // Check for duplicate role name
            if (await _context.Roles.AnyAsync(r => r.Name == request.Name))
            {
                throw new InvalidOperationException("A role with this name already exists.");
            }
        }

        protected override async Task BeforeUpdate(Database.Role entity, RoleUpsertRequest request)
        {
            // Check for duplicate role name (excluding current role)
            if (await _context.Roles.AnyAsync(r => r.Name == request.Name && r.Id != entity.Id))
            {
                throw new InvalidOperationException("A role with this name already exists.");
            }
        }
    }
} 