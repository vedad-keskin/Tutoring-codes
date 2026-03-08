using Studentska.Data.Entiteti;

namespace Studentska.Servis.Servisi
{
    public class StudentServis : BaseServis<Student>
    {

        public int GetBrojStudenata()
        {
            return _dbContext.Studenti.Count();
        }

    }
}
