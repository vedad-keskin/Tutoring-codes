using Microsoft.EntityFrameworkCore;
using Studentska.Data.Entiteti;

namespace Studentska.Servis.Servisi
{
    public class StudentServis : BaseServis<Student>
    {


        public List<Student> GetAllIncluded()
        {
            //     db.KnjigeIB180079.ToList();
            return _dbContext
                .Set<Student>()
                .Include(x => x.Grad).ThenInclude(x => x.Drzava)
                .Include(x => x.Spol)
                .ToList();

        }


        public int GetBrojStudenata()
        {
            return _dbContext.Studenti.Count();
        }

    }
}
