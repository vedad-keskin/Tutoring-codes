using System;
using System.Collections.Generic;
using System.Text;
using ridewithme.Model.Models;

namespace ridewithme.Model.Messages
{
    public class VoznjeActivated
    {
        public VoznjeActivated() { }

        public Voznje Voznja { get; set; }

        public string email { get; set; }
    }
}
