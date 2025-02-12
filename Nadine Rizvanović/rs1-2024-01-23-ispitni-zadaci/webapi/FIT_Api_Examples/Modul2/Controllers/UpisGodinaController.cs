using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FIT_Api_Examples.Modul2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpisGodinaController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public UpisGodinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        // GET UPISI STUDENT   -    DODAJ UPIS    -   OVJERI UPIS 


        [HttpGet]
        [Route("/GetUpisiStudenta")]

        public ActionResult<List<UpisGodina>> GetUpisiStudenta([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisi = _dbContext.UpisGodina
                .Include(x=> x.student)
                .Include(x=> x.akademskaGodina)
                .Include(x=> x.evidentirao)
                .Where(x=> x.studentid == studentid)
                .ToList();

            if(upisi == null)
            {
                return BadRequest();
            }




            return Ok(upisi);
        }

        [HttpPost]
        [Route("/DodajUpis")]

        public ActionResult DodajUpis([FromBody] DodajUpisVM x )
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            if (_dbContext.UpisGodina.ToList().Exists( u => u.studentid == x.studentid && u.godinaStudija == x.godinaStudija   )   )
            {

                if(x.obnova)
                {
                    var noviUpis = new UpisGodina()
                    {
                        datumUpisa = x.datumUpisa,
                        cijenaSkolarine = x.cijenaSkolarine,
                        godinaStudija = x.godinaStudija,
                        obnova = x.obnova,
                        akademskaGodinaid = x.akademskaGodinaid,
                        evidentiraoid = x.evidentiraoid,
                        studentid = x.studentid,

                    };

                    _dbContext.UpisGodina.Add(noviUpis);
                    _dbContext.SaveChanges();



                    return Ok();
                }
                else
                {
                    return BadRequest();
                }



            }
            else
            {
                var noviUpis = new UpisGodina()
                {
                    datumUpisa = x.datumUpisa,
                    cijenaSkolarine = x.cijenaSkolarine,
                    godinaStudija = x.godinaStudija,
                    obnova = x.obnova,
                    akademskaGodinaid = x.akademskaGodinaid,
                    evidentiraoid = x.evidentiraoid,
                    studentid = x.studentid,

                };

                _dbContext.UpisGodina.Add(noviUpis);
                _dbContext.SaveChanges();



                return Ok();
            }

        }

        [HttpPost]
        [Route("/OvjeriUpis")]
        public ActionResult OvjeriUpis([FromBody] OvjeriUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upis = _dbContext.UpisGodina.Find(x.id);


            if(upis == null)
            {
                return BadRequest();
            }

            upis.datumOvjera = x.datumOvjera;
            upis.napomena = x.napomena;

            _dbContext.SaveChanges();


            return Ok();
        }





    }
}
