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
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Services.ProductStateMachine
{
    public class BaseProductState
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly eCommerceDbContext _context;
        protected readonly IMapper _mapper;

        public BaseProductState(IServiceProvider serviceProvider, eCommerceDbContext context, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _context = context;
            _mapper = mapper;

        }
        public virtual async Task<ProductResponse> CreateAsync(ProductInsertRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual async Task<ProductResponse> UpdateAsync(int id, ProductUpdateRequest request)
        {
            throw new UserException("Not allowed");
        }

        public virtual async Task<ProductResponse> ActivateAsync(int id)
        {
            throw new UserException("Not allowed");
        }

        public virtual async Task<ProductResponse> DeactivateAsync(int id)
        {
            throw new UserException("Not allowed");
        }

        public BaseProductState GetProductState(string stateName)
        {
            switch (stateName)
            {
                case "InitialProductState":
                    return _serviceProvider.GetService<InitialProductState>();
                case nameof(DraftProductState):
                    return _serviceProvider.GetService<DraftProductState>();
                case nameof(ActiveProductState):
                    return _serviceProvider.GetService<ActiveProductState>();
                case nameof(DeactivatedProductState):
                    return _serviceProvider.GetService<DeactivatedProductState>();

                default:
                    throw new Exception($"State {stateName} not defined");
            }
        }
        
        public virtual List<string> AllowedActions(int id) 
        {
            throw new UserException("Metoda nije dozvoljena");
        }
   }
} 