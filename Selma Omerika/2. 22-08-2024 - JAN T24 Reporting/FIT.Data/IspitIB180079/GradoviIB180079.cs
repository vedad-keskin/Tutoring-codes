﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class GradoviIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Status { get; set; }

        public int DrzavaId { get; set; } // 1

        // ovo se mora includati
        public DrzaveIB180079 Drzava { get; set; } // BiH true 

        public override string ToString()
        {
            return Naziv;
        }

    }
}
