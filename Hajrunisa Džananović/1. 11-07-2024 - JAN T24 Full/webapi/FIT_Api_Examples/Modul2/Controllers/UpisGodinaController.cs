﻿using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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



        // Get upisi studenta

        [HttpGet]
        [Route("/GetUpisiStudenta")]
        public ActionResult<List<UpisGodina>> GetUpisiStudenta([FromQuery]  int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisiStudenta = _dbContext.UpisGodina
                .Include(x=> x.student)
                .Include(x=> x.evidentirao)
                .Include(x=> x.akademskaGodina)
                .Where(x => x.studentid == studentid)
                .ToList();




            return Ok(upisiStudenta);

        }




        // Dodavanje upisa

        [HttpPost]
        [Route("/DodajUpis")]
        public ActionResult DodajUpis([FromBody] DodajUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");


            if (_dbContext.UpisGodina.ToList().Exists(s=> s.studentid == x.studentid && s.godinaStudija == x.godinaStudija  )  )
            {

                if (x.obnova)
                {
                    var noviUpis = new UpisGodina()
                    {
                        datumUpis = x.datumUpis,
                        obnova = x.obnova,
                        cijenaSkolarine = x.cijenaSkolarine,
                        akademskaGodinaid = x.akademskaGodinaid,
                        studentid = x.studentid,
                        evidentiraoid = x.evidentiraoid,
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
                    obnova = x.obnova,
                    cijenaSkolarine = x.cijenaSkolarine,
                    akademskaGodinaid = x.akademskaGodinaid,
                    studentid = x.studentid,
                    evidentiraoid = x.evidentiraoid,
                    godinaStudija = x.godinaStudija,
                };

                _dbContext.UpisGodina.Add(noviUpis);
                _dbContext.SaveChanges();

                return Ok();
            }




        }




        // Ovjera upisa

        [HttpPost]
        [Route("/OvjeriUpis")]
        public ActionResult OvjeriUpis([FromBody] OvjeriUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisZaOvjeru = _dbContext.UpisGodina.Find(x.id);

            if(upisZaOvjeru == null) {
                return BadRequest();
            }

            upisZaOvjeru.datumOvjera = x.datumOvjera;
            upisZaOvjeru.napomena = x.napomena;



            _dbContext.SaveChanges();

            return Ok();
        }





    }
}
