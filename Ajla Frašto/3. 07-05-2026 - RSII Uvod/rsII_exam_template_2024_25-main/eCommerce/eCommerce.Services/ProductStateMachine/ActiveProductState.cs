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
using eCommerce.Model;

namespace eCommerce.Services.ProductStateMachine
{
    public class ActiveProductState : BaseProductState
    {
        public ActiveProductState(IServiceProvider serviceProvider, eCommerceDbContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<ProductResponse> DeactivateAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            entity.ProductState = nameof(DeactivatedProductState);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(entity);
        }

        public override List<string> AllowedActions(int id)
        {
            return new List<string>() { nameof(DeactivateAsync) };
        }
    }
} 