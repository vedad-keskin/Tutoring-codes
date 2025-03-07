using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Interfaces;
using System.Security.Claims;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuponiController : BaseCRUDController<Kuponi, KuponiSearchObject, KuponiInsertRequest, KuponiUpdateRequest>
    {
        public KuponiController(IKuponiService service) : base(service)
        {
        }
        
        [Authorize(Roles = "Administrator")]
        public override Kuponi Insert(KuponiInsertRequest request)
        {
            if (request.KorisnikId == null || request.KorisnikId == 0)
            {
                var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                request.KorisnikId = userId;
            }
            return base.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        public override Kuponi Update(int id, KuponiUpdateRequest request)
        {
            return base.Update(id, request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}/delete")]

        public Kuponi Delete(int id)
        {
            return (_service as IKuponiService).Delete(id);
        }

        [HttpPut("{id}/activate")]

        public Kuponi Activate(int id)
        {
            return (_service as IKuponiService).Activate(id);
        }

        [HttpGet("check")]

        public ProvjerenKupon Check(string kod)
        {
            return (_service as IKuponiService).Check(kod);
        }

        [HttpPut("{id}/hide")]

        public Kuponi Hide(int id)
        {
            return (_service as IKuponiService).Hide(id);
        }

        [HttpPut("{id}/edit")]

        public Kuponi Edit(int id)
        {
            return (_service as IKuponiService).Edit(id);
        }


        [HttpGet("{id}/allowedActions")]

        public List<string> AllowedActions(int id)
        {
            return (_service as IKuponiService).AllowedActions(id);
        }
    }
}
