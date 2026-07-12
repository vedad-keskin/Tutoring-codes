using Microsoft.EntityFrameworkCore;

using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
using System.Configuration;

namespace Studentska.Servis
{
    public class StudentskaDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["StudentskaDb"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Spol> Spolovi { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<AkademskaGodina> AkademskeGodine { get; set; }
        public DbSet<ProjektiIB180079> ProjektiIB180079 { get; set; }
        public DbSet<StudentiProjektiIB180079> StudentiProjektiIB180079 { get; set; }

    }
}
