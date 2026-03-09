using Microsoft.EntityFrameworkCore;

namespace Studentska.Servis.Servisi
{

    // AkagServis --->             AkademskaGodina
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();



        // List<Knjiga> 
        public List<T> GetAll()
        {
            // return db.Knjige.ToLis();
            return _dbContext.Set<T>()
                .ToList();
        }       




        public void Add(T obj)
        {

            // db.Knjige.Add(Knjige);
            // db.SaveChanges();

            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(T obj)
        {

            // db.Knjige.Add(Knjige);
            // db.SaveChanges();

            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        public void Remove(T obj)
        {

            // db.Knjige.Add(Knjige);
            // db.SaveChanges();

            _dbContext.Set<T>().Remove(obj);
            _dbContext.SaveChanges();
        }



        // 1 --> 1	2024/2025	...	1

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
