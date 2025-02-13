using FIT_Api_Examples.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class DodajUpisVM
    {
        public DateTime datumUpis { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }

        public int akademskaGodinaId { get; set; }

        public int studentId { get; set; }

        public int evidentiraoId { get; set; }


    }
}
