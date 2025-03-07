using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : BaseCRUDController<Model.Models.Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public RidewithmeContext context { get; set; }
        public KorisniciController(IKorisniciService service, RidewithmeContext ridewithmecontext) : base(service) {
            context = ridewithmecontext;
        }

        [HttpGet("{vozacId}/trusted/{klijentId}")]
        public PovjerljivVozac Trusted(int vozacId, int klijentId)
        {
            return (_service as IKorisniciService).Trusted(vozacId, klijentId);
        }

        [HttpGet("popular")]
        [AllowAnonymous]
        public List<Model.Models.Korisnici> Popular()
        {
            return (_service as IKorisniciService).Popular();
        }

        public override Model.Models.Korisnici GetById(int id)
        {
            return (_service as IKorisniciService).GetById(id);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public Model.Models.Korisnici Login(string username, string password)
        {
            return (_service as IKorisniciService).Login(username, password);
        }

        [HttpPost]
        [AllowAnonymous]
        public override Model.Models.Korisnici Insert(KorisniciInsertRequest request)
        {
            return base.Insert(request);
        }

        [AllowAnonymous]
        public override PagedResult<Model.Models.Korisnici> GetList([FromQuery] KorisniciSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }


        [HttpDelete("{id}/delete")]
        [Authorize(Roles = "Administrator")]

        public Model.Models.Korisnici Delete(int id)
        {
            return (_service as IKorisniciService).Delete(id);
        }

    }
}
