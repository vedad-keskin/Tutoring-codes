﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class ProstorijeIB180079
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public byte[] Logo { get; set; }
        public int Kapacitet { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
