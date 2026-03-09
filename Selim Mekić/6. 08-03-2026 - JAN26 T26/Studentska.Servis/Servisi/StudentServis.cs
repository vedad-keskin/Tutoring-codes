using Microsoft.EntityFrameworkCore;
using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;

namespace Studentska.Servis.Servisi
{
    public class StudentServis : BaseServis<Student>
    {

        public int GetBrojStudenata()
        {
            return _dbContext.Studenti.Count();
        }

        public List<Student> GetAllIncluded()
        {
            // return db.Knjige.ToLis();
            return _dbContext.Set<Student>()
                .Include(x => x.Grad.Drzava)
                .Include(x => x.Spol)
                .ToList();
        }

    }
}
