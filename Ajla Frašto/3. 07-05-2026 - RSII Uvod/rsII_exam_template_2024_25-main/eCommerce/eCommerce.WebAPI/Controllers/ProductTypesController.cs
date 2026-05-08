using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    [AllowAnonymous]
    public class ProductTypesController : BaseCRUDController<ProductTypeResponse, ProductTypeSearchObject, ProductTypeUpsertRequest, ProductTypeUpsertRequest>
    {
        public ProductTypesController(IProductTypeService productTypeService) : base(productTypeService)
        {
        }
    }
} 