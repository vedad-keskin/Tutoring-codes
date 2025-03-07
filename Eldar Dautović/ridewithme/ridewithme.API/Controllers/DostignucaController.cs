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
    [Authorize(Roles = "Administrator")]
    [ApiController]
    public class DostignucaController : BaseCRUDController<Dostignuca, DostignucaSearchObject, DostignucaUpsertRequest, DostignucaUpsertRequest>
    {
        public DostignucaController(IDostignucaService service) : base(service)
        {
        }
    }
}
