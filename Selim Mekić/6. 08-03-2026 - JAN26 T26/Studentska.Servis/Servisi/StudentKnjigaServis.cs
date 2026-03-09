using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Servis.Servisi
{
    public class StudentKnjigaServis : BaseServis<StudentiKnjigeIB180079>
    {


        public List<StudentiKnjigeIB180079> GetAllIncluded()
        {
            // return db.Knjige.ToLis();
            return _dbContext.Set<StudentiKnjigeIB180079>()
                .Include(x => x.Knjiga)
                .Include(x => x.Student)
                .ToList();
        }


    }
}
