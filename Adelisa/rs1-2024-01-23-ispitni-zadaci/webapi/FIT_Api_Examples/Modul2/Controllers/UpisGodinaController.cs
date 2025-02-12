using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UpisGodinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpisGodinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        // GET UPISI NEKOG STUDENTA ,  DODAVANJE NOVOG UPISA , OVJERA UPISA


        [HttpGet]
        [Route("/GetUpisi")]

        public ActionResult<List<UpisGodina>> GetUpisi([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisi = _dbContext.UpisGodina
                .Include(x=> x.student)
                .Include(x=> x.evidentirao)
                .Include(x=> x.akademskaGodina)
                .Where(x=> x.studentId == studentid).ToList();

            if(upisi == null)
            {
                return BadRequest();
            }

            return Ok(upisi);
        }


        [HttpPost]
        [Route("/DodajUpis")]

        public ActionResult DodajUpis([FromBody] DodajUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            // 1 godinaStudija   obnova = false
            // 1 godinaStudija   obnova = true
            // 2 godinaStudija   obnova = false

            if (_dbContext.UpisGodina.ToList().Exists(s => s.studentId == x.studentId && s.godinaStudija == x.godinaStudija))
            {

                if (x.obnova)
                {
                    var noviUpis = new UpisGodina()
                    {
                        datumUpis = x.datumUpis,
                        akademskaGodinaId = x.akademskaGodinaId,
                        studentId = x.studentId,
                        godinaStudija = x.godinaStudija,
                        evidentiraoId = x.evidentiraoId,
                        cijenaSkolarine = x.cijenaSkolarine,
                        obnova = x.obnova
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
                    datumUpis = x.datumUpis,
                    akademskaGodinaId = x.akademskaGodinaId,
                    studentId = x.studentId,
                    godinaStudija = x.godinaStudija,
                    evidentiraoId = x.evidentiraoId,
                    cijenaSkolarine = x.cijenaSkolarine,
                    obnova = x.obnova
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

            var odabraniUpis = _dbContext.UpisGodina.Find(x.id);

            if (odabraniUpis == null)
            {
                return BadRequest();
            }

            odabraniUpis.datumOvjera = x.datumOvjera;
            odabraniUpis.napomena = x.napomena;


            _dbContext.SaveChanges();


            return Ok();
        }

    }
}
