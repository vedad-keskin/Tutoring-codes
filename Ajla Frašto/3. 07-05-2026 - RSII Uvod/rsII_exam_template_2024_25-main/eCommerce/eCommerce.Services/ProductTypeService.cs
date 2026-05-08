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
using Microsoft.Extensions.Logging;

namespace eCommerce.Services
{
    public class ProductTypeService : 
            BaseCRUDService<ProductTypeResponse, ProductTypeSearchObject, ProductType, ProductTypeUpsertRequest, ProductTypeUpsertRequest>, IProductTypeService
    {
        private readonly eCommerceDbContext _context;
        private readonly ILogger<ProductTypeService> _logger;

        public ProductTypeService(eCommerceDbContext context, IMapper mapper, ILogger<ProductTypeService> logger) : base(context, mapper)
        {
            _context = context;
            _logger = logger;
        }

        protected override IQueryable<ProductType> ApplyFilter(IQueryable<ProductType> query, ProductTypeSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(pt => pt.Name.Contains(search.Name));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(pt => pt.Name.Contains(search.FTS) || pt.Description.Contains(search.FTS));
            }
            return query;
        }


        protected override Task BeforeInsert(ProductType entity, ProductTypeUpsertRequest request)
        { 
            _logger.LogInformation($"User is trying to add product type {request.Name}");

            return base.BeforeInsert(entity, request);
        }

    }
} 