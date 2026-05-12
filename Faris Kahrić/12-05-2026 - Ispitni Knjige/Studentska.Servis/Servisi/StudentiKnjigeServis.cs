using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Servis.Servisi
{
    public class StudentiKnjigeServis : BaseServis<StudentiKnjigeIB180079>
    {
        public List<StudentiKnjigeIB180079> GetAllIncluded()
        {
            //     db.KnjigeIB180079  <--->   .ToList();
            return _dbContext.Set<StudentiKnjigeIB180079>()
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                .ToList();
        }


    }
}
