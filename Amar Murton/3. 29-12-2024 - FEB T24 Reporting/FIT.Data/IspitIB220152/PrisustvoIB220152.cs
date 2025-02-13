using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB220152
{
    public class PrisustvoIB220152
    {
        public int Id { get; set; }
        public int NastavaId { get; set; }
        public NastavaIB220152 Nastava { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
