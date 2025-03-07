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
    [Authorize(Roles = "Administrator")]

    public class FAQController : BaseCRUDController<FAQ, FAQSearchObject, FAQInsertRequest, FAQUpdateRequest>
    {
        public FAQController(IFAQService service) : base(service)
        {

        }

        [AllowAnonymous]
        public override PagedResult<FAQ> GetList([FromQuery] FAQSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [Authorize(Roles = "Administrator")]
        public override FAQ Insert(FAQInsertRequest request)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            request.KorisnikId = userId;

            return base.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}/delete")]

        public FAQ Delete(int id)
        {
            return (_service as IFAQService).Delete(id);
        }

    }
}
