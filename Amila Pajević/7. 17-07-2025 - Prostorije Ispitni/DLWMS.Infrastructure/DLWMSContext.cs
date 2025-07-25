﻿using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace DLWMS.Infrastructure
{
    public class DLWMSContext : DbContext
    {
      
        private string konekcijskiString = ConfigurationManager.ConnectionStrings["DLWMSBaza"].ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(konekcijskiString);
        }











        public DbSet<Student> Studenti { get; set; }
        public DbSet<AkademskaGodina> AkademskeGodine { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Spol> Spolovi { get; set; }
        public DbSet<ProstorijeIB180079> ProstorijeIB180079 { get; set; }
        public DbSet<NastavaIB180079> NastavaIB180079 { get; set; }
        public DbSet<PrisustvoIB180079> PrisustvoIB180079 { get; set; }

    }
}
