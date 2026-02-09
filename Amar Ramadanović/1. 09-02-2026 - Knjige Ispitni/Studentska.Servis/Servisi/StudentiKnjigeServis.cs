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
            //     db.Knjige.ToList();
            return _dbContext.Set<StudentiKnjigeIB180079>()
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                .ToList();
        }

        //public List<StudentiKnjigeIB180079> GetAllIncludedWithFilter(bool vracena)
        //{
        //    //     db.Knjige.ToList();
        //    return _dbContext.Set<StudentiKnjigeIB180079>()
        //        .Include(x => x.Student)
        //        .Include(x => x.Knjiga)
        //        .Where(x => x.Vracena == vracena)
        //        .ToList();
        //}

    }
}
