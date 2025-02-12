using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB210166
{
    public class StudentiUlogeIB210166
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int UlogaId { get; set; }
        public UlogeIB210166 uloga { get; set; }
    }
}
