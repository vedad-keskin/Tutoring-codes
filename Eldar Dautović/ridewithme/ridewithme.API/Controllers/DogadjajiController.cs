using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Interfaces;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class DogadjajiController : BaseCRUDController<Dogadjaji, DogadjajiSearchObejct, DogadjajiUpsertRequest, DogadjajiUpsertRequest>
    {
        public DogadjajiController(IDogadjaji service) : base(service)
        {
        }

        [HttpDelete("{id}/delete")]

        public Dogadjaji Delete(int id)
        {
            return (_service as IDogadjaji).Delete(id);
        }

        [AllowAnonymous]
        public override PagedResult<Dogadjaji> GetList([FromQuery] DogadjajiSearchObejct searchObject)
        {
            return base.GetList(searchObject);
        }
    }
}
