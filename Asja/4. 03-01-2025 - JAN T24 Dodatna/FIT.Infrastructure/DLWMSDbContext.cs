using FIT.Data;
using FIT.Data.IspitIB230030;
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
        public DbSet<PredmetiIB230030> Predmeti { get; set; }
        public DbSet<SemestriIB230030> Semestri { get; set; }
        public DbSet<PolozeniPredmetiIB230030> PolozeniPredmeti { get; set; }
        public DbSet<DrzaveIB230030> DrzaveIB230030{ get; set; }
        public DbSet<GradoviIB230030> GradoviIB230030 { get; set; }
    }
}