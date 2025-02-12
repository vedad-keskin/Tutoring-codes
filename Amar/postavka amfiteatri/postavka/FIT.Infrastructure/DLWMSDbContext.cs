using FIT.Data;
using FIT.Data.IspitIB220152;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace FIT.Infrastructure
{
    public class DLWMSDbContext : DbContext
    {
        private readonly string dbPutanja;

        public DLWMSDbContext()
        {
            dbPutanja = ConfigurationManager.
                ConnectionStrings["DLWMSBaza"].ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(dbPutanja);
        }
    
        public DbSet<Student> Studenti { get; set; }
        public DbSet<SemestriIB220152> Semestri { get; set; }

        public DbSet<PredmetiIB220152> Predmeti { get; set; }
        public DbSet<PolozeniPredmetiIB220152> PolozeniPredmeti { get; set; }
        public DbSet<ProstorijeIB220152> ProstorijeIB220152 { get; set; }
        public DbSet<PrisustvoIB220152> PrisustvoIB220152 { get; set; }
        public DbSet<NastavaIB220152> NastavaIB220152 { get; set; }







    }
}