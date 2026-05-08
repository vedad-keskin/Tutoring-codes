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
    public class InitialProductState : BaseProductState
    {
        public InitialProductState(IServiceProvider serviceProvider, eCommerceDbContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        public override async Task<ProductResponse> CreateAsync(ProductInsertRequest request)
        {
            // var entity = new TEntity();
            // MapInsertToEntity(entity, request);
            // _context.Set<TEntity>().Add(entity);

            // await BeforeInsert(entity, request);

            // await _context.SaveChangesAsync();
            // return MapToResponse(entity);
            var entity = new Database.Product();
            _mapper.Map(request, entity);

            entity.ProductState = nameof(DraftProductState);

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            if (request.AssetInsertRequest != null)
            {
                Asset asset = new Asset
                {
                    ProductId = entity.Id,
                    FileName = request.AssetInsertRequest.FileName,
                    Base64Content = request.AssetInsertRequest.Base64Content,
                    ContentType = request.AssetInsertRequest.ContentType,
                };


                _context.Assets.Add(asset);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<ProductResponse>(entity);
        }

        public override List<string> AllowedActions(int id)
        {
            return new List<string>() { nameof(CreateAsync) };
        }
    }
} 