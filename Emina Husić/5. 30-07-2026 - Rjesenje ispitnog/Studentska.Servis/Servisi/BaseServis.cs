namespace Studentska.Servis.Servisi
{
    public abstract class BaseServis<T> where T : class
    {
        protected StudentskaDbContext _dbContext = new StudentskaDbContext();


        //     List<Knjiga> -> GETALL
        public List<T> GetAll()
        {

            //      db.Drzave.ToList();
            return _dbContext.Set<T>().ToList();
        }       



        // ADD 
        public void Add(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        // UPDATE 
        public void Update(T obj)
        {
            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        // REMOVE 
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
