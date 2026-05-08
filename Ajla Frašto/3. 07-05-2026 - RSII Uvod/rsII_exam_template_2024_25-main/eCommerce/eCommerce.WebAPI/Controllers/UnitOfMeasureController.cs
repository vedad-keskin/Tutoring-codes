using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using eCommerce.Services.Responses;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitOfMeasureController : BaseCRUDController<UnitOfMeasureResponse, UnitOfMeasureSearchObject, UnitOfMeasureUpsertRequest, UnitOfMeasureUpsertRequest>
    {
        public UnitOfMeasureController(IUnitOfMeasureService service) : base(service)
        {
        }
    }
}