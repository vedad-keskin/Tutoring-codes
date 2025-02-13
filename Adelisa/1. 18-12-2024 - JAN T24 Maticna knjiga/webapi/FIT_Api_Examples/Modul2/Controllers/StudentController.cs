﻿using System;
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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

      

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .Where(x=> x.Obrisan == false)
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        //  ADD/EDIT STUDENT    DELETE (SOFT DELETE)     GET STUDENT 


        [HttpPost]
        [Route("/DodajStudent")]

        public ActionResult DodajStudent([FromBody] DodajStudentVM x )
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");


            Student novi;

            if(x.id == 0) // dodavanje novog studenta
            {
                novi = new Student();
                _dbContext.Student.Add(novi);

            }
            else // editovanje nekog studenta
            {
                novi = _dbContext.Student.Find(x.id);
            }

            novi.ime = x.ime;
            novi.prezime = x.prezime;
            novi.opstina_rodjenja_id = x.opstina_rodjenja_id;
            novi.Obrisan = false;

            _dbContext.SaveChanges();


            return Ok();
        }

        [HttpPost]
        [Route("/ObrisiStudenta")]

        public ActionResult ObrisiStudenta([FromBody] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var student = _dbContext.Student.Find(studentid);

            if(student == null)
            {
                return BadRequest();
            }


            //_dbContext.Student.Remove(student);

            student.Obrisan = true;

            _dbContext.SaveChanges();


            return Ok();
        }

        [HttpGet]
        [Route("/GetStudent")]

        public ActionResult GetStudent([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var student = _dbContext.Student.Find(studentid);

            if (student == null)
            {
                return BadRequest();
            }




            return Ok(student);
        }




    }
}
