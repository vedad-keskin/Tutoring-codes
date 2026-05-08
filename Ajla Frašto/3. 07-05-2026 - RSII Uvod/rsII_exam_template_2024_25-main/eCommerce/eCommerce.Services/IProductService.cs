using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Model.Requests;

namespace eCommerce.Services
{
    public interface IProductService : ICRUDService<ProductResponse, ProductSearchObject, ProductInsertRequest, ProductUpdateRequest>
    {
        Task<ProductResponse> ActivateAsync(int id);
        Task<ProductResponse> DeactivateAsync(int id);
        List<string> AllowedActions(int id);
        Task CreateDummyOrderDataAsync(int userId, int numberOfOrders = 10);
        List<ProductResponse> Recommend(int id);
    }
}
