using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Interfaces;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UlogeController : BaseCRUDController<Uloge, UlogeearchObject, UlogeUpsertRequest, UlogeUpsertRequest>
    {
        public UlogeController(IUlogeervice service) : base(service)
        {
        }
    }
}
