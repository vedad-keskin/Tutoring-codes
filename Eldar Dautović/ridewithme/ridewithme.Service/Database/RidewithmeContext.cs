using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ridewithme.Service.Database;

public partial class RidewithmeContext : DbContext
{
    public RidewithmeContext()
    {
    }

    public RidewithmeContext(DbContextOptions<RidewithmeContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Korisnici> Korisnicis { get; set; }
    public virtual DbSet<Uloge> Uloge { get; set; }
    public virtual DbSet<Voznje> Voznje { get; set; }
    public virtual DbSet<Gradovi> Gradovi { get; set; }
    public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
    public virtual DbSet<Kuponi> Kuponi { get; set; }
    public virtual DbSet<VrstaZalbe> VrstaZalbe { get; set; }
    public virtual DbSet<Zalbe> Zalbe { get; set; }
    public virtual DbSet<Reklame> Reklame { get; set; }
    public virtual DbSet<Dogadjaji> Dogadjaji { get; set; }
    public virtual DbSet<Obavjestenja> Obavjestenja { get; set; }
    public virtual DbSet<FAQ> FAQs { get; set; }
    public virtual DbSet<KorisniciDostignuca> KorisniciDostignuca { get; set; }
    public virtual DbSet<Dostignuca> Dostignuca { get; set; }
    public virtual DbSet<Recenzija> Recenzije { get; set; }
    public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    public virtual DbSet<Payments> Payments { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=localhost, 1436;Initial Catalog=ridewithme; user=sa; Password=Password_123!; TrustServerCertificate=True");

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.ToTable("Korisnici");

            entity.Property(e => e.DatumKreiranja)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .IsUnicode(false);
            entity.Property(e => e.Ime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasData(
                    new Korisnici { Id = 1, KorisnickoIme = "test", Ime = "Test", Prezime = "Korisnik", Email = "test@gmail.com", LozinkaHash = "KaiUaS4zfaZiZnbuv7TN0r5OfeM=", LozinkaSalt = "AglQFeC8HyIM/UV2yFOa0w==", DatumKreiranja = DateTime.Now },
                    new Korisnici { Id = 2, KorisnickoIme = "admin", Ime = "Admin", Prezime = "Korisnik", Email = "admin@gmail.com", LozinkaHash = "KaiUaS4zfaZiZnbuv7TN0r5OfeM=", LozinkaSalt = "AglQFeC8HyIM/UV2yFOa0w==", DatumKreiranja = DateTime.Now }
                ); //pw string
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.ToTable("Uloge");

            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasData(
               new Uloge { Id = 1, Naziv = "Korisnik" },
               new Uloge { Id = 2, Naziv = "Administrator" });
        });

        modelBuilder.Entity<KorisniciUloge>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("KorisniciUloge");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikId");
            entity.Property(e => e.UlogaId).HasColumnName("UlogaId");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciUloge)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisniciUloge_Korisnici");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisniciUloge)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisniciUloge_Uloge");

            entity.HasData(
               new KorisniciUloge { Id = 1, DatumIzmjene = DateTime.Now, KorisnikId = 1, UlogaId = 1 },
               new KorisniciUloge { Id = 2, DatumIzmjene = DateTime.Now, KorisnikId = 2, UlogaId = 2 });

        });

        modelBuilder.Entity<Dostignuca>(entity =>
        {
            entity.ToTable("Dostignuca");

            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.HasData(
                new Dostignuca { Id = 1, Naziv = "Prva vožnja", Opis = "Završio si svoju prvu vožnju! Dobrodošao u zajednicu!" },
                new Dostignuca { Id = 2, Naziv = "Desetka!", Opis = "Odradio si 10 vožnji! Postaješ pravi profesionalac!" },
                new Dostignuca { Id = 3, Naziv = "Carpool majstor", Opis = "50 vožnji! Već si legenda na putu!" },
                new Dostignuca { Id = 4, Naziv = "Legenda na cesti", Opis = "100 vožnji! Tvoj auto sada zna put napamet!" },
                new Dostignuca { Id = 5, Naziv = "Putni veteran", Opis = "500 vožnji! Obišao si pola zemlje!" },
                new Dostignuca { Id = 6, Naziv = "Putevi su moj dom", Opis = "1000 vožnji! Jesi li siguran da ne živiš u autu?" },
                new Dostignuca { Id = 7, Naziv = "Pet zvjezdica, molim!", Opis = "5/5 ocjena! Samo rijetki uspiju ovako!" },
                new Dostignuca { Id = 8, Naziv = "Pustolov na putu", Opis = "Vozio si se u 10 različitih gradova! Avantura te zove!" }
        );

        });

        modelBuilder.Entity<KorisniciDostignuca>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("KorisniciDostignuca");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikId");
            entity.Property(e => e.DostignuceId).HasColumnName("DostignuceId");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciDostignuca)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisniciDostignuca_Korisnici");

            entity.HasOne(d => d.Dostignuce).WithMany(p => p.KorisniciDostignuca)
                .HasForeignKey(d => d.DostignuceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisniciDostignuca_Dostignuca");

            entity.HasData(
               new KorisniciDostignuca { Id = 1, DatumKreiranja = DateTime.Now, DostignuceId = 1, KorisnikId = 2 });
        });

        modelBuilder.Entity<FAQ>(entity =>
        {
            entity.HasData(
                 new FAQ { Id = 1, KorisnikId = 1, Pitanje = "Kako mogu promijeniti svoju lozinku?", Odgovor = "Lozinku možete promijeniti u postavkama profila pod opcijom 'Uredi profil'.", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now },

                 new FAQ { Id = 3, KorisnikId = 1, Pitanje = "Kako mogu ocijeniti vozača ili saputnika?", Odgovor = "Nakon završene vožnje, možete ostaviti ocjenu i komentar u sekciji 'Vožnje u kojima ste (bili) putnici'.", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now },

                 new FAQ { Id = 4, KorisnikId = 1, Pitanje = "Kako mogu dodati novu vožnju?", Odgovor = "Kliknite na (+) ikonicu, 'Dodaj vožnju', unesite detalje i objavite vožnju.", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now },

                 new FAQ { Id = 5, KorisnikId = 1, Pitanje = "Da li mogu kontaktirati vozača prije vožnje?", Odgovor = "Da, možete poslati poruku vozaču putem chat opcije na platformi.", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now },

                 new FAQ { Id = 6, KorisnikId = 1, Pitanje = "Šta ako vozač ne dođe na dogovorenu lokaciju?", Odgovor = "Možete prijaviti problem putem opcije 'Žalbe' u sekciji profila .", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now }
             );

        });

        modelBuilder.Entity<Gradovi>(entity =>
        {
            entity.HasData(
                new Gradovi { Id = 1, Latitude = 44.2261, Longitude = 17.6658, Naziv = "Travnik" },
                new Gradovi { Id = 2, Latitude = 43.8486, Longitude = 18.3564, Naziv = "Sarajevo" },
                new Gradovi { Id = 3, Latitude = 44.5373, Longitude = 18.6766, Naziv = "Tuzla" },
                new Gradovi { Id = 4, Latitude = 43.3438, Longitude = 17.8078, Naziv = "Mostar" },
                new Gradovi { Id = 5, Latitude = 44.7735, Longitude = 17.1937, Naziv = "Banja Luka" },
                new Gradovi { Id = 6, Latitude = 44.2064, Longitude = 17.6708, Naziv = "Bugojno" },
                new Gradovi { Id = 7, Latitude = 44.1178, Longitude = 17.6111, Naziv = "Jajce" },
                new Gradovi { Id = 8, Latitude = 43.6125, Longitude = 18.9725, Naziv = "Foča" },
                new Gradovi { Id = 9, Latitude = 44.4406, Longitude = 17.2218, Naziv = "Prijedor" },
                new Gradovi { Id = 10, Latitude = 44.9811, Longitude = 15.7471, Naziv = "Bihać" },
                new Gradovi { Id = 11, Latitude = 44.1608, Longitude = 19.1021, Naziv = "Zvornik" },
                new Gradovi { Id = 12, Latitude = 43.2009, Longitude = 17.6847, Naziv = "Široki Brijeg" },
                new Gradovi { Id = 13, Latitude = 44.3608, Longitude = 18.8053, Naziv = "Lukavac" },
                new Gradovi { Id = 14, Latitude = 44.5412, Longitude = 17.3654, Naziv = "Gradiška" },
                new Gradovi { Id = 15, Latitude = 43.3378, Longitude = 17.8139, Naziv = "Stolac" },
                new Gradovi { Id = 16, Latitude = 44.4664, Longitude = 19.1736, Naziv = "Bijeljina" },
                new Gradovi { Id = 17, Latitude = 43.8284, Longitude = 17.4043, Naziv = "Livno" },
                new Gradovi { Id = 18, Latitude = 43.7698, Longitude = 18.0578, Naziv = "Konjic" },
                new Gradovi { Id = 19, Latitude = 44.1249, Longitude = 18.1232, Naziv = "Visoko" },
                new Gradovi { Id = 20, Latitude = 44.7752, Longitude = 17.1924, Naziv = "Doboj" }
            );
        });

        modelBuilder.Entity<Dogadjaji>(entity =>
        {
            entity.HasData(
                new Dogadjaji
                {
                    Id = 1,
                    Naziv = "Tech Conference 2025",
                    Opis = "Najveća tehnološka konferencija godine koja okuplja stručnjake iz cijelog svijeta. Predavanja, radionice i networking na jednom mjestu.",
                    DatumKreiranja = DateTime.Now,
                    DatumIzmjene = DateTime.Now,
                    DatumPocetka = new DateTime(2025, 5, 10, 9, 0, 0),
                    DatumZavrsetka = new DateTime(2025, 5, 12, 18, 0, 0)
                },
                new Dogadjaji
                {
                    Id = 2,
                    Naziv = "Ljetni Muzicki Festival",
                    Opis = "Trodenvni muzički spektakl na obali mora. Nastupi poznatih bendova, DJ-eva i nezaboravna zabava!",
                    DatumKreiranja = DateTime.Now,
                    DatumIzmjene = DateTime.Now,
                    DatumPocetka = new DateTime(2025, 7, 15, 17, 0, 0),
                    DatumZavrsetka = new DateTime(2025, 7, 17, 23, 59, 0)
                },
                new Dogadjaji
                {
                    Id = 3,
                    Naziv = "Startup Weekend",
                    Opis = "Intenzivan vikend za sve koji žele pokrenuti vlastiti biznis. Mentori, investitori i prilika za pitchanje svojih ideja.",
                    DatumKreiranja = DateTime.Now,
                    DatumIzmjene = DateTime.Now,
                    DatumPocetka = new DateTime(2025, 9, 5, 18, 0, 0),
                    DatumZavrsetka = new DateTime(2025, 9, 7, 20, 0, 0)
                },
                new Dogadjaji
                {
                    Id = 4,
                    Naziv = "Zimski Sajam Knjiga",
                    Opis = "Najveći sajam knjiga u regiji. Promocije novih naslova, susreti s autorima i popusti na knjige.",
                    DatumKreiranja = DateTime.Now,
                    DatumIzmjene = DateTime.Now,
                    DatumPocetka = new DateTime(2025, 12, 1, 10, 0, 0),
                    DatumZavrsetka = new DateTime(2025, 12, 5, 19, 0, 0)
                }
            );
        });

        modelBuilder.Entity<Voznje>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.HasOne(v => v.GradOd)
                      .WithMany()
                      .HasForeignKey(v => v.GradOdId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(v => v.GradDo)
                      .WithMany()
                      .HasForeignKey(v => v.GradDoId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(v => v.Vozac)
                      .WithMany()
                      .HasForeignKey(v => v.VozacId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(v => v.Klijent)
                      .WithMany()
                      .HasForeignKey(v => v.KlijentId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasData(
                  new Voznje
                  {
                      Id = 1,
                      StateMachine = "draft",
                      DatumVrijemePocetka = null,
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 27, 10, 0, 0),
                      Napomena = "Draft vožnja za Vozac 1.",
                      Cijena = 25.00,
                      GradOdId = 1,
                      GradDoId = 2,
                      VozacId = 1,
                      KlijentId = null,
                      KuponId = null,
                      DogadjajId = 1
                  },
                  new Voznje
                  {
                      Id = 2,
                      StateMachine = "active",
                      DatumVrijemePocetka = new DateTime(2025, 3, 1, 8, 0, 0),
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 28, 12, 0, 0),
                      Napomena = "Active vožnja za Vozac 1.",
                      Cijena = 20.00,
                      GradOdId = 2,
                      GradDoId = 3,
                      VozacId = 1,
                      KlijentId = null,
                      KuponId = null,
                      DogadjajId = 3
                  },
                  new Voznje
                  {
                      Id = 3,
                      StateMachine = "booked",
                      DatumVrijemePocetka = new DateTime(2025, 3, 2, 9, 30, 0),
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 28, 14, 0, 0),
                      Napomena = "Booked vožnja za Vozac 1.",
                      Cijena = 25.00,
                      GradOdId = 3,
                      GradDoId = 4,
                      VozacId = 1,
                      KlijentId = 2,
                      KuponId = 1,
                      DogadjajId = null
                  },
                  new Voznje
                  {
                      Id = 4,
                      StateMachine = "inprogress",
                      DatumVrijemePocetka = new DateTime(2025, 3, 3, 14, 0, 0),
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 27, 9, 0, 0),
                      Napomena = "InProgress vožnja za Vozac 1.",
                      Cijena = 30.00,
                      GradOdId = 4,
                      GradDoId = 5,
                      VozacId = 1,
                      KlijentId = 2,
                      KuponId = null,
                      DogadjajId = 3
                  },
                  new Voznje
                  {
                      Id = 5,
                      StateMachine = "completed",
                      DatumVrijemePocetka = new DateTime(2025, 3, 4, 10, 0, 0),
                      DatumVrijemeZavrsetka = new DateTime(2025, 3, 4, 14, 0, 0),
                      DatumKreiranja = new DateTime(2025, 2, 26, 11, 0, 0),
                      Napomena = "Completed vožnja za Vozac 1.",
                      Cijena = 40.00,
                      GradOdId = 5,
                      GradDoId = 1,
                      VozacId = 1,
                      KlijentId = 2,
                      KuponId = 2,
                      DogadjajId = 2
                  },
                  // Vozac 2
                  new Voznje
                  {
                      Id = 6,
                      StateMachine = "draft",
                      DatumVrijemePocetka = null,
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 27, 11, 0, 0),
                      Napomena = "Draft vožnja za Vozac 2.",
                      Cijena = 50.00,
                      GradOdId = 1,
                      GradDoId = 2,
                      VozacId = 2,
                      KlijentId = null,
                      KuponId = null,
                      DogadjajId = 1
                  },
                  new Voznje
                  {
                      Id = 7,
                      StateMachine = "active",
                      DatumVrijemePocetka = new DateTime(2025, 3, 5, 8, 0, 0),
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 28, 13, 0, 0),
                      Napomena = "Active vožnja za Vozac 2.",
                      Cijena = 15.00,
                      GradOdId = 2,
                      GradDoId = 3,
                      VozacId = 2,
                      KlijentId = null,
                      KuponId = null,
                      DogadjajId = null
                  },
                  new Voznje
                  {
                      Id = 8,
                      StateMachine = "booked",
                      DatumVrijemePocetka = new DateTime(2025, 3, 5, 8, 0, 0),
                      DatumVrijemeZavrsetka = null,
                      DatumKreiranja = new DateTime(2025, 2, 28, 13, 0, 0),
                      Napomena = "booked vožnja za Vozac 2.",
                      Cijena = 15.00,
                      GradOdId = 2,
                      GradDoId = 3,
                      VozacId = 2,
                      KlijentId = 1,
                      KuponId = null,
                      DogadjajId = 2
                  },
                  new Voznje
                  {
                      Id = 9,
                      StateMachine = "inprogress",
                      DatumVrijemePocetka = DateTime.Now.AddDays(-1),
                      DatumVrijemeZavrsetka = DateTime.Now,
                      DatumKreiranja = DateTime.Now.AddDays(-2),
                      Napomena = "inprogress vožnja za Vozac 2.",
                      Cijena = 15.00,
                      GradOdId = 2,
                      GradDoId = 3,
                      VozacId = 2,
                      KlijentId = 1,
                      KuponId = null,
                      DogadjajId = 1
                  },
                  new Voznje
                  {
                      Id = 10,
                      StateMachine = "completed",
                      DatumVrijemePocetka = DateTime.Now.AddDays(-1),
                      DatumVrijemeZavrsetka = DateTime.Now,
                      DatumKreiranja = DateTime.Now.AddDays(-2),
                      Napomena = "completed vožnja za Vozac 2.",
                      Cijena = 15.00,
                      GradOdId = 2,
                      GradDoId = 3,
                      VozacId = 2,
                      KlijentId = 1,
                      KuponId = null,
                      DogadjajId = 3
                  }
              );

            });

        modelBuilder.Entity<Recenzija>(entity =>
        {
            entity.HasData(
                 new Recenzija { Id = 1, KorisnikId = 1, VoznjaId = 10, Komentar= "Odlična vožnja, prezadovoljan sam vozačem.", Ocjena = 5, DatumKreiranja = DateTime.Now },
                 new Recenzija { Id = 2, KorisnikId = 2, VoznjaId = 5, Komentar = "Okej vožnja, nisam zadivljen posebno, ali stigli smo relativno brzo..", Ocjena = 3, DatumKreiranja = DateTime.Now });

        });


        modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.HasOne(v => v.Sender)
                         .WithMany()
                         .HasForeignKey(v => v.SenderId)
                         .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(v => v.Reciever)
                      .WithMany()
                      .HasForeignKey(v => v.RecieverId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        
            modelBuilder.Entity<Zalbe>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.HasOne(v => v.Administrator)
                      .WithMany()
                      .HasForeignKey(v => v.AdministratorId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(v => v.Korisnik)
                      .WithMany()
                      .HasForeignKey(v => v.KorisnikId)
                      .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<VrstaZalbe>(entity =>
            {
                entity.HasData(
                    new VrstaZalbe { Id = 1, Naziv = "Na vožnju", KorisnikId = 1, DatumIzmjene = DateTime.Now },
                    new VrstaZalbe { Id = 2, Naziv = "Na vozača", KorisnikId = 1, DatumIzmjene = DateTime.Now },
                    new VrstaZalbe { Id = 3, Naziv = "Na aplikaciju", KorisnikId = 1, DatumIzmjene = DateTime.Now },
                    new VrstaZalbe { Id = 4, Naziv = "Ostalo", KorisnikId = 1, DatumIzmjene = DateTime.Now }
                );
            });

            modelBuilder.Entity<Kuponi>(entity =>
            {
                entity.HasData(
                    new Kuponi { Id = 1, Naziv = "Testni kod", KorisnikId = 1, DatumIzmjene = DateTime.Now, BrojIskoristivosti = 5, DatumPocetka = DateTime.Now, Popust = 0.1, Kod = "TESTNI-KOD", StateMachine = "draft" },
                    new Kuponi { Id = 2, Naziv = "Popust dobrodošlice", KorisnikId = 1, DatumIzmjene = DateTime.Now, BrojIskoristivosti = 10, DatumPocetka = DateTime.Now, Popust = 0.5, Kod = "WELCOME", StateMachine = "active" }
                );
            });

            modelBuilder.Entity<Zalbe>(entity =>
            {
                entity.HasData(
                   new Zalbe { Id = 1, Naslov = "Problem prilikom prijave", Sadrzaj = "Prilikom pokušaja prijave na aplikaciju, ne mogu da se prijavim iako unosim ispravne podatke.", KorisnikId = 1, DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, VrstaZalbeId = 3, StateMachine = "active" },
                   new Zalbe { Id = 2, Naslov = "Vozač ne uzvraća poruke", Sadrzaj = "Potrebno je da dogovorim lokaciju polaska sa vozačem vožnje ID: 2 ali ne mogu da dobijem povratnu informaciju od vozača.", KorisnikId = 1, DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, VrstaZalbeId = 2, StateMachine = "active" },
                   new Zalbe { Id = 3, Naslov = "Vožnja nije bila do navedene lokacije", Sadrzaj = "Vožnja je naznačena da je do Sarajeva, a vozili smo se do Kaknja, molim za povrat novca.", KorisnikId = 1, DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, VrstaZalbeId = 1, StateMachine = "active" },
                   new Zalbe { Id = 4, Naslov = "Neiskoristiv kupon", Sadrzaj = "Naznačeno je da koristimo kupon 'WELCOME', ali on ne radi.", KorisnikId = 1, DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, VrstaZalbeId = 4, StateMachine = "active" }
                );
            });

            modelBuilder.Entity<Obavjestenja>(entity =>
            {

                entity.HasData(
                   new Obavjestenja { Id = 1, Naslov = "Ažuriranje pravila privatnosti", Opis = "Ažurirali smo naša pravila privatnosti kako bi ti pružili veću transparentnost i kontrolu nad tvojim podacima. Pregledaj nove postavke privatnosti u aplikaciji i prilagodi ih svojim potrebama.", Podnaslov= "Više kontrole nad tvojim podacima", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, DatumZavrsetka = DateTime.Now.AddDays(2),  KorisnikId= 2, StateMachine = "active"},
                   new Obavjestenja { Id = 2, Naslov = "Stigli su novi alati za bolje iskustvo!", Opis = "RideWithMe je bogatiji za nove funkcionalnosti! Sada možeš lakše planirati putovanja, pratiti svoje vožnje i komunicirati s vozačima direktno iz aplikacije. Ažuriraj aplikaciju i isprobaj nove mogućnosti!", Podnaslov = "Otkrij nove funkcije aplikacije", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, DatumZavrsetka = DateTime.Now.AddHours(2), KorisnikId = 2, StateMachine = "active" },
                   new Obavjestenja { Id = 3, Naslov= "Poboljšana korisnička podrška", Opis = "Uveli smo nove opcije podrške u aplikaciji, uključujući chat uživo i detaljniji centar za pomoć. Kontaktiraj nas jednostavno putem aplikacije za bilo kakva pitanja ili sugestije!", Podnaslov = "Brže rješenje tvojih upita", DatumIzmjene = DateTime.Now, DatumKreiranja = DateTime.Now, DatumZavrsetka = DateTime.Now.AddHours(5), KorisnikId = 2, StateMachine = "active" }
                );
            });

        modelBuilder.Entity<Reklame>(entity =>
        {
            entity.HasData(
                new Reklame
                {
                    Id = 1,
                    NazivKampanje = "Revolucija u Online Kupovini",
                    SadrzajKampanje = "Iskusite novu eru online kupovine uz nevjerojatne popuste i brzu dostavu! Pridružite se milijunima zadovoljnih kupaca širom svijeta.",
                    NazivKlijenta = "ShopMaster Ltd.",
                    DatumIzmjene = DateTime.Now,
                    DatumKreiranja = DateTime.Now,
                    KorisnikId = 2,
                    Slika = Convert.FromBase64String("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")
                },
                new Reklame
                {
                    Id = 2,
                    NazivKampanje = "Vaša Sigurnost je Naš Prioritet",
                    SadrzajKampanje = "Uz SecurityPro, vaša imovina je uvijek zaštićena. Iskoristite posebne pogodnosti prilikom instalacije naših sigurnosnih sustava.",
                    NazivKlijenta = "SecurityPro Solutions",
                    DatumIzmjene = DateTime.Now,
                    DatumKreiranja = DateTime.Now,
                    KorisnikId = 2,
                    Slika = Convert.FromBase64String("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")
                },
                new Reklame
                {
                    Id = 3,
                    NazivKampanje = "Putujte Pametnije, Putujte S Nama",
                    SadrzajKampanje = "DreamTravel vam donosi nevjerojatne aranžmane i popuste na putovanja širom svijeta. Rezervirajte svoje snove još danas!",
                    NazivKlijenta = "DreamTravel Agency",
                    DatumIzmjene = DateTime.Now,
                    DatumKreiranja = DateTime.Now,
                    KorisnikId = 2,
                    Slika = null
                },
                new Reklame
                {
                    Id = 4,
                    NazivKampanje = "Inovacije Koje Mijenjaju Život",
                    SadrzajKampanje = "TechNova donosi vam najnovije tehnološke inovacije koje olakšavaju svakodnevni život. Budite dio budućnosti već danas!",
                    NazivKlijenta = "TechNova Innovations",
                    DatumIzmjene = DateTime.Now,
                    DatumKreiranja = DateTime.Now,
                    KorisnikId = 2,
                    Slika = null
                }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }


}
