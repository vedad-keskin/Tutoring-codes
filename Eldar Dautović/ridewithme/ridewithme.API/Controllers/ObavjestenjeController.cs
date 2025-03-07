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
    public class ObavjestenjeController : BaseCRUDController<Obavjestenja, ObavjestenjaSearchObject, ObavjestenjaInsertRequest, ObavjestenjaUpdateRequest>
    {
        public ObavjestenjeController(IObavjestenjaService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override PagedResult<Obavjestenja> GetList([FromQuery] ObavjestenjaSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [HttpPut("{id}/activate")]

        public Obavjestenja Activate(int id)
        {
            return (_service as IObavjestenjaService).Activate(id);
        }

        [HttpPut("{id}/complete")]

        public Obavjestenja Complete(int id)
        {
            return (_service as IObavjestenjaService).Complete(id);
        }

        [HttpPut("{id}/edit")]

        public Obavjestenja Edit(int id)
        {
            return (_service as IObavjestenjaService).Edit(id);
        }

        [HttpDelete("{id}/delete")]

        public Obavjestenja Delete(int id)
        {
            return (_service as IObavjestenjaService).Delete(id);
        }

        [HttpPut("{id}/hide")]

        public Obavjestenja Hide(int id)
        {
            return (_service as IObavjestenjaService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]

        public List<string> AllowedActions(int id)
        {
            return (_service as IObavjestenjaService).AllowedActions(id);
        }

        public override Obavjestenja Insert(ObavjestenjaInsertRequest request)
        {
            if (request.KorisnikId == null || request.KorisnikId == 0)
            {
                var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                request.KorisnikId = userId;
            }

            return base.Insert(request);
        }
    }
}
