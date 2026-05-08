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
using EasyNetQ;
using eCommerce.Model.Messages;

namespace eCommerce.Services.ProductStateMachine
{
    public class DraftProductState : BaseProductState
    {
        public DraftProductState(IServiceProvider serviceProvider, eCommerceDbContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<ProductResponse> UpdateAsync(int id, ProductUpdateRequest request)
        {
            var entity = await _context.Products.FindAsync(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            var bus = RabbitHutch.CreateBus("host=localhost");


            var response = _mapper.Map<ProductResponse>(entity);

            var productUpdated = new ProductUpdated
            {
                Product = response
            };
            //await bus.PubSub.PublishAsync(productUpdated);

            return response;
        }

        public override async Task<ProductResponse> ActivateAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            entity.ProductState = nameof(ActiveProductState);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(entity);
        }

        public override async Task<ProductResponse> DeactivateAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            entity.ProductState = nameof(DeactivatedProductState);
            entity.Name = entity.Name + "Deactivated from draft";

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(entity);
        }

        public override List<string> AllowedActions(int id)
        {
            return new List<string>() { nameof(ActivateAsync), nameof(UpdateAsync), nameof(DeactivateAsync) };
        }
    }
} 