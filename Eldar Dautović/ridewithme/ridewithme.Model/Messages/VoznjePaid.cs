using ridewithme.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Messages
{
    public class VoznjePaid
    {
        public VoznjePaid() { }

        public Voznje Voznja { get; set; }

        public string klijentEmail { get; set; }
        public string vozacEmail { get; set; }

        public double totalPrice { get; set; }
    }
}
