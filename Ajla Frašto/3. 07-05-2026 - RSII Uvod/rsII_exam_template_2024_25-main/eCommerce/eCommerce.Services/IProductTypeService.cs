using eCommerce.Services.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Responses;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;

namespace eCommerce.Services
{
    public interface IProductTypeService : ICRUDService<ProductTypeResponse, ProductTypeSearchObject, ProductTypeUpsertRequest, ProductTypeUpsertRequest>
    {
    }
} 