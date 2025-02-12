using FIT.Data;
using FIT.Data.IspitIB210166;
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
        public DbSet<NastavaIB210166> NastavaIB210166 { get; set; }
        public DbSet<PrisustvoIB210166> PrisustvoIB210166 { get; set; }
        public DbSet<ProstorijeIB210166> ProstorijeIB210166 { get; set; }


        public DbSet<SemestriIB210166> Semestri { get; set; }
        public DbSet<StudentiUlogeIB210166> StudentiUloge { get; set; }
        public DbSet<UlogeIB210166> Uloge { get; set; }
        public DbSet<PredmetiIB210166> Predmeti { get; set; }
        public DbSet<PolozeniPredmetiIB210166> PolozeniPredmeti { get; set; }



    }
}