using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.ispitIB230030
{
    public class PrisustvoIB230030
    {
        public int Id { get; set; }
        public int NastavaID { get; set; }
        public NastavaIB230030 Nastava { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
