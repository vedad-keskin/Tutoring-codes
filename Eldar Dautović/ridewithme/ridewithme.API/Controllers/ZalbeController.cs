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
    public class ZalbeController : BaseCRUDController<Zalbe, ZalbeSearchObject, ZalbeInsertRequest, ZalbeUpdateRequest>
    {
        public ZalbeController(IZalbeService service) : base(service)
        {
        }

        [HttpPut("{id}/process")]

        public Zalbe Processing(int id)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return (_service as IZalbeService).Processing(id, userId);
        }

        [HttpPut("{id}/activate")]

        public Zalbe Activate(int id)
        {
            return (_service as IZalbeService).Activate(id);
        }

        [HttpPut("{id}/complete")]

        public Zalbe Complete(int id, ZalbeCompleteRequest request)
        {
            return (_service as IZalbeService).Complete(id, request);
        }

        [HttpDelete("{id}/delete")]

        public Zalbe Delete(int id)
        {
            return (_service as IZalbeService).Delete(id);
        }

        [HttpGet("{id}/allowedActions")]

        public List<string> AllowedActions(int id)
        {
            return (_service as IZalbeService).AllowedActions(id);
        }

    }
}
