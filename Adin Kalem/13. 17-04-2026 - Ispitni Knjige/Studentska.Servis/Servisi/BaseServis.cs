using Microsoft.EntityFrameworkCore;

namespace Studentska.Servis.Servisi
{


    //                            Knjige
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();


        //      StudentiKnjige
        public List<T> GetAll()
        {

            //     db.StudentiKnjige.ToList();
            return _dbContext.Set<T>().ToList();
        }       

        public void Add(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
