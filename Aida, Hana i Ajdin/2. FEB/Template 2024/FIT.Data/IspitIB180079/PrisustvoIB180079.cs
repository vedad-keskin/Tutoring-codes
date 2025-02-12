using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class PrisustvoIB180079
    {
        public int Id { get; set; }
        public int NastavaId { get; set; }


        // ovo se mora includati u ispis
        public NastavaIB180079 Nastava { get; set; }
        public int StudentId { get; set; }


        // ovo se mora includati u ispis
        public Student Student { get; set; }
    }
}
