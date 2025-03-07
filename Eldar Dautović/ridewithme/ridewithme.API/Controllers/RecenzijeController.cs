using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Interfaces;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenzijeController : BaseCRUDController<Recenzija, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
    {
        public RecenzijeController(IRecenzijaService service) : base(service)
        {
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}/delete")]

        public Recenzija Delete(int id)
        {
            return (_service as IRecenzijaService).Delete(id);
        }
    }
}
