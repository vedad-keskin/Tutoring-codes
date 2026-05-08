using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using eCommerce.Services.Responses;

namespace eCommerce.Services
{
    public interface IUnitOfMeasureService : ICRUDService<UnitOfMeasureResponse, UnitOfMeasureSearchObject, UnitOfMeasureUpsertRequest, UnitOfMeasureUpsertRequest>
    {
    }
}