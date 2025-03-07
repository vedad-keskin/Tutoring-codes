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
    [Authorize(Roles = "Administrator")]
    [ApiController]
    public class GradoviController : BaseCRUDController<Gradovi, GradoviSearchObject, GradoviUpsertRequest, GradoviUpsertRequest>
    {
        public GradoviController(IGradoviService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override Gradovi GetById(int id)
        {
            return base.GetById(id);
        }

        [AllowAnonymous]
        public override PagedResult<Gradovi> GetList([FromQuery] GradoviSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [HttpDelete("{id}/delete")]

        public Gradovi Delete(int id)
        {
            return (_service as IGradoviService).Delete(id);
        }
    }
}
