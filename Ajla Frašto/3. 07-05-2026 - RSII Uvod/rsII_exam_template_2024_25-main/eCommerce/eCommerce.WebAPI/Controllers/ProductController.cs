using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Requests;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.WebAPI.Controllers
{

    public class ProductController : BaseCRUDController<ProductResponse, ProductSearchObject, ProductInsertRequest, ProductUpdateRequest>
    {
        IProductService _productService;
        public ProductController(IProductService service) : base(service)
        {
            _productService = service;
        }

        [HttpPost]
        // [Authorize(Roles = "Administrator")]
        public override async Task<ProductResponse> Create([FromBody] ProductInsertRequest request)
        {
            return await _crudService.CreateAsync(request);
        }

        [HttpPut("{id}/activate")]
        public virtual async Task<ProductResponse?> ActivateAsync(int id)
        {
            return await _productService.ActivateAsync(id);
        }

        [HttpPut("{id}/deactivate")]
        public virtual async Task<ProductResponse?> DeactivateAsync(int id)
        {
            return await _productService.DeactivateAsync(id);
        }

        [HttpGet("{id}/allowed-actions")]
        public virtual List<string> AllowedActions(int id)
        {
            return _productService.AllowedActions(id);
        }
        [HttpPost("dummy-orders")]
        public virtual async Task CreateDummyOrderDataAsync(int userId, int numberOfOrders = 10)
        {
            await _productService.CreateDummyOrderDataAsync(userId, numberOfOrders);
        }

        [HttpGet("{id}/recommend")]
        public virtual List<ProductResponse> Recommend(int id)
        {
            return _productService.Recommend(id);
        }
    }
}
