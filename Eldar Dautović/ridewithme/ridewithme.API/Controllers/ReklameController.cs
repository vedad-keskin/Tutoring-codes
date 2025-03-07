using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Interfaces;
using System.Security.Claims;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReklameController : BaseCRUDController<Reklame, ReklameSearchObject, ReklameInsertRequest, ReklameUpdateRequest>
    {
        public ReklameController(IReklameService service) : base(service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override Reklame Insert(ReklameInsertRequest request)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            request.KorisnikId = userId; 

            return base.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        public override Reklame Update(int id, ReklameUpdateRequest request)
        {
            return base.Update(id, request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}/delete")]

        public Reklame Delete(int id)
        {
            return (_service as IReklameService).Delete(id);
        }

        [AllowAnonymous]
        public override PagedResult<Reklame> GetList([FromQuery] ReklameSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
    }
}
