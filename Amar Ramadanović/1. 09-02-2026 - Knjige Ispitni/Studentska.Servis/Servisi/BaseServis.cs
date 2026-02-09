using Microsoft.EntityFrameworkCore;

namespace Studentska.Servis.Servisi
{

    //                          Knjiga
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();


        // List<Knjiga>
        public List<T> GetAll()
        {


            //     db.Knjige.ToList();
            return _dbContext.Set<T>()
                .ToList();
        }

        //          AkademskaGodina -> obj
        public void Add(T obj)
        {

            // db.Knjige.Add(k);
            // db.SaveChanges();

            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }
        public void Update(T obj)
        {

            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        public void Remove(T obj)
        {

            _dbContext.Set<T>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public T? GetById(int id)
        {


            //     db.AkademskaGodine.Find(1); --> 1	2024/2025	...	1
            return _dbContext.Set<T>().Find(id);
        }
    }
}
