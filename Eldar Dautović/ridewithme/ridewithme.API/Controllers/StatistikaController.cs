using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using ridewithme.Service.Interfaces;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistikaController : ControllerBase
    {
        protected IStatistikaService _service;
        public StatistikaController(IStatistikaService service)
        {
            _service = service;
        }

        [HttpGet]

        public PagedResult<Statistika> Get()
        {
            return _service.GetList();
        }

        [HttpGet("monthly")]

        public UkupnaStatistika GetMonthlyStatistics()
        {
            return _service.GetMonthlyStatistics();
        }

        [HttpGet("business")]

        public List<PoslovniIzvjestaj> GetBusinessReport()
        {
            return _service.GetBusinessReport();
        }
    }
}
