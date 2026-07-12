using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Servis.Servisi
{
    public class StudentiProjektiServis : BaseServis<StudentiProjektiIB180079>
    {


        public List<StudentiProjektiIB180079> GetAllIncluded()
        {
            return _dbContext.Set<StudentiProjektiIB180079>()
                .Include(x => x.Student)
                .Include(x => x.Projekat)
                .ToList();
        }


    }
}
