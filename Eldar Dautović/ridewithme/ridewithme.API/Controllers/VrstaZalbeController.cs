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
    public class VrstaZalbeController : BaseCRUDController<VrstaZalbe, VrstaZalbeSearchObject, VrstaZalbeInsertRequest, VrstaZalbeUpdateRequest>
    { 
        public VrstaZalbeController(IVrstaZalbeService service) : base(service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override VrstaZalbe Insert(VrstaZalbeInsertRequest request)
        {
            if (request.KorisnikId == null || request.KorisnikId == 0)
            {
                var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                request.KorisnikId = userId;
            }

            return base.Insert(request);
        }

        [HttpDelete("{id}/delete")]
        [Authorize(Roles = "Administrator")]

        public VrstaZalbe Delete(int id)
        {
            return (_service as IVrstaZalbeService).Delete(id);
        }
        public override PagedResult<VrstaZalbe> GetList([FromQuery] VrstaZalbeSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
    }
}
