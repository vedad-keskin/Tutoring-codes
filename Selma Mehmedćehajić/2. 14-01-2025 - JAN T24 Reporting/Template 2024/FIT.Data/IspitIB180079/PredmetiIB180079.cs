﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class PredmetiIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Semsetar { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
