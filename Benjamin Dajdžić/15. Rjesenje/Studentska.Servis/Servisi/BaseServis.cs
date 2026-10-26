using Microsoft.EntityFrameworkCore;

namespace Studentska.Servis.Servisi
{


    //                             T -> Knjige
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();



        //     List<Knjige> 
        public List<T> GetAll()
        {
            //     db.Knjige.ToList();
            return _dbContext.Set<T>()
                .ToList();
        }


        //              T -> Knjige
        public void Add(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        //              T -> Knjige
        public void Update(T obj)
        {
            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        //              T -> Knjige
        public void Remove(T obj)
        {
            _dbContext.Set<T>().Remove(obj);
            _dbContext.SaveChanges();
        }



        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
