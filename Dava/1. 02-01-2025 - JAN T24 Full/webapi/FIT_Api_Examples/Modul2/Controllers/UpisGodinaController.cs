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

        // GETBYID   -- UPIS GODINE   -- OVJERA GODINE


        [HttpGet]
        [Route("/GetUpisiStudenta")]

        public ActionResult<List<UpisGodina>> GetUpisiStudenta([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisi = _dbContext.UpisGodina
                .Include(x=> x.evidentirao)
                .Include(x=> x.akademskaGodina)
                .Include(x=> x.student)

                .Where(x => x.studentid == studentid)
                .ToList();



            if(upisi == null)
            {
                return BadRequest();
            }

            return Ok(upisi);
        }


        [HttpPost]
        [Route("/UpisiGodinu")]

        public ActionResult UpisiGodinu([FromBody] UpisiGodinuVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");


            if (_dbContext.UpisGodina.ToList().Exists( u => u.studentid == x.studentid && u.godinaStudija == x.godinaStudija )  )
            {

                if (x.obnova)
                {

                    var noviUpis = new UpisGodina()
                    {
                        datumUpis = x.datumUpis,
                        studentid = x.studentid,
                        cijenaSkolarine = x.cijenaSkolarine,
                        evidentiraoid = x.evidentiraoid,
                        obnova = x.obnova,
                        akademskaGodinaid = x.akademskaGodinaid,
                        godinaStudija = x.godinaStudija,


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
                    studentid = x.studentid,
                    cijenaSkolarine = x.cijenaSkolarine,
                    evidentiraoid = x.evidentiraoid,
                    obnova = x.obnova,
                    akademskaGodinaid = x.akademskaGodinaid,
                    godinaStudija = x.godinaStudija,


                };

                _dbContext.UpisGodina.Add(noviUpis);
                _dbContext.SaveChanges();


                return Ok();
            }

        }

        [HttpPost]

        [Route("/OvjeriGodinu")]

        public ActionResult OvjeriGodinu([FromBody] OvjeriGodinuVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var odabraniUpis = _dbContext.UpisGodina.Find(x.id);

            if(odabraniUpis == null)
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
