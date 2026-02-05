using Microsoft.EntityFrameworkCore;

namespace Studentska.Servis.Servisi
{
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();

        public List<T> GetAll()
        {
            //     db.Knjige.ToList();
            return _dbContext.Set<T>().ToList();
        }       

        public void Add(T obj)
        {

            // db.Knjige.Add(knjiga)
            // db.SaveChanges();

            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(T obj)
        {

            // db.Knjige.Add(knjiga)
            // db.SaveChanges();

            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        public void Remove(T obj)
        {

            // db.Knjige.Add(knjiga)
            // db.SaveChanges();

            _dbContext.Set<T>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public T? GetById(int id) // 1
        {

            //     db.Knjige.Find(1); --> Id = 1
            return _dbContext.Set<T>().Find(id);
        }
    }
}
