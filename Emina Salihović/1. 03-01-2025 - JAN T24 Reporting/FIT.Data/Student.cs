﻿using FIT.Data.IspitIB180079;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Security.Principal;

namespace FIT.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Aktivan { get; set; }        
        public int SemestarId { get; set; }
        public SemestriIB180079 Semestar { get; set; }

        public int GradId { get; set; }
        public GradoviIB180079 Grad { get; set; }

        //      ako je nesto od ovog isred null  <-  ?? onda mi ispisi ovo
        public string DrzavaInfo => Grad.Drzava.Naziv ?? "N/A";

        [NotMapped]
        public double Prosjek { get; set; }


        public override string ToString()
        {
            // COUT << Indeks << " " << Ime << " " << Prezime << endl;
            return $"{Indeks} {Ime} {Prezime}";
        }
    }
}
