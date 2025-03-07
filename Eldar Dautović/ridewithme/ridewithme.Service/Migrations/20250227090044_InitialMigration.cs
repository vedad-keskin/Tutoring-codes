using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ridewithme.Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogadjaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dostignuca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostignuca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(320)", unicode: false, maxLength: 320, nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Korisnici_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatMessages_Korisnici_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pitanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciDostignuca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DostignuceId = table.Column<int>(type: "int", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciDostignuca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisniciDostignuca_Dostignuca",
                        column: x => x.DostignuceId,
                        principalTable: "Dostignuca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KorisniciDostignuca_Korisnici",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kuponi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojIskoristivosti = table.Column<int>(type: "int", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Popust = table.Column<double>(type: "float", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuponi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kuponi_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavjestenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Podnaslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavjestenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavjestenja_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reklame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivKampanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SadrzajKampanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reklame_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VrstaZalbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaZalbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VrstaZalbe_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnici",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voznje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemePocetka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumVrijemeZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    GradOdId = table.Column<int>(type: "int", nullable: false),
                    GradDoId = table.Column<int>(type: "int", nullable: false),
                    VozacId = table.Column<int>(type: "int", nullable: false),
                    KlijentId = table.Column<int>(type: "int", nullable: true),
                    KuponId = table.Column<int>(type: "int", nullable: true),
                    DogadjajId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voznje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voznje_Dogadjaji_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaji",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voznje_Gradovi_GradDoId",
                        column: x => x.GradDoId,
                        principalTable: "Gradovi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voznje_Gradovi_GradOdId",
                        column: x => x.GradOdId,
                        principalTable: "Gradovi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voznje_Korisnici_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voznje_Korisnici_VozacId",
                        column: x => x.VozacId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voznje_Kuponi_KuponId",
                        column: x => x.KuponId,
                        principalTable: "Kuponi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zalbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdgovorNaZalbu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPreuzimanja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VrstaZalbeId = table.Column<int>(type: "int", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zalbe_Korisnici_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zalbe_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zalbe_VrstaZalbe_VrstaZalbeId",
                        column: x => x.VrstaZalbeId,
                        principalTable: "VrstaZalbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    VoznjaId = table.Column<int>(type: "int", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzije_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzije_Voznje_VoznjaId",
                        column: x => x.VoznjaId,
                        principalTable: "Voznje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dogadjaji",
                columns: new[] { "Id", "DatumIzmjene", "DatumKreiranja", "DatumPocetka", "DatumZavrsetka", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4733), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4725), new DateTime(2025, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference 2025", "Najveća tehnološka konferencija godine koja okuplja stručnjake iz cijelog svijeta. Predavanja, radionice i networking na jednom mjestu." },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4755), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4749), new DateTime(2025, 7, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 17, 23, 59, 0, 0, DateTimeKind.Unspecified), "Ljetni Muzicki Festival", "Trodenvni muzički spektakl na obali mora. Nastupi poznatih bendova, DJ-eva i nezaboravna zabava!" },
                    { 3, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4770), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4764), new DateTime(2025, 9, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 7, 20, 0, 0, 0, DateTimeKind.Unspecified), "Startup Weekend", "Intenzivan vikend za sve koji žele pokrenuti vlastiti biznis. Mentori, investitori i prilika za pitchanje svojih ideja." },
                    { 4, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4785), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4779), new DateTime(2025, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Zimski Sajam Knjiga", "Najveći sajam knjiga u regiji. Promocije novih naslova, susreti s autorima i popusti na knjige." }
                });

            migrationBuilder.InsertData(
                table: "Dostignuca",
                columns: new[] { "Id", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Prva vožnja", "Završio si svoju prvu vožnju! Dobrodošao u zajednicu!" },
                    { 2, "Desetka!", "Odradio si 10 vožnji! Postaješ pravi profesionalac!" },
                    { 3, "Carpool majstor", "50 vožnji! Već si legenda na putu!" },
                    { 4, "Legenda na cesti", "100 vožnji! Tvoj auto sada zna put napamet!" },
                    { 5, "Putni veteran", "500 vožnji! Obišao si pola zemlje!" },
                    { 6, "Putevi su moj dom", "1000 vožnji! Jesi li siguran da ne živiš u autu?" },
                    { 7, "Pet zvjezdica, molim!", "5/5 ocjena! Samo rijetki uspiju ovako!" },
                    { 8, "Pustolov na putu", "Vozio si se u 10 različitih gradova! Avantura te zove!" }
                });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "Id", "Latitude", "Longitude", "Naziv" },
                values: new object[,]
                {
                    { 1, 44.226100000000002, 17.665800000000001, "Travnik" },
                    { 2, 43.848599999999998, 18.356400000000001, "Sarajevo" },
                    { 3, 44.537300000000002, 18.676600000000001, "Tuzla" },
                    { 4, 43.343800000000002, 17.8078, "Mostar" },
                    { 5, 44.773499999999999, 17.1937, "Banja Luka" },
                    { 6, 44.206400000000002, 17.6708, "Bugojno" },
                    { 7, 44.117800000000003, 17.6111, "Jajce" },
                    { 8, 43.612499999999997, 18.9725, "Foča" },
                    { 9, 44.440600000000003, 17.221800000000002, "Prijedor" },
                    { 10, 44.981099999999998, 15.7471, "Bihać" },
                    { 11, 44.160800000000002, 19.1021, "Zvornik" },
                    { 12, 43.200899999999997, 17.684699999999999, "Široki Brijeg" },
                    { 13, 44.360799999999998, 18.805299999999999, "Lukavac" },
                    { 14, 44.541200000000003, 17.365400000000001, "Gradiška" },
                    { 15, 43.337800000000001, 17.8139, "Stolac" },
                    { 16, 44.4664, 19.1736, "Bijeljina" },
                    { 17, 43.828400000000002, 17.404299999999999, "Livno" },
                    { 18, 43.769799999999996, 18.0578, "Konjic" },
                    { 19, 44.124899999999997, 18.123200000000001, "Visoko" },
                    { 20, 44.775199999999998, 17.192399999999999, "Doboj" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "DatumKreiranja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 480, DateTimeKind.Local).AddTicks(6350), "test@gmail.com", "Test", "test", "KaiUaS4zfaZiZnbuv7TN0r5OfeM=", "AglQFeC8HyIM/UV2yFOa0w==", "Korisnik", null },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 480, DateTimeKind.Local).AddTicks(6450), "admin@gmail.com", "Admin", "admin", "KaiUaS4zfaZiZnbuv7TN0r5OfeM=", "AglQFeC8HyIM/UV2yFOa0w==", "Korisnik", null }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Korisnik" },
                    { 2, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "DatumIzmjene", "DatumKreiranja", "KorisnikId", "Odgovor", "Pitanje" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4368), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4376), 1, "Lozinku možete promijeniti u postavkama profila pod opcijom 'Uredi profil'.", "Kako mogu promijeniti svoju lozinku?" },
                    { 3, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4386), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4391), 1, "Nakon završene vožnje, možete ostaviti ocjenu i komentar u sekciji 'Vožnje u kojima ste (bili) putnici'.", "Kako mogu ocijeniti vozača ili saputnika?" },
                    { 4, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4399), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4406), 1, "Kliknite na (+) ikonicu, 'Dodaj vožnju', unesite detalje i objavite vožnju.", "Kako mogu dodati novu vožnju?" },
                    { 5, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4413), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4419), 1, "Da, možete poslati poruku vozaču putem chat opcije na platformi.", "Da li mogu kontaktirati vozača prije vožnje?" },
                    { 6, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4427), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4432), 1, "Možete prijaviti problem putem opcije 'Žalbe' u sekciji profila .", "Šta ako vozač ne dođe na dogovorenu lokaciju?" }
                });

            migrationBuilder.InsertData(
                table: "KorisniciDostignuca",
                columns: new[] { "Id", "DatumKreiranja", "DostignuceId", "KorisnikId" },
                values: new object[] { 1, new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4189), 1, 2 });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "Id", "DatumIzmjene", "KorisnikId", "UlogaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 481, DateTimeKind.Local).AddTicks(6380), 1, 1 },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 481, DateTimeKind.Local).AddTicks(6433), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Kuponi",
                columns: new[] { "Id", "BrojIskoristivosti", "DatumIzmjene", "DatumPocetka", "Kod", "KorisnikId", "Naziv", "Popust", "StateMachine" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1614), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1620), "TESTNI-KOD", 1, "Testni kod", 0.10000000000000001, "draft" },
                    { 2, 10, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1629), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1635), "WELCOME", 1, "Popust dobrodošlice", 0.5, "active" }
                });

            migrationBuilder.InsertData(
                table: "Obavjestenja",
                columns: new[] { "Id", "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka", "KorisnikId", "Naslov", "Opis", "Podnaslov", "StateMachine" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1905), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1912), new DateTime(2025, 3, 1, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1918), 2, "Ažuriranje pravila privatnosti", "Ažurirali smo naša pravila privatnosti kako bi ti pružili veću transparentnost i kontrolu nad tvojim podacima. Pregledaj nove postavke privatnosti u aplikaciji i prilagodi ih svojim potrebama.", "Više kontrole nad tvojim podacima", "active" },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1933), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1939), new DateTime(2025, 2, 27, 12, 0, 42, 485, DateTimeKind.Local).AddTicks(1945), 2, "Stigli su novi alati za bolje iskustvo!", "RideWithMe je bogatiji za nove funkcionalnosti! Sada možeš lakše planirati putovanja, pratiti svoje vožnje i komunicirati s vozačima direktno iz aplikacije. Ažuriraj aplikaciju i isprobaj nove mogućnosti!", "Otkrij nove funkcije aplikacije", "active" },
                    { 3, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1954), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1960), new DateTime(2025, 2, 27, 15, 0, 42, 485, DateTimeKind.Local).AddTicks(1965), 2, "Poboljšana korisnička podrška", "Uveli smo nove opcije podrške u aplikaciji, uključujući chat uživo i detaljniji centar za pomoć. Kontaktiraj nas jednostavno putem aplikacije za bilo kakva pitanja ili sugestije!", "Brže rješenje tvojih upita", "active" }
                });

            migrationBuilder.InsertData(
                table: "Reklame",
                columns: new[] { "Id", "DatumIzmjene", "DatumKreiranja", "KorisnikId", "NazivKampanje", "NazivKlijenta", "SadrzajKampanje", "Slika" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(2065), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(2074), 2, "Revolucija u Online Kupovini", "ShopMaster Ltd.", "Iskusite novu eru online kupovine uz nevjerojatne popuste i brzu dostavu! Pridružite se milijunima zadovoljnih kupaca širom svijeta.", new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 255, 219, 0, 67, 0, 10, 7, 7, 9, 7, 6, 10, 9, 8, 9, 11, 11, 10, 12, 15, 25, 16, 15, 14, 14, 15, 30, 22, 23, 18, 25, 36, 32, 38, 37, 35, 32, 35, 34, 40, 45, 57, 48, 40, 42, 54, 43, 34, 35, 50, 68, 50, 54, 59, 61, 64, 64, 64, 38, 48, 70, 75, 69, 62, 74, 57, 63, 64, 61, 255, 219, 0, 67, 1, 11, 11, 11, 15, 13, 15, 29, 16, 16, 29, 61, 41, 35, 41, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 255, 194, 0, 17, 8, 2, 178, 2, 178, 3, 1, 17, 0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 28, 0, 1, 0, 1, 5, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 4, 5, 6, 7, 1, 8, 255, 196, 0, 27, 1, 1, 0, 2, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 255, 218, 0, 12, 3, 1, 0, 2, 16, 3, 16, 0, 0, 0, 236, 192, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 10, 83, 91, 27, 87, 31, 124, 118, 119, 173, 157, 226, 218, 213, 179, 82, 133, 34, 24, 213, 241, 78, 71, 94, 114, 20, 189, 252, 228, 200, 223, 37, 245, 239, 82, 211, 232, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 57, 140, 117, 240, 225, 242, 224, 196, 229, 195, 143, 201, 142, 133, 226, 22, 66, 80, 76, 22, 166, 66, 109, 4, 208, 44, 241, 207, 154, 177, 127, 203, 166, 83, 157, 23, 84, 190, 78, 249, 179, 59, 25, 243, 27, 89, 50, 25, 175, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 26, 174, 214, 134, 35, 54, 173, 189, 233, 76, 132, 204, 38, 97, 51, 4, 192, 132, 205, 57, 152, 38, 18, 130, 97, 54, 167, 40, 45, 103, 54, 167, 160, 216, 56, 120, 242, 60, 170, 212, 165, 234, 214, 247, 185, 51, 108, 29, 60, 219, 23, 74, 224, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 66, 105, 161, 116, 56, 148, 173, 16, 90, 18, 130, 97, 51, 9, 154, 105, 129, 25, 154, 115, 48, 76, 37, 4, 194, 109, 78, 80, 153, 130, 96, 189, 141, 45, 152, 224, 215, 96, 243, 248, 234, 97, 189, 74, 223, 37, 177, 147, 121, 244, 187, 30, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 51, 93, 11, 127, 135, 74, 245, 130, 240, 33, 51, 9, 154, 115, 48, 76, 19, 9, 66, 102, 9, 132, 204, 8, 76, 211, 153, 132, 90, 19, 16, 178, 17, 123, 72, 156, 207, 158, 108, 94, 118, 42, 225, 190, 71, 111, 46, 243, 232, 179, 251, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 25, 166, 137, 191, 196, 163, 122, 193, 120, 16, 148, 19, 9, 152, 74, 156, 204, 22, 132, 76, 45, 49, 166, 122, 216, 115, 231, 177, 206, 90, 147, 115, 19, 74, 88, 172, 149, 214, 118, 105, 132, 203, 142, 206, 27, 79, 148, 101, 248, 147, 146, 216, 205, 188, 250, 92, 254, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 83, 93, 19, 127, 135, 70, 244, 130, 240, 153, 166, 69, 48, 153, 167, 40, 68, 194, 114, 80, 215, 232, 83, 212, 236, 238, 184, 240, 237, 211, 167, 93, 0, 1, 19, 95, 205, 78, 107, 208, 193, 133, 197, 93, 227, 196, 50, 183, 203, 188, 122, 44, 254, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 78, 107, 162, 111, 113, 40, 223, 28, 38, 240, 41, 204, 198, 80, 76, 38, 212, 113, 110, 226, 185, 126, 170, 182, 159, 83, 170, 238, 121, 140, 181, 245, 125, 0, 0, 1, 66, 99, 148, 116, 48, 219, 112, 177, 109, 252, 156, 187, 191, 161, 207, 236, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 152, 209, 55, 184, 116, 47, 72, 77, 160, 83, 76, 19, 11, 94, 207, 79, 179, 131, 227, 251, 75, 157, 93, 142, 187, 213, 241, 185, 108, 154, 160, 0, 0, 0, 81, 152, 228, 243, 131, 104, 243, 243, 186, 247, 179, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 70, 139, 189, 196, 183, 201, 138, 19, 104, 38, 9, 167, 54, 199, 104, 122, 28, 15, 23, 220, 94, 107, 219, 126, 223, 243, 59, 166, 247, 23, 208, 0, 0, 0, 1, 135, 154, 235, 156, 204, 123, 223, 75, 48, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 120, 141, 35, 123, 141, 107, 147, 4, 22, 132, 205, 51, 31, 165, 232, 53, 222, 47, 188, 190, 212, 181, 236, 234, 245, 174, 223, 141, 185, 190, 48, 0, 0, 0, 0, 240, 192, 225, 174, 127, 53, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 195, 78, 221, 227, 216, 100, 214, 132, 169, 205, 173, 245, 250, 122, 167, 15, 232, 87, 124, 253, 154, 213, 166, 195, 187, 199, 233, 29, 111, 55, 100, 95, 0, 81, 45, 139, 242, 5, 129, 34, 252, 162, 90, 2, 224, 164, 95, 130, 204, 184, 42, 22, 165, 82, 208, 240, 191, 36, 90, 145, 47, 11, 18, 248, 137, 104, 84, 36, 87, 41, 150, 229, 224, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 84, 219, 229, 98, 179, 105, 194, 102, 156, 95, 89, 227, 251, 234, 92, 142, 237, 206, 42, 251, 20, 221, 250, 158, 127, 113, 232, 113, 190, 93, 62, 162, 6, 166, 113, 3, 32, 103, 14, 152, 124, 230, 109, 101, 67, 119, 57, 65, 177, 157, 28, 249, 228, 250, 44, 218, 15, 147, 207, 163, 141, 172, 226, 6, 248, 112, 3, 116, 48, 199, 100, 56, 193, 124, 117, 179, 134, 159, 81, 150, 39, 207, 38, 228, 106, 231, 209, 71, 23, 48, 103, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 119, 99, 157, 129, 218, 231, 196, 179, 214, 236, 106, 158, 127, 232, 185, 13, 36, 162, 158, 195, 126, 236, 249, 157, 163, 119, 153, 242, 233, 245, 16, 62, 109, 59, 209, 152, 62, 111, 58, 169, 205, 78, 228, 124, 216, 117, 211, 64, 55, 83, 163, 31, 47, 153, 211, 112, 57, 89, 244, 73, 181, 156, 64, 223, 14, 28, 125, 44, 124, 220, 116, 147, 159, 29, 96, 222, 207, 152, 15, 168, 203, 19, 231, 147, 114, 57, 113, 222, 78, 32, 108, 167, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 62, 93, 61, 103, 115, 149, 9, 190, 185, 201, 246, 86, 220, 31, 87, 95, 30, 25, 68, 73, 27, 159, 95, 206, 237, 253, 14, 87, 203, 167, 212, 64, 249, 196, 238, 6, 120, 249, 168, 235, 135, 8, 47, 14, 150, 100, 13, 76, 232, 134, 210, 124, 202, 111, 70, 152, 108, 71, 78, 54, 179, 136, 27, 225, 192, 13, 196, 221, 14, 142, 107, 135, 38, 51, 38, 148, 125, 42, 98, 78, 46, 108, 165, 225, 197, 142, 226, 105, 39, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 43, 225, 211, 183, 184, 145, 140, 186, 111, 3, 233, 55, 188, 141, 201, 68, 74, 34, 81, 25, 222, 167, 31, 160, 245, 120, 63, 47, 25, 64, 117, 227, 138, 21, 77, 212, 223, 142, 68, 118, 179, 231, 147, 167, 156, 136, 205, 157, 36, 228, 71, 210, 230, 52, 228, 135, 77, 54, 179, 136, 27, 225, 196, 15, 168, 129, 205, 14, 98, 82, 58, 185, 51, 147, 17, 59, 121, 166, 155, 17, 152, 46, 78, 52, 125, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 132, 215, 73, 221, 226, 91, 179, 233, 126, 107, 233, 153, 62, 122, 80, 246, 34, 81, 19, 221, 211, 234, 61, 223, 51, 114, 168, 3, 194, 36, 192, 0, 0, 0, 0, 0, 0, 0, 129, 225, 80, 17, 4, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 134, 173, 181, 203, 194, 90, 250, 159, 152, 250, 78, 75, 74, 190, 214, 178, 136, 144, 201, 143, 57, 233, 252, 214, 252, 213, 0, 0, 0, 0, 13, 68, 21, 10, 68, 204, 201, 138, 43, 152, 82, 244, 191, 61, 49, 100, 75, 98, 185, 158, 51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 49, 57, 117, 117, 28, 184, 117, 111, 47, 244, 92, 134, 156, 202, 49, 202, 30, 196, 74, 99, 3, 234, 57, 29, 111, 63, 39, 51, 74, 0, 0, 0, 1, 225, 160, 131, 92, 47, 140, 81, 213, 142, 56, 11, 147, 166, 26, 145, 138, 61, 47, 10, 69, 161, 215, 11, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 230, 186, 62, 198, 142, 163, 229, 254, 135, 144, 212, 74, 149, 146, 61, 132, 162, 184, 238, 198, 174, 59, 211, 114, 251, 46, 150, 150, 66, 180, 0, 0, 0, 137, 133, 182, 92, 101, 113, 64, 240, 198, 30, 148, 139, 178, 240, 199, 151, 37, 192, 53, 243, 46, 86, 48, 7, 67, 50, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 3, 38, 191, 59, 224, 251, 11, 206, 110, 207, 181, 172, 161, 40, 172, 161, 238, 90, 105, 94, 207, 157, 150, 218, 142, 141, 167, 163, 179, 98, 213, 144, 0, 30, 22, 51, 151, 76, 201, 209, 218, 105, 163, 153, 174, 184, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 142, 113, 201, 236, 218, 241, 187, 18, 138, 74, 18, 71, 181, 74, 107, 137, 237, 107, 235, 190, 171, 5, 229, 114, 231, 49, 235, 237, 120, 117, 50, 244, 195, 94, 43, 78, 102, 194, 115, 96, 173, 183, 131, 203, 185, 156, 199, 165, 208, 176, 114, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195, 107, 108, 232, 254, 99, 210, 33, 56, 143, 98, 37, 17, 234, 37, 146, 186, 119, 172, 210, 143, 87, 53, 101, 167, 19, 56, 138, 149, 153, 197, 189, 90, 81, 23, 145, 135, 166, 107, 112, 239, 99, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 195, 85, 228, 117, 117, 222, 47, 86, 85, 123, 17, 40, 137, 68, 123, 17, 75, 118, 154, 79, 177, 213, 186, 218, 216, 169, 22, 148, 90, 164, 39, 9, 21, 171, 94, 137, 173, 198, 206, 215, 84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 98, 117, 46, 39, 87, 11, 199, 233, 72, 149, 107, 237, 99, 210, 81, 22, 189, 44, 90, 111, 171, 197, 117, 185, 154, 117, 201, 57, 78, 182, 173, 90, 239, 184, 57, 27, 54, 61, 47, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 21, 157, 99, 137, 212, 194, 241, 186, 62, 195, 217, 137, 99, 167, 178, 150, 53, 45, 236, 90, 183, 163, 173, 175, 95, 37, 198, 76, 181, 232, 223, 240, 114, 54, 108, 90, 94, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 67, 7, 203, 222, 215, 188, 255, 0, 67, 204, 89, 101, 21, 246, 34, 82, 149, 34, 89, 107, 105, 181, 91, 110, 246, 61, 199, 167, 207, 204, 87, 7, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 22, 154, 217, 117, 223, 61, 211, 178, 231, 108, 74, 18, 138, 202, 177, 41, 140, 151, 107, 75, 57, 222, 210, 171, 154, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 107, 56, 190, 102, 198, 23, 133, 189, 79, 79, 53, 231, 71, 87, 55, 223, 210, 188, 221, 195, 236, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 41, 52, 48, 94, 231, 103, 26, 94, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 255, 196, 0, 85, 16, 0, 1, 4, 1, 2, 2, 4, 5, 12, 14, 8, 2, 11, 0, 0, 0, 1, 0, 2, 3, 4, 5, 6, 17, 7, 33, 18, 19, 49, 81, 16, 50, 65, 113, 178, 20, 34, 35, 54, 55, 80, 82, 97, 114, 115, 116, 145, 21, 22, 23, 48, 51, 53, 67, 84, 85, 96, 129, 148, 179, 194, 32, 52, 66, 117, 131, 161, 177, 210, 37, 98, 64, 83, 86, 130, 146, 147, 149, 160, 176, 193, 242, 255, 218, 0, 8, 1, 1, 0, 1, 63, 0, 255, 0, 223, 47, 37, 184, 33, 252, 36, 172, 111, 156, 169, 245, 22, 58, 14, 217, 193, 243, 41, 117, 165, 54, 120, 145, 189, 234, 93, 117, 255, 0, 85, 89, 63, 92, 91, 242, 71, 18, 126, 181, 200, 158, 194, 192, 165, 213, 153, 99, 226, 217, 217, 29, 93, 158, 30, 45, 150, 61, 125, 191, 230, 161, 252, 42, 131, 137, 118, 251, 226, 80, 241, 10, 219, 187, 99, 133, 202, 29, 124, 223, 202, 213, 80, 107, 90, 18, 120, 225, 236, 80, 106, 28, 117, 142, 76, 156, 15, 63, 37, 29, 136, 165, 27, 199, 35, 29, 230, 63, 168, 175, 158, 56, 134, 239, 123, 90, 173, 106, 26, 117, 247, 1, 221, 51, 241, 43, 58, 182, 83, 202, 24, 195, 85, 140, 229, 217, 252, 105, 156, 2, 146, 121, 36, 241, 222, 93, 231, 37, 56, 162, 138, 40, 162, 156, 17, 10, 90, 241, 73, 227, 177, 169, 248, 242, 207, 93, 94, 87, 199, 241, 38, 222, 187, 76, 251, 43, 4, 172, 239, 85, 51, 16, 79, 179, 92, 122, 14, 238, 41, 143, 228, 28, 215, 125, 74, 27, 83, 199, 226, 74, 241, 251, 85, 93, 69, 122, 14, 93, 113, 112, 238, 42, 182, 176, 61, 147, 196, 170, 231, 233, 89, 252, 167, 65, 221, 197, 50, 70, 60, 110, 199, 3, 239, 252, 175, 234, 226, 115, 251, 134, 234, 254, 126, 203, 220, 230, 68, 122, 176, 166, 179, 52, 199, 119, 200, 231, 31, 140, 167, 34, 138, 40, 162, 138, 40, 162, 138, 40, 162, 136, 223, 146, 158, 140, 82, 110, 64, 13, 114, 134, 229, 188, 107, 128, 46, 46, 103, 113, 88, 252, 164, 55, 70, 222, 36, 159, 5, 53, 53, 48, 236, 170, 223, 177, 1, 246, 57, 28, 22, 35, 61, 45, 137, 219, 12, 192, 18, 125, 254, 184, 55, 167, 47, 201, 42, 79, 29, 222, 116, 81, 69, 20, 81, 69, 20, 81, 69, 20, 81, 69, 20, 83, 154, 14, 234, 90, 206, 133, 221, 100, 36, 141, 187, 187, 86, 39, 53, 211, 45, 130, 217, 217, 222, 71, 166, 115, 9, 169, 171, 11, 203, 39, 7, 202, 247, 250, 223, 245, 73, 126, 73, 82, 120, 238, 243, 162, 138, 40, 162, 138, 40, 162, 138, 40, 248, 10, 40, 162, 138, 114, 158, 15, 237, 176, 17, 241, 44, 30, 91, 114, 43, 89, 60, 251, 24, 244, 212, 213, 134, 252, 103, 7, 202, 247, 250, 215, 245, 89, 126, 73, 82, 248, 238, 243, 162, 17, 8, 163, 224, 40, 162, 138, 33, 21, 177, 61, 131, 154, 173, 140, 179, 113, 251, 67, 27, 158, 79, 112, 84, 180, 45, 185, 249, 206, 68, 106, 30, 31, 212, 31, 132, 157, 229, 13, 11, 139, 238, 122, 151, 64, 99, 159, 226, 61, 236, 87, 56, 112, 64, 38, 172, 235, 35, 165, 50, 56, 237, 204, 144, 146, 223, 132, 20, 145, 190, 51, 179, 216, 70, 221, 234, 104, 204, 110, 233, 52, 252, 124, 150, 15, 35, 234, 200, 58, 15, 62, 204, 196, 213, 134, 252, 103, 7, 202, 247, 250, 199, 58, 242, 124, 149, 55, 225, 29, 231, 69, 20, 81, 69, 20, 81, 69, 79, 60, 112, 248, 238, 85, 133, 139, 243, 8, 234, 196, 226, 74, 194, 232, 142, 201, 178, 46, 223, 254, 69, 90, 156, 21, 35, 12, 130, 54, 177, 163, 187, 250, 78, 104, 112, 217, 192, 16, 179, 58, 58, 134, 78, 55, 152, 216, 34, 153, 102, 244, 205, 204, 60, 133, 179, 71, 187, 15, 148, 42, 150, 31, 66, 235, 30, 222, 68, 31, 93, 230, 80, 72, 217, 162, 108, 140, 59, 181, 195, 112, 176, 223, 141, 32, 249, 94, 255, 0, 76, 55, 133, 227, 226, 83, 126, 21, 254, 114, 138, 40, 162, 138, 40, 169, 94, 216, 154, 92, 242, 0, 10, 206, 76, 187, 113, 15, 33, 222, 176, 184, 91, 25, 155, 97, 128, 30, 103, 153, 43, 7, 167, 235, 225, 224, 13, 104, 14, 147, 202, 239, 189, 91, 167, 5, 216, 29, 21, 136, 218, 246, 57, 107, 29, 33, 38, 38, 67, 60, 27, 190, 2, 180, 213, 178, 248, 95, 93, 231, 155, 57, 181, 96, 198, 249, 72, 124, 254, 255, 0, 63, 156, 110, 243, 43, 3, 105, 159, 231, 69, 16, 138, 40, 132, 66, 187, 118, 58, 173, 230, 122, 82, 121, 26, 167, 179, 37, 151, 238, 253, 207, 112, 11, 29, 140, 125, 219, 13, 102, 222, 49, 28, 150, 7, 13, 14, 42, 147, 67, 90, 58, 194, 57, 159, 190, 90, 171, 21, 202, 239, 134, 102, 135, 49, 227, 98, 178, 248, 73, 52, 222, 125, 165, 131, 216, 30, 238, 71, 188, 21, 128, 0, 228, 226, 238, 242, 123, 252, 123, 10, 182, 54, 176, 255, 0, 148, 138, 40, 162, 156, 178, 57, 17, 88, 24, 217, 206, 83, 254, 75, 119, 207, 33, 36, 238, 227, 218, 84, 53, 196, 124, 207, 55, 249, 22, 139, 195, 15, 235, 114, 143, 147, 247, 237, 77, 137, 110, 91, 17, 43, 54, 222, 86, 14, 147, 10, 210, 133, 239, 179, 7, 76, 108, 64, 217, 222, 255, 0, 223, 103, 70, 228, 131, 227, 69, 31, 1, 89, 59, 194, 164, 59, 14, 114, 59, 176, 33, 211, 158, 82, 73, 220, 158, 210, 161, 133, 177, 183, 144, 84, 107, 155, 54, 217, 24, 29, 170, 133, 102, 212, 167, 28, 76, 28, 154, 62, 255, 0, 87, 29, 234, 93, 73, 35, 154, 61, 141, 224, 188, 121, 207, 191, 249, 102, 244, 114, 50, 249, 209, 69, 21, 106, 118, 86, 129, 210, 56, 236, 7, 98, 150, 89, 46, 217, 47, 62, 51, 191, 201, 67, 8, 141, 128, 15, 218, 128, 90, 58, 152, 159, 44, 215, 121, 26, 58, 94, 9, 243, 120, 186, 211, 58, 25, 242, 84, 226, 149, 157, 172, 124, 237, 4, 126, 194, 127, 161, 102, 221, 122, 112, 153, 109, 79, 20, 17, 142, 215, 200, 240, 209, 245, 149, 83, 59, 138, 191, 47, 85, 75, 39, 74, 196, 159, 2, 25, 216, 243, 245, 3, 224, 150, 104, 224, 137, 210, 205, 35, 35, 141, 131, 119, 61, 231, 96, 7, 198, 87, 219, 22, 27, 244, 181, 15, 222, 88, 153, 159, 196, 72, 240, 214, 101, 40, 185, 221, 194, 195, 60, 22, 174, 86, 163, 16, 150, 221, 136, 96, 140, 157, 186, 114, 188, 52, 111, 221, 185, 95, 108, 88, 111, 210, 212, 63, 121, 98, 251, 98, 195, 126, 150, 161, 251, 203, 21, 91, 116, 239, 239, 45, 59, 48, 88, 12, 228, 93, 20, 129, 224, 125, 72, 231, 177, 34, 83, 25, 202, 81, 18, 3, 209, 45, 51, 179, 125, 252, 54, 178, 248, 234, 82, 245, 86, 239, 213, 130, 77, 183, 232, 75, 51, 90, 118, 243, 18, 160, 158, 43, 48, 182, 104, 37, 100, 177, 59, 155, 94, 199, 7, 52, 249, 136, 240, 91, 201, 81, 160, 90, 46, 92, 175, 92, 187, 155, 68, 178, 181, 155, 253, 106, 189, 152, 109, 192, 217, 171, 77, 28, 209, 59, 177, 241, 184, 57, 167, 246, 132, 252, 254, 34, 55, 150, 63, 43, 69, 174, 105, 216, 131, 97, 128, 130, 134, 161, 195, 249, 50, 212, 63, 121, 98, 142, 70, 74, 192, 248, 220, 215, 177, 195, 112, 230, 157, 193, 240, 92, 201, 209, 199, 0, 235, 215, 43, 86, 7, 176, 205, 43, 89, 254, 170, 150, 95, 29, 146, 229, 70, 253, 91, 63, 51, 51, 95, 254, 135, 192, 252, 222, 46, 57, 204, 15, 201, 83, 108, 193, 221, 18, 195, 59, 67, 129, 238, 219, 127, 3, 156, 214, 48, 185, 228, 53, 160, 110, 73, 228, 0, 85, 243, 56, 219, 147, 8, 106, 228, 42, 77, 41, 236, 100, 115, 53, 199, 234, 5, 91, 200, 83, 160, 26, 110, 219, 130, 184, 127, 139, 214, 200, 25, 191, 155, 117, 86, 237, 91, 209, 153, 41, 217, 134, 195, 1, 216, 186, 39, 135, 128, 123, 185, 120, 39, 158, 26, 176, 186, 107, 18, 178, 40, 155, 227, 61, 238, 13, 104, 243, 146, 170, 229, 177, 247, 165, 49, 84, 189, 86, 121, 0, 220, 182, 41, 154, 227, 183, 152, 31, 121, 243, 172, 232, 223, 113, 239, 69, 20, 86, 114, 233, 158, 199, 82, 195, 235, 35, 228, 85, 104, 58, 182, 110, 123, 74, 1, 108, 180, 44, 0, 50, 89, 60, 28, 78, 247, 71, 204, 252, 240, 244, 71, 135, 136, 58, 226, 29, 19, 133, 19, 0, 37, 191, 63, 42, 208, 255, 0, 171, 143, 196, 22, 59, 9, 170, 248, 163, 147, 150, 209, 144, 207, 208, 228, 249, 231, 126, 209, 68, 178, 220, 23, 212, 248, 138, 134, 220, 6, 173, 222, 135, 50, 202, 175, 61, 53, 194, 254, 40, 219, 101, 248, 112, 121, 249, 204, 208, 204, 67, 32, 158, 95, 30, 55, 119, 57, 113, 7, 218, 6, 115, 232, 143, 90, 67, 72, 220, 214, 153, 105, 104, 80, 154, 8, 101, 142, 3, 57, 51, 146, 6, 192, 129, 228, 5, 92, 224, 94, 165, 130, 171, 230, 138, 124, 116, 229, 157, 145, 49, 239, 220, 253, 109, 92, 39, 215, 119, 176, 249, 248, 48, 57, 41, 94, 250, 22, 95, 212, 176, 75, 219, 4, 139, 142, 190, 209, 32, 250, 115, 61, 7, 173, 29, 195, 172, 158, 182, 169, 102, 122, 22, 105, 194, 32, 120, 97, 19, 151, 15, 244, 5, 125, 193, 53, 15, 233, 12, 87, 215, 39, 251, 23, 12, 180, 85, 237, 21, 139, 187, 90, 252, 240, 76, 249, 230, 15, 6, 5, 168, 125, 178, 229, 62, 151, 47, 166, 87, 12, 53, 95, 219, 78, 145, 133, 243, 191, 123, 213, 54, 130, 199, 255, 0, 78, 89, 11, 240, 98, 241, 214, 46, 219, 120, 100, 21, 227, 50, 72, 239, 136, 45, 73, 157, 159, 82, 103, 238, 101, 44, 248, 243, 191, 112, 223, 128, 222, 198, 183, 246, 5, 195, 15, 115, 140, 55, 204, 159, 76, 248, 56, 255, 0, 248, 207, 11, 243, 50, 174, 17, 123, 152, 98, 63, 198, 254, 51, 213, 218, 18, 101, 117, 212, 244, 32, 44, 108, 182, 242, 78, 129, 133, 253, 128, 186, 93, 130, 60, 5, 212, 94, 75, 248, 175, 174, 79, 246, 45, 51, 169, 179, 60, 52, 213, 47, 163, 123, 166, 32, 100, 189, 11, 149, 15, 164, 213, 196, 157, 102, 116, 182, 146, 22, 241, 228, 27, 87, 8, 142, 179, 255, 0, 204, 189, 105, 157, 15, 159, 226, 44, 182, 114, 2, 208, 216, 63, 105, 45, 91, 121, 37, 239, 89, 110, 15, 106, 172, 24, 245, 85, 49, 21, 208, 207, 45, 55, 158, 154, 225, 119, 217, 199, 232, 232, 103, 207, 217, 150, 105, 165, 36, 194, 38, 241, 217, 26, 212, 126, 234, 183, 255, 0, 189, 143, 241, 60, 25, 191, 196, 57, 15, 163, 73, 232, 149, 193, 191, 116, 154, 31, 34, 95, 64, 174, 63, 254, 3, 5, 231, 159, 249, 23, 7, 53, 95, 216, 29, 83, 234, 9, 223, 181, 60, 150, 209, 249, 165, 254, 199, 131, 142, 154, 175, 156, 26, 110, 171, 251, 167, 183, 252, 140, 92, 9, 246, 247, 63, 208, 95, 233, 179, 222, 125, 71, 30, 211, 49, 253, 225, 20, 86, 66, 200, 169, 69, 242, 30, 210, 54, 10, 180, 102, 121, 75, 221, 207, 189, 0, 128, 91, 45, 17, 253, 74, 95, 7, 19, 189, 209, 243, 63, 60, 61, 17, 225, 227, 30, 82, 75, 252, 66, 183, 15, 108, 84, 216, 200, 99, 90, 79, 11, 14, 3, 75, 208, 199, 192, 192, 58, 168, 71, 79, 227, 121, 230, 227, 224, 227, 22, 26, 44, 46, 189, 123, 234, 128, 198, 93, 136, 90, 243, 60, 146, 10, 201, 228, 223, 153, 224, 140, 247, 230, 231, 44, 216, 189, 223, 242, 182, 230, 184, 27, 106, 10, 154, 210, 227, 231, 153, 144, 131, 65, 252, 223, 243, 145, 171, 90, 147, 13, 78, 179, 231, 159, 41, 73, 145, 48, 110, 73, 153, 170, 134, 250, 151, 137, 241, 203, 65, 132, 11, 185, 67, 59, 7, 115, 12, 157, 63, 242, 11, 142, 190, 209, 32, 250, 115, 61, 7, 174, 25, 241, 26, 134, 137, 161, 118, 11, 213, 45, 78, 103, 148, 60, 24, 87, 221, 243, 7, 250, 51, 37, 245, 49, 97, 178, 145, 102, 176, 213, 50, 80, 49, 236, 138, 212, 77, 149, 173, 127, 104, 5, 75, 64, 101, 184, 134, 250, 15, 121, 99, 109, 229, 76, 5, 221, 193, 210, 236, 180, 22, 102, 125, 1, 175, 223, 71, 39, 235, 33, 124, 134, 165, 177, 232, 189, 113, 207, 86, 116, 32, 131, 78, 85, 127, 57, 118, 154, 215, 242, 53, 103, 52, 244, 216, 42, 56, 153, 44, 242, 154, 253, 111, 84, 244, 62, 3, 75, 136, 106, 225, 135, 185, 198, 27, 230, 79, 166, 124, 28, 127, 252, 103, 133, 249, 153, 87, 8, 189, 204, 49, 31, 227, 127, 25, 234, 139, 196, 92, 88, 129, 239, 32, 48, 102, 219, 252, 116, 115, 152, 182, 130, 78, 74, 144, 3, 190, 118, 174, 37, 229, 235, 106, 45, 125, 114, 124, 103, 179, 67, 235, 33, 99, 217, 249, 82, 2, 226, 134, 149, 191, 63, 14, 48, 194, 6, 25, 167, 196, 177, 130, 118, 14, 238, 128, 4, 173, 5, 196, 203, 154, 34, 25, 106, 122, 149, 151, 40, 202, 254, 180, 199, 226, 56, 57, 97, 120, 207, 166, 50, 164, 50, 204, 179, 99, 165, 238, 159, 196, 250, 194, 134, 104, 236, 66, 201, 96, 145, 146, 68, 241, 187, 94, 194, 8, 112, 239, 5, 106, 63, 117, 91, 255, 0, 222, 199, 248, 158, 12, 223, 226, 28, 135, 209, 164, 244, 74, 224, 223, 186, 77, 15, 145, 47, 160, 87, 31, 255, 0, 1, 130, 243, 207, 252, 138, 206, 2, 122, 218, 91, 31, 159, 136, 147, 4, 243, 62, 7, 159, 129, 35, 79, 47, 172, 45, 55, 196, 58, 214, 248, 106, 252, 245, 247, 239, 61, 24, 203, 44, 142, 249, 71, 251, 149, 58, 23, 181, 157, 236, 230, 94, 211, 249, 87, 130, 91, 182, 36, 248, 246, 61, 22, 174, 4, 251, 123, 159, 232, 47, 244, 217, 239, 62, 162, 143, 165, 85, 142, 238, 40, 162, 22, 164, 159, 119, 199, 0, 243, 149, 82, 46, 174, 17, 222, 121, 160, 16, 11, 101, 162, 39, 229, 44, 94, 14, 39, 123, 163, 230, 126, 120, 122, 35, 195, 198, 124, 68, 184, 237, 123, 61, 175, 200, 223, 99, 38, 103, 162, 86, 138, 207, 193, 169, 52, 165, 27, 208, 188, 23, 152, 131, 38, 31, 2, 64, 54, 112, 240, 113, 99, 59, 30, 163, 215, 146, 138, 62, 205, 21, 86, 10, 145, 150, 127, 108, 133, 151, 197, 191, 11, 193, 89, 241, 242, 120, 240, 98, 246, 127, 202, 219, 154, 210, 90, 74, 246, 178, 202, 75, 67, 27, 36, 17, 205, 28, 38, 114, 103, 36, 13, 129, 3, 200, 10, 213, 252, 61, 204, 104, 184, 160, 155, 36, 96, 150, 25, 201, 2, 72, 9, 32, 30, 227, 184, 11, 129, 152, 172, 25, 197, 79, 147, 131, 119, 230, 24, 76, 83, 244, 255, 0, 36, 60, 157, 5, 199, 95, 104, 144, 125, 57, 158, 131, 215, 7, 244, 102, 11, 83, 226, 178, 51, 102, 104, 11, 47, 134, 96, 24, 76, 175, 98, 251, 146, 232, 207, 208, 163, 247, 137, 191, 220, 168, 81, 175, 140, 161, 5, 42, 113, 245, 85, 224, 96, 142, 54, 110, 78, 205, 29, 131, 114, 177, 190, 235, 149, 127, 191, 25, 252, 117, 199, 77, 41, 206, 13, 73, 85, 157, 208, 91, 254, 71, 173, 7, 128, 179, 174, 181, 172, 34, 251, 223, 60, 17, 109, 45, 183, 191, 202, 198, 242, 13, 92, 124, 246, 205, 140, 250, 31, 243, 149, 195, 15, 115, 140, 55, 204, 159, 76, 248, 56, 255, 0, 248, 207, 11, 243, 50, 174, 17, 123, 152, 98, 63, 198, 254, 51, 213, 234, 18, 229, 117, 205, 154, 16, 22, 9, 173, 100, 93, 3, 11, 251, 1, 116, 155, 13, 215, 220, 27, 83, 126, 121, 137, 255, 0, 206, 147, 253, 139, 66, 240, 118, 13, 57, 125, 153, 60, 196, 236, 185, 114, 46, 112, 177, 158, 36, 101, 79, 106, 10, 129, 134, 204, 209, 196, 36, 120, 141, 133, 238, 13, 233, 56, 246, 1, 191, 149, 103, 120, 109, 166, 115, 229, 242, 218, 198, 178, 41, 207, 108, 208, 123, 27, 150, 191, 225, 25, 210, 184, 169, 114, 216, 235, 198, 122, 81, 16, 36, 100, 220, 158, 205, 215, 1, 51, 118, 140, 249, 28, 51, 222, 95, 89, 145, 9, 226, 92, 71, 130, 92, 63, 19, 50, 111, 239, 156, 89, 103, 237, 217, 203, 29, 126, 12, 166, 58, 189, 234, 175, 15, 130, 196, 109, 145, 135, 226, 33, 107, 156, 172, 88, 109, 21, 149, 181, 47, 230, 239, 141, 159, 27, 220, 54, 106, 224, 125, 23, 207, 174, 204, 254, 74, 181, 158, 245, 199, 255, 0, 192, 96, 188, 243, 255, 0, 34, 225, 214, 2, 13, 77, 193, 169, 241, 115, 246, 79, 44, 187, 63, 224, 63, 200, 85, 177, 127, 20, 251, 152, 137, 221, 36, 91, 76, 4, 240, 121, 11, 217, 184, 31, 86, 229, 99, 116, 167, 218, 175, 5, 178, 204, 157, 155, 94, 181, 70, 89, 236, 249, 203, 57, 53, 112, 39, 219, 220, 255, 0, 65, 127, 166, 207, 121, 242, 209, 117, 180, 36, 8, 162, 55, 87, 222, 109, 102, 31, 221, 190, 201, 160, 15, 244, 64, 32, 16, 11, 74, 89, 234, 50, 177, 143, 35, 183, 103, 237, 62, 14, 39, 123, 163, 230, 126, 120, 122, 33, 125, 218, 181, 119, 231, 21, 127, 119, 11, 238, 213, 171, 191, 56, 171, 251, 184, 90, 135, 74, 195, 175, 244, 85, 38, 92, 34, 59, 166, 6, 79, 12, 255, 0, 1, 229, 171, 170, 214, 60, 47, 201, 72, 88, 39, 169, 222, 240, 58, 112, 76, 175, 113, 47, 88, 234, 120, 78, 58, 41, 223, 180, 188, 140, 116, 160, 217, 239, 92, 50, 225, 60, 244, 46, 195, 155, 212, 113, 6, 75, 23, 58, 213, 15, 166, 245, 196, 31, 104, 25, 207, 162, 61, 112, 23, 219, 189, 223, 238, 231, 255, 0, 18, 53, 169, 112, 21, 181, 62, 2, 214, 46, 223, 137, 51, 121, 63, 202, 199, 249, 28, 180, 174, 102, 239, 13, 181, 217, 101, 224, 67, 24, 243, 5, 216, 187, 216, 184, 223, 51, 39, 208, 21, 102, 132, 135, 196, 251, 145, 22, 31, 59, 30, 180, 198, 187, 205, 105, 24, 39, 131, 19, 44, 44, 100, 239, 15, 127, 78, 32, 229, 247, 106, 213, 223, 156, 85, 253, 220, 46, 18, 107, 60, 182, 175, 135, 42, 114, 239, 137, 230, 177, 136, 51, 160, 206, 254, 146, 198, 251, 174, 85, 254, 252, 103, 241, 214, 83, 27, 91, 49, 140, 177, 66, 244, 125, 101, 123, 12, 44, 123, 86, 151, 209, 184, 157, 31, 4, 241, 98, 98, 120, 235, 220, 12, 142, 123, 247, 39, 101, 199, 223, 108, 248, 223, 161, 255, 0, 57, 92, 48, 247, 56, 195, 124, 201, 244, 207, 131, 143, 255, 0, 140, 240, 191, 51, 42, 225, 23, 185, 134, 35, 252, 111, 227, 61, 99, 125, 215, 42, 255, 0, 126, 51, 248, 254, 30, 48, 233, 108, 254, 165, 169, 76, 226, 0, 158, 173, 109, 222, 250, 221, 143, 47, 84, 181, 238, 180, 210, 59, 83, 154, 205, 166, 6, 118, 65, 122, 45, 253, 46, 107, 55, 175, 53, 70, 183, 132, 99, 38, 38, 88, 156, 127, 171, 84, 131, 199, 43, 132, 58, 22, 222, 151, 163, 102, 254, 85, 157, 11, 183, 54, 2, 31, 44, 76, 11, 138, 188, 60, 151, 86, 85, 138, 254, 47, 241, 157, 97, 183, 207, 177, 98, 117, 150, 173, 208, 91, 227, 129, 150, 6, 126, 109, 110, 21, 123, 47, 171, 184, 149, 114, 40, 8, 158, 246, 199, 214, 67, 11, 54, 137, 139, 135, 26, 28, 104, 172, 25, 100, 228, 73, 126, 209, 15, 157, 255, 0, 232, 192, 184, 255, 0, 248, 12, 23, 158, 127, 228, 92, 19, 247, 60, 139, 233, 50, 172, 143, 14, 240, 25, 77, 74, 204, 237, 170, 207, 55, 3, 152, 254, 230, 60, 183, 176, 144, 181, 223, 180, 60, 239, 208, 101, 244, 87, 2, 125, 189, 207, 244, 23, 250, 108, 247, 158, 86, 116, 226, 123, 123, 193, 10, 211, 12, 86, 30, 222, 226, 158, 238, 131, 11, 187, 185, 170, 123, 201, 117, 239, 61, 229, 0, 128, 91, 32, 19, 102, 125, 97, 214, 198, 118, 115, 15, 72, 121, 214, 58, 219, 47, 80, 134, 196, 103, 118, 189, 160, 255, 0, 73, 145, 178, 61, 250, 182, 53, 187, 247, 13, 191, 232, 210, 70, 201, 89, 209, 145, 141, 123, 123, 156, 55, 10, 40, 34, 128, 17, 12, 76, 140, 119, 49, 160, 120, 94, 198, 72, 221, 158, 214, 184, 119, 17, 186, 107, 67, 6, 205, 0, 1, 228, 30, 247, 103, 96, 234, 174, 244, 252, 142, 87, 14, 212, 230, 249, 5, 98, 219, 185, 145, 200, 4, 2, 1, 0, 156, 208, 246, 16, 124, 163, 101, 195, 236, 231, 57, 113, 83, 187, 155, 14, 241, 253, 251, 86, 235, 139, 90, 90, 119, 237, 128, 187, 114, 156, 81, 7, 201, 109, 156, 163, 106, 211, 26, 214, 254, 163, 181, 8, 126, 154, 189, 70, 156, 209, 117, 162, 220, 222, 33, 11, 75, 107, 234, 58, 179, 53, 147, 161, 70, 23, 129, 75, 196, 155, 201, 56, 220, 141, 194, 204, 241, 10, 10, 57, 89, 113, 120, 124, 101, 220, 213, 248, 57, 206, 202, 131, 148, 63, 41, 203, 19, 175, 233, 101, 116, 214, 83, 42, 106, 89, 170, 252, 88, 127, 170, 107, 79, 201, 225, 205, 11, 78, 102, 62, 207, 224, 41, 229, 58, 131, 92, 90, 103, 76, 68, 227, 185, 1, 51, 92, 214, 126, 87, 80, 212, 21, 95, 213, 96, 161, 235, 102, 159, 200, 254, 91, 236, 180, 150, 177, 165, 171, 52, 241, 202, 192, 12, 2, 34, 225, 52, 79, 59, 152, 200, 71, 138, 48, 13, 19, 6, 162, 56, 185, 246, 179, 111, 212, 176, 65, 211, 230, 245, 134, 214, 57, 124, 158, 90, 10, 147, 233, 28, 149, 24, 164, 237, 158, 111, 17, 139, 87, 106, 168, 244, 165, 42, 147, 26, 207, 181, 45, 187, 45, 173, 28, 76, 59, 18, 74, 214, 26, 170, 45, 33, 134, 101, 233, 107, 62, 201, 146, 118, 192, 200, 152, 118, 46, 113, 89, 253, 127, 46, 39, 82, 125, 132, 161, 131, 183, 148, 182, 32, 19, 188, 64, 124, 69, 46, 191, 158, 142, 152, 200, 230, 114, 216, 11, 148, 5, 66, 192, 200, 102, 127, 57, 203, 138, 171, 197, 2, 50, 116, 42, 230, 116, 238, 71, 23, 21, 247, 136, 225, 158, 110, 108, 46, 43, 49, 196, 57, 168, 106, 107, 88, 76, 110, 2, 238, 82, 122, 172, 99, 229, 48, 30, 245, 166, 243, 55, 51, 116, 165, 158, 246, 30, 206, 41, 204, 147, 160, 34, 159, 198, 112, 239, 247, 199, 61, 91, 173, 170, 30, 7, 54, 171, 163, 122, 115, 124, 130, 177, 35, 214, 73, 231, 64, 32, 16, 8, 4, 2, 200, 201, 54, 43, 49, 21, 200, 9, 105, 39, 112, 180, 214, 122, 28, 238, 53, 146, 176, 251, 40, 27, 72, 223, 190, 23, 6, 141, 202, 227, 21, 183, 253, 165, 50, 132, 28, 229, 201, 219, 138, 176, 92, 67, 203, 75, 134, 211, 180, 244, 206, 13, 146, 203, 145, 191, 24, 175, 19, 33, 230, 246, 66, 209, 179, 202, 211, 115, 156, 111, 18, 5, 90, 88, 155, 120, 222, 158, 12, 195, 4, 22, 128, 15, 123, 153, 204, 57, 112, 195, 39, 90, 167, 14, 46, 207, 86, 229, 8, 179, 29, 116, 175, 157, 247, 159, 176, 15, 242, 23, 172, 206, 179, 200, 231, 120, 77, 149, 158, 219, 41, 3, 107, 32, 40, 192, 106, 49, 236, 18, 246, 60, 187, 215, 44, 71, 168, 177, 216, 138, 116, 34, 179, 1, 21, 96, 100, 67, 103, 142, 198, 181, 50, 249, 28, 42, 213, 89, 190, 201, 243, 217, 35, 27, 62, 73, 119, 255, 0, 181, 159, 169, 111, 133, 125, 124, 53, 65, 56, 236, 222, 47, 168, 127, 252, 150, 3, 54, 37, 101, 177, 146, 154, 122, 3, 76, 86, 180, 202, 83, 136, 141, 231, 202, 240, 8, 137, 254, 58, 210, 212, 242, 245, 77, 147, 150, 212, 177, 230, 183, 13, 232, 6, 86, 142, 46, 171, 191, 197, 92, 70, 130, 222, 127, 95, 233, 156, 21, 11, 66, 172, 241, 7, 221, 235, 139, 3, 195, 59, 142, 222, 118, 44, 214, 35, 60, 117, 246, 151, 195, 102, 243, 255, 0, 101, 216, 249, 253, 86, 89, 234, 86, 68, 24, 35, 88, 216, 50, 121, 254, 33, 106, 140, 182, 43, 80, 195, 135, 49, 78, 41, 135, 190, 6, 75, 214, 181, 191, 43, 228, 46, 38, 11, 243, 233, 205, 57, 128, 55, 89, 147, 200, 223, 185, 206, 125, 131, 27, 55, 69, 80, 126, 95, 90, 241, 10, 44, 70, 171, 245, 29, 51, 129, 34, 224, 171, 84, 29, 167, 43, 75, 214, 203, 103, 179, 250, 147, 59, 137, 212, 208, 97, 196, 247, 157, 15, 175, 129, 147, 25, 24, 206, 207, 25, 99, 89, 52, 88, 218, 204, 179, 108, 92, 156, 70, 209, 37, 128, 208, 209, 43, 182, 230, 237, 135, 33, 191, 190, 51, 196, 38, 129, 236, 62, 80, 175, 215, 49, 153, 161, 61, 187, 16, 177, 77, 216, 76, 222, 231, 32, 16, 8, 4, 2, 1, 103, 106, 122, 162, 129, 115, 71, 174, 143, 154, 210, 217, 217, 176, 215, 195, 216, 227, 208, 61, 161, 98, 51, 21, 242, 245, 132, 144, 184, 116, 188, 173, 242, 143, 189, 57, 205, 99, 75, 156, 64, 1, 125, 145, 251, 41, 144, 21, 171, 254, 6, 51, 187, 207, 122, 205, 97, 51, 57, 123, 245, 102, 159, 23, 132, 156, 80, 159, 174, 166, 100, 187, 59, 11, 123, 137, 13, 102, 200, 97, 115, 195, 62, 115, 127, 98, 176, 39, 34, 98, 234, 122, 227, 126, 193, 217, 157, 192, 22, 108, 20, 248, 92, 245, 172, 245, 108, 204, 216, 172, 9, 200, 213, 97, 142, 25, 189, 95, 99, 147, 79, 196, 25, 178, 159, 64, 79, 111, 44, 114, 83, 233, 173, 52, 251, 95, 77, 159, 160, 79, 121, 103, 67, 162, 166, 208, 118, 231, 194, 193, 136, 151, 3, 129, 52, 32, 144, 203, 28, 67, 37, 107, 147, 207, 198, 26, 177, 220, 58, 155, 19, 107, 213, 52, 112, 24, 24, 166, 232, 61, 159, 140, 237, 158, 78, 4, 30, 214, 163, 163, 178, 39, 13, 79, 20, 112, 120, 19, 70, 148, 221, 124, 16, 250, 190, 215, 39, 255, 0, 224, 89, 204, 38, 119, 82, 80, 20, 178, 248, 156, 5, 152, 3, 195, 192, 55, 103, 28, 252, 225, 139, 57, 161, 238, 234, 59, 140, 181, 150, 193, 96, 103, 153, 145, 136, 129, 251, 37, 105, 155, 48, 124, 77, 96, 88, 13, 47, 150, 210, 162, 113, 133, 195, 96, 107, 117, 251, 117, 191, 241, 11, 47, 223, 111, 148, 194, 134, 27, 61, 246, 124, 230, 254, 197, 96, 78, 71, 169, 234, 58, 227, 126, 199, 137, 230, 232, 108, 159, 134, 207, 75, 159, 139, 52, 252, 86, 4, 228, 98, 136, 192, 201, 141, 235, 28, 153, 230, 232, 108, 165, 225, 96, 154, 87, 202, 253, 55, 130, 47, 127, 126, 86, 226, 139, 74, 229, 96, 159, 25, 43, 48, 184, 16, 252, 83, 11, 41, 255, 0, 196, 44, 237, 16, 63, 247, 19, 240, 25, 199, 231, 198, 108, 226, 112, 67, 36, 34, 234, 68, 226, 253, 145, 235, 60, 193, 155, 47, 185, 68, 95, 246, 103, 3, 255, 0, 170, 220, 88, 26, 214, 105, 98, 32, 171, 110, 10, 176, 24, 26, 34, 142, 58, 178, 57, 236, 107, 0, 1, 188, 220, 1, 247, 203, 61, 71, 119, 137, 219, 229, 228, 85, 88, 122, 155, 182, 226, 248, 47, 64, 32, 16, 8, 4, 2, 232, 135, 53, 193, 195, 145, 28, 213, 250, 174, 161, 146, 115, 60, 155, 244, 129, 239, 11, 21, 150, 177, 141, 156, 77, 89, 229, 96, 181, 165, 92, 136, 17, 217, 246, 41, 83, 30, 215, 183, 118, 56, 17, 222, 63, 167, 127, 49, 83, 30, 194, 102, 148, 111, 228, 104, 89, 93, 75, 62, 77, 230, 40, 119, 100, 69, 105, 172, 119, 168, 168, 7, 191, 240, 146, 115, 63, 168, 115, 68, 217, 162, 115, 31, 216, 86, 99, 26, 250, 57, 185, 78, 220, 164, 106, 1, 0, 128, 64, 32, 22, 203, 80, 227, 189, 87, 80, 74, 193, 236, 145, 42, 114, 244, 154, 88, 79, 54, 166, 18, 8, 32, 236, 86, 47, 83, 223, 199, 114, 100, 164, 179, 184, 170, 26, 250, 25, 57, 90, 143, 162, 161, 213, 120, 201, 191, 47, 178, 26, 135, 27, 249, 212, 106, 77, 77, 140, 143, 182, 192, 42, 214, 182, 165, 24, 61, 64, 47, 42, 246, 177, 187, 103, 118, 197, 180, 77, 82, 79, 36, 210, 116, 164, 121, 113, 62, 82, 180, 190, 32, 222, 182, 37, 120, 246, 54, 115, 41, 160, 53, 160, 14, 193, 250, 137, 168, 49, 98, 237, 94, 177, 131, 217, 24, 157, 31, 69, 229, 168, 32, 16, 8, 5, 178, 217, 102, 241, 199, 27, 123, 174, 140, 123, 12, 135, 145, 238, 42, 39, 137, 24, 8, 242, 166, 160, 129, 33, 53, 231, 188, 160, 79, 194, 40, 32, 177, 244, 164, 189, 105, 145, 70, 59, 74, 197, 99, 217, 142, 166, 216, 155, 219, 229, 63, 168, 187, 110, 181, 6, 23, 160, 243, 102, 22, 238, 223, 40, 65, 187, 32, 16, 8, 5, 178, 1, 91, 167, 29, 218, 206, 130, 81, 201, 223, 228, 84, 213, 230, 196, 92, 116, 51, 131, 208, 242, 59, 226, 77, 59, 128, 71, 97, 27, 130, 130, 8, 32, 130, 175, 3, 231, 148, 49, 131, 114, 86, 156, 193, 140, 117, 113, 36, 163, 121, 93, 250, 142, 246, 54, 70, 22, 184, 110, 10, 204, 225, 13, 87, 25, 97, 27, 198, 131, 80, 8, 15, 0, 8, 5, 146, 198, 67, 147, 172, 98, 155, 145, 30, 35, 187, 138, 154, 11, 24, 139, 6, 11, 32, 245, 100, 242, 114, 107, 131, 134, 224, 242, 65, 4, 20, 49, 62, 121, 3, 99, 27, 238, 180, 206, 157, 21, 24, 39, 178, 223, 94, 123, 7, 234, 76, 145, 182, 86, 22, 188, 2, 10, 203, 96, 157, 1, 50, 192, 55, 98, 232, 144, 128, 91, 32, 16, 8, 5, 106, 140, 55, 97, 49, 206, 192, 230, 149, 115, 79, 92, 198, 60, 201, 79, 217, 160, 248, 30, 80, 162, 178, 199, 158, 139, 183, 99, 254, 11, 185, 20, 21, 120, 31, 98, 81, 28, 109, 36, 149, 167, 52, 200, 166, 193, 61, 176, 12, 190, 64, 135, 234, 81, 0, 141, 143, 48, 178, 120, 33, 46, 242, 65, 203, 189, 170, 72, 95, 19, 203, 30, 8, 43, 100, 2, 1, 0, 128, 91, 43, 120, 138, 119, 71, 179, 192, 222, 151, 120, 228, 85, 109, 24, 102, 151, 104, 44, 188, 51, 185, 203, 13, 167, 43, 226, 217, 185, 1, 242, 247, 254, 167, 92, 198, 195, 113, 190, 184, 0, 238, 245, 115, 19, 53, 82, 78, 219, 183, 189, 108, 128, 64, 32, 19, 88, 231, 114, 1, 81, 196, 62, 94, 114, 250, 214, 168, 43, 199, 93, 157, 22, 15, 213, 7, 52, 60, 16, 225, 184, 42, 230, 18, 57, 55, 116, 60, 156, 167, 167, 45, 119, 17, 35, 8, 248, 208, 105, 85, 177, 179, 88, 62, 46, 195, 188, 170, 152, 216, 171, 13, 200, 233, 59, 245, 81, 241, 178, 65, 179, 218, 8, 76, 199, 192, 199, 244, 131, 2, 0, 1, 176, 31, 252, 130, 255, 0, 255, 196, 0, 44, 17, 0, 2, 1, 3, 2, 5, 4, 1, 5, 1, 1, 0, 0, 0, 0, 0, 1, 2, 0, 3, 4, 17, 33, 49, 5, 16, 18, 32, 96, 34, 48, 65, 80, 50, 19, 20, 35, 51, 64, 160, 176, 255, 218, 0, 8, 1, 2, 1, 1, 63, 0, 255, 0, 185, 112, 166, 10, 108, 96, 162, 96, 183, 48, 91, 193, 109, 13, 180, 54, 240, 219, 183, 196, 106, 78, 177, 153, 150, 126, 190, 55, 159, 185, 88, 43, 33, 129, 129, 240, 92, 24, 180, 201, 139, 66, 10, 34, 4, 2, 5, 19, 3, 158, 103, 87, 62, 144, 97, 183, 67, 42, 216, 6, 218, 87, 176, 101, 143, 73, 214, 7, 101, 139, 118, 203, 22, 248, 124, 196, 185, 70, 129, 129, 240, 10, 116, 132, 8, 4, 199, 189, 212, 68, 32, 48, 149, 172, 195, 203, 171, 50, 155, 66, 152, 58, 195, 9, 34, 37, 195, 39, 204, 182, 188, 235, 61, 39, 239, 151, 120, 155, 127, 128, 17, 51, 55, 141, 73, 95, 67, 47, 184, 113, 221, 99, 169, 67, 131, 200, 203, 49, 252, 162, 15, 189, 27, 202, 123, 127, 131, 78, 66, 24, 125, 99, 6, 95, 216, 252, 137, 81, 58, 76, 214, 89, 255, 0, 96, 131, 239, 70, 242, 158, 222, 225, 117, 88, 215, 3, 226, 126, 226, 27, 134, 159, 174, 208, 92, 52, 91, 163, 22, 186, 176, 138, 115, 42, 83, 12, 39, 17, 181, 40, 114, 35, 28, 75, 31, 236, 16, 125, 232, 222, 38, 222, 192, 133, 192, 143, 114, 171, 30, 236, 183, 227, 1, 99, 191, 176, 149, 217, 101, 42, 225, 229, 229, 1, 85, 37, 205, 18, 143, 45, 52, 170, 32, 251, 209, 41, 237, 219, 142, 111, 84, 40, 149, 238, 226, 150, 170, 98, 32, 81, 237, 6, 35, 105, 66, 183, 80, 233, 51, 139, 91, 224, 228, 75, 33, 252, 130, 15, 189, 18, 158, 221, 162, 28, 1, 42, 220, 5, 18, 173, 209, 138, 77, 70, 148, 211, 164, 123, 128, 144, 114, 37, 208, 21, 105, 75, 53, 197, 95, 191, 167, 183, 105, 32, 9, 94, 227, 18, 173, 98, 76, 99, 153, 107, 75, 26, 251, 223, 24, 130, 159, 77, 111, 191, 167, 183, 49, 9, 196, 173, 91, 2, 86, 171, 147, 25, 165, 21, 235, 104, 139, 129, 143, 124, 166, 95, 63, 127, 75, 110, 202, 181, 49, 43, 214, 201, 133, 137, 48, 203, 53, 201, 240, 250, 39, 78, 108, 112, 37, 213, 92, 71, 124, 192, 97, 50, 200, 105, 225, 244, 79, 33, 43, 190, 4, 184, 124, 152, 79, 59, 63, 199, 195, 233, 29, 121, 29, 4, 187, 169, 42, 62, 79, 101, 145, 211, 195, 208, 224, 197, 143, 180, 188, 110, 219, 22, 240, 241, 41, 153, 91, 241, 151, 71, 88, 123, 44, 219, 15, 7, 135, 209, 50, 177, 244, 203, 163, 175, 109, 22, 195, 196, 245, 32, 62, 31, 72, 224, 202, 223, 140, 186, 62, 168, 59, 20, 224, 206, 30, 225, 211, 17, 208, 169, 240, 224, 112, 99, 28, 164, 189, 30, 169, 241, 219, 195, 171, 244, 180, 100, 21, 23, 49, 148, 143, 111, 30, 6, 27, 76, 75, 225, 172, 207, 109, 26, 133, 26, 88, 215, 14, 152, 142, 128, 198, 166, 71, 176, 1, 48, 46, 35, 31, 4, 191, 95, 153, 158, 195, 203, 134, 221, 116, 176, 6, 43, 6, 16, 129, 26, 144, 48, 210, 51, 160, 206, 131, 58, 12, 253, 51, 2, 64, 35, 183, 130, 220, 210, 235, 89, 80, 20, 108, 119, 83, 169, 208, 115, 56, 109, 224, 113, 136, 227, 26, 207, 142, 246, 108, 66, 115, 224, 215, 182, 153, 245, 8, 70, 15, 117, 157, 193, 164, 217, 150, 215, 107, 89, 123, 201, 140, 217, 240, 118, 80, 70, 12, 187, 179, 233, 245, 8, 119, 228, 79, 101, 149, 225, 164, 101, 181, 216, 170, 59, 78, 68, 102, 207, 132, 178, 134, 24, 50, 238, 199, 30, 165, 132, 16, 117, 133, 135, 35, 51, 164, 201, 6, 91, 222, 181, 57, 105, 196, 213, 180, 104, 149, 81, 181, 16, 182, 99, 28, 70, 168, 79, 133, 144, 12, 186, 176, 15, 170, 202, 180, 26, 153, 214, 3, 14, 179, 110, 106, 253, 59, 74, 55, 245, 16, 203, 75, 183, 169, 11, 146, 60, 58, 181, 178, 85, 18, 230, 193, 233, 234, 33, 210, 111, 49, 54, 139, 73, 156, 233, 44, 248, 105, 58, 188, 165, 69, 105, 140, 15, 16, 101, 12, 48, 101, 199, 13, 71, 213, 101, 197, 165, 74, 81, 67, 147, 140, 74, 28, 57, 234, 239, 45, 236, 146, 144, 128, 120, 155, 83, 86, 222, 45, 165, 37, 57, 196, 10, 6, 223, 250, 11, 255, 0, 255, 196, 0, 43, 17, 0, 1, 4, 1, 2, 5, 4, 3, 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 2, 3, 17, 4, 16, 49, 5, 18, 32, 33, 96, 19, 34, 48, 80, 20, 50, 65, 81, 97, 160, 176, 255, 218, 0, 8, 1, 3, 1, 1, 63, 0, 255, 0, 188, 185, 112, 70, 86, 132, 103, 11, 242, 2, 252, 132, 114, 10, 245, 156, 189, 103, 175, 93, 235, 242, 28, 191, 36, 161, 148, 134, 67, 74, 18, 52, 171, 30, 10, 92, 2, 116, 237, 106, 118, 82, 57, 46, 43, 213, 37, 115, 30, 155, 10, 194, 177, 167, 40, 70, 48, 81, 101, 43, 33, 9, 72, 77, 152, 161, 50, 15, 7, 192, 9, 160, 164, 201, 55, 65, 62, 82, 85, 223, 198, 53, 7, 74, 69, 138, 144, 64, 166, 185, 53, 223, 124, 253, 147, 191, 101, 95, 32, 232, 8, 104, 66, 164, 16, 76, 223, 239, 159, 178, 127, 237, 240, 87, 192, 52, 5, 90, 181, 90, 4, 207, 190, 126, 201, 255, 0, 183, 192, 45, 90, 13, 209, 152, 207, 122, 24, 165, 187, 175, 68, 33, 8, 94, 147, 87, 162, 17, 132, 35, 21, 34, 218, 87, 160, 76, 251, 231, 236, 159, 251, 124, 28, 201, 141, 47, 217, 65, 195, 229, 144, 166, 112, 216, 226, 22, 245, 44, 204, 29, 152, 17, 113, 61, 101, 128, 167, 71, 74, 144, 76, 223, 239, 157, 178, 147, 246, 61, 64, 233, 143, 136, 233, 157, 75, 15, 131, 6, 119, 42, 103, 195, 136, 207, 249, 89, 25, 78, 153, 223, 27, 217, 163, 62, 249, 219, 41, 63, 99, 211, 186, 229, 255, 0, 22, 7, 13, 116, 198, 202, 196, 225, 172, 128, 89, 89, 19, 54, 54, 90, 202, 200, 116, 206, 249, 92, 218, 81, 239, 247, 199, 101, 47, 238, 81, 232, 99, 44, 246, 92, 51, 134, 58, 87, 89, 80, 99, 179, 29, 189, 147, 164, 46, 11, 137, 100, 217, 228, 31, 49, 22, 154, 40, 253, 252, 226, 157, 163, 116, 22, 77, 46, 21, 195, 204, 143, 183, 40, 97, 100, 13, 160, 139, 173, 100, 75, 200, 194, 84, 175, 47, 113, 39, 231, 174, 255, 0, 127, 148, 61, 218, 176, 210, 193, 197, 51, 61, 97, 226, 182, 22, 4, 227, 106, 215, 19, 150, 153, 94, 31, 150, 61, 218, 4, 25, 206, 104, 46, 11, 130, 24, 206, 98, 164, 52, 185, 187, 33, 238, 92, 85, 222, 234, 240, 252, 208, 155, 178, 11, 134, 99, 250, 178, 5, 11, 61, 54, 0, 17, 55, 166, 203, 137, 155, 127, 135, 229, 182, 218, 130, 11, 128, 99, 255, 0, 74, 115, 168, 82, 189, 10, 226, 77, 247, 95, 135, 206, 45, 139, 250, 161, 109, 188, 5, 194, 225, 17, 196, 19, 187, 158, 142, 38, 206, 215, 225, 238, 22, 20, 173, 167, 44, 65, 114, 5, 140, 42, 32, 134, 232, 157, 114, 153, 204, 196, 225, 71, 195, 242, 153, 70, 215, 15, 23, 32, 81, 246, 140, 34, 175, 75, 82, 11, 106, 201, 142, 157, 225, 249, 44, 182, 174, 31, 218, 80, 129, 246, 4, 118, 67, 83, 178, 201, 141, 57, 180, 124, 57, 194, 197, 40, 7, 36, 192, 40, 205, 198, 17, 61, 57, 45, 176, 157, 31, 55, 100, 246, 22, 159, 140, 179, 148, 89, 240, 51, 29, 60, 57, 97, 203, 205, 16, 69, 94, 161, 60, 115, 39, 183, 149, 200, 196, 36, 82, 227, 22, 124, 12, 133, 207, 217, 69, 140, 214, 11, 114, 200, 127, 51, 168, 120, 39, 13, 127, 106, 79, 61, 144, 232, 10, 118, 218, 97, 165, 65, 201, 248, 205, 114, 126, 35, 134, 200, 227, 189, 122, 47, 67, 29, 231, 248, 155, 134, 242, 163, 194, 104, 221, 53, 129, 163, 178, 202, 154, 133, 120, 46, 52, 188, 142, 76, 33, 205, 190, 167, 11, 79, 20, 84, 103, 182, 148, 169, 6, 4, 26, 21, 45, 202, 158, 79, 77, 170, 71, 151, 155, 240, 108, 76, 170, 246, 148, 13, 244, 148, 90, 8, 70, 193, 77, 61, 149, 244, 189, 225, 130, 202, 200, 156, 200, 124, 28, 26, 54, 177, 178, 239, 218, 80, 54, 53, 181, 122, 57, 168, 18, 19, 93, 104, 106, 94, 27, 186, 201, 200, 231, 52, 60, 36, 18, 13, 133, 141, 151, 252, 114, 105, 14, 23, 161, 208, 34, 139, 85, 210, 107, 144, 70, 64, 193, 221, 100, 228, 243, 154, 30, 25, 6, 81, 103, 98, 153, 32, 114, 189, 111, 74, 91, 39, 207, 200, 165, 156, 191, 195, 163, 149, 204, 81, 100, 181, 195, 186, 14, 7, 160, 188, 5, 46, 71, 248, 156, 226, 237, 252, 64, 26, 81, 228, 22, 238, 163, 156, 57, 23, 132, 252, 128, 19, 230, 46, 241, 64, 72, 70, 71, 31, 253, 6, 63, 255, 217 } },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(3020), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(3027), 2, "Vaša Sigurnost je Naš Prioritet", "SecurityPro Solutions", "Uz SecurityPro, vaša imovina je uvijek zaštićena. Iskoristite posebne pogodnosti prilikom instalacije naših sigurnosnih sustava.", new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 255, 219, 0, 67, 0, 10, 7, 7, 9, 7, 6, 10, 9, 8, 9, 11, 11, 10, 12, 15, 25, 16, 15, 14, 14, 15, 30, 22, 23, 18, 25, 36, 32, 38, 37, 35, 32, 35, 34, 40, 45, 57, 48, 40, 42, 54, 43, 34, 35, 50, 68, 50, 54, 59, 61, 64, 64, 64, 38, 48, 70, 75, 69, 62, 74, 57, 63, 64, 61, 255, 219, 0, 67, 1, 11, 11, 11, 15, 13, 15, 29, 16, 16, 29, 61, 41, 35, 41, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 61, 255, 194, 0, 17, 8, 2, 178, 2, 178, 3, 1, 17, 0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 28, 0, 1, 0, 1, 5, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 4, 5, 6, 7, 1, 8, 255, 196, 0, 27, 1, 1, 0, 2, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 255, 218, 0, 12, 3, 1, 0, 2, 16, 3, 16, 0, 0, 0, 236, 192, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 10, 83, 91, 27, 87, 31, 124, 118, 119, 173, 157, 226, 218, 213, 179, 82, 133, 34, 24, 213, 241, 78, 71, 94, 114, 20, 189, 252, 228, 200, 223, 37, 245, 239, 82, 211, 232, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 57, 140, 117, 240, 225, 242, 224, 196, 229, 195, 143, 201, 142, 133, 226, 22, 66, 80, 76, 22, 166, 66, 109, 4, 208, 44, 241, 207, 154, 177, 127, 203, 166, 83, 157, 23, 84, 190, 78, 249, 179, 59, 25, 243, 27, 89, 50, 25, 175, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 26, 174, 214, 134, 35, 54, 173, 189, 233, 76, 132, 204, 38, 97, 51, 4, 192, 132, 205, 57, 152, 38, 18, 130, 97, 54, 167, 40, 45, 103, 54, 167, 160, 216, 56, 120, 242, 60, 170, 212, 165, 234, 214, 247, 185, 51, 108, 29, 60, 219, 23, 74, 224, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 66, 105, 161, 116, 56, 148, 173, 16, 90, 18, 130, 97, 51, 9, 154, 105, 129, 25, 154, 115, 48, 76, 37, 4, 194, 109, 78, 80, 153, 130, 96, 189, 141, 45, 152, 224, 215, 96, 243, 248, 234, 97, 189, 74, 223, 37, 177, 147, 121, 244, 187, 30, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 51, 93, 11, 127, 135, 74, 245, 130, 240, 33, 51, 9, 154, 115, 48, 76, 19, 9, 66, 102, 9, 132, 204, 8, 76, 211, 153, 132, 90, 19, 16, 178, 17, 123, 72, 156, 207, 158, 108, 94, 118, 42, 225, 190, 71, 111, 46, 243, 232, 179, 251, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 25, 166, 137, 191, 196, 163, 122, 193, 120, 16, 148, 19, 9, 152, 74, 156, 204, 22, 132, 76, 45, 49, 166, 122, 216, 115, 231, 177, 206, 90, 147, 115, 19, 74, 88, 172, 149, 214, 118, 105, 132, 203, 142, 206, 27, 79, 148, 101, 248, 147, 146, 216, 205, 188, 250, 92, 254, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 83, 93, 19, 127, 135, 70, 244, 130, 240, 153, 166, 69, 48, 153, 167, 40, 68, 194, 114, 80, 215, 232, 83, 212, 236, 238, 184, 240, 237, 211, 167, 93, 0, 1, 19, 95, 205, 78, 107, 208, 193, 133, 197, 93, 227, 196, 50, 183, 203, 188, 122, 44, 254, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 78, 107, 162, 111, 113, 40, 223, 28, 38, 240, 41, 204, 198, 80, 76, 38, 212, 113, 110, 226, 185, 126, 170, 182, 159, 83, 170, 238, 121, 140, 181, 245, 125, 0, 0, 1, 66, 99, 148, 116, 48, 219, 112, 177, 109, 252, 156, 187, 191, 161, 207, 236, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 152, 209, 55, 184, 116, 47, 72, 77, 160, 83, 76, 19, 11, 94, 207, 79, 179, 131, 227, 251, 75, 157, 93, 142, 187, 213, 241, 185, 108, 154, 160, 0, 0, 0, 81, 152, 228, 243, 131, 104, 243, 243, 186, 247, 179, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 70, 139, 189, 196, 183, 201, 138, 19, 104, 38, 9, 167, 54, 199, 104, 122, 28, 15, 23, 220, 94, 107, 219, 126, 223, 243, 59, 166, 247, 23, 208, 0, 0, 0, 1, 135, 154, 235, 156, 204, 123, 223, 75, 48, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 120, 141, 35, 123, 141, 107, 147, 4, 22, 132, 205, 51, 31, 165, 232, 53, 222, 47, 188, 190, 212, 181, 236, 234, 245, 174, 223, 141, 185, 190, 48, 0, 0, 0, 0, 240, 192, 225, 174, 127, 53, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 195, 78, 221, 227, 216, 100, 214, 132, 169, 205, 173, 245, 250, 122, 167, 15, 232, 87, 124, 253, 154, 213, 166, 195, 187, 199, 233, 29, 111, 55, 100, 95, 0, 81, 45, 139, 242, 5, 129, 34, 252, 162, 90, 2, 224, 164, 95, 130, 204, 184, 42, 22, 165, 82, 208, 240, 191, 36, 90, 145, 47, 11, 18, 248, 137, 104, 84, 36, 87, 41, 150, 229, 224, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 84, 219, 229, 98, 179, 105, 194, 102, 156, 95, 89, 227, 251, 234, 92, 142, 237, 206, 42, 251, 20, 221, 250, 158, 127, 113, 232, 113, 190, 93, 62, 162, 6, 166, 113, 3, 32, 103, 14, 152, 124, 230, 109, 101, 67, 119, 57, 65, 177, 157, 28, 249, 228, 250, 44, 218, 15, 147, 207, 163, 141, 172, 226, 6, 248, 112, 3, 116, 48, 199, 100, 56, 193, 124, 117, 179, 134, 159, 81, 150, 39, 207, 38, 228, 106, 231, 209, 71, 23, 48, 103, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 119, 99, 157, 129, 218, 231, 196, 179, 214, 236, 106, 158, 127, 232, 185, 13, 36, 162, 158, 195, 126, 236, 249, 157, 163, 119, 153, 242, 233, 245, 16, 62, 109, 59, 209, 152, 62, 111, 58, 169, 205, 78, 228, 124, 216, 117, 211, 64, 55, 83, 163, 31, 47, 153, 211, 112, 57, 89, 244, 73, 181, 156, 64, 223, 14, 28, 125, 44, 124, 220, 116, 147, 159, 29, 96, 222, 207, 152, 15, 168, 203, 19, 231, 147, 114, 57, 113, 222, 78, 32, 108, 167, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 62, 93, 61, 103, 115, 149, 9, 190, 185, 201, 246, 86, 220, 31, 87, 95, 30, 25, 68, 73, 27, 159, 95, 206, 237, 253, 14, 87, 203, 167, 212, 64, 249, 196, 238, 6, 120, 249, 168, 235, 135, 8, 47, 14, 150, 100, 13, 76, 232, 134, 210, 124, 202, 111, 70, 152, 108, 71, 78, 54, 179, 136, 27, 225, 192, 13, 196, 221, 14, 142, 107, 135, 38, 51, 38, 148, 125, 42, 98, 78, 46, 108, 165, 225, 197, 142, 226, 105, 39, 208, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 43, 225, 211, 183, 184, 145, 140, 186, 111, 3, 233, 55, 188, 141, 201, 68, 74, 34, 81, 25, 222, 167, 31, 160, 245, 120, 63, 47, 25, 64, 117, 227, 138, 21, 77, 212, 223, 142, 68, 118, 179, 231, 147, 167, 156, 136, 205, 157, 36, 228, 71, 210, 230, 52, 228, 135, 77, 54, 179, 136, 27, 225, 196, 15, 168, 129, 205, 14, 98, 82, 58, 185, 51, 147, 17, 59, 121, 166, 155, 17, 152, 46, 78, 52, 125, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 132, 215, 73, 221, 226, 91, 179, 233, 126, 107, 233, 153, 62, 122, 80, 246, 34, 81, 19, 221, 211, 234, 61, 223, 51, 114, 168, 3, 194, 36, 192, 0, 0, 0, 0, 0, 0, 0, 129, 225, 80, 17, 4, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 134, 173, 181, 203, 194, 90, 250, 159, 152, 250, 78, 75, 74, 190, 214, 178, 136, 144, 201, 143, 57, 233, 252, 214, 252, 213, 0, 0, 0, 0, 13, 68, 21, 10, 68, 204, 201, 138, 43, 152, 82, 244, 191, 61, 49, 100, 75, 98, 185, 158, 51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 49, 57, 117, 117, 28, 184, 117, 111, 47, 244, 92, 134, 156, 202, 49, 202, 30, 196, 74, 99, 3, 234, 57, 29, 111, 63, 39, 51, 74, 0, 0, 0, 1, 225, 160, 131, 92, 47, 140, 81, 213, 142, 56, 11, 147, 166, 26, 145, 138, 61, 47, 10, 69, 161, 215, 11, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 230, 186, 62, 198, 142, 163, 229, 254, 135, 144, 212, 74, 149, 146, 61, 132, 162, 184, 238, 198, 174, 59, 211, 114, 251, 46, 150, 150, 66, 180, 0, 0, 0, 137, 133, 182, 92, 101, 113, 64, 240, 198, 30, 148, 139, 178, 240, 199, 151, 37, 192, 53, 243, 46, 86, 48, 7, 67, 50, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 3, 38, 191, 59, 224, 251, 11, 206, 110, 207, 181, 172, 161, 40, 172, 161, 238, 90, 105, 94, 207, 157, 150, 218, 142, 141, 167, 163, 179, 98, 213, 144, 0, 30, 22, 51, 151, 76, 201, 209, 218, 105, 163, 153, 174, 184, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 142, 113, 201, 236, 218, 241, 187, 18, 138, 74, 18, 71, 181, 74, 107, 137, 237, 107, 235, 190, 171, 5, 229, 114, 231, 49, 235, 237, 120, 117, 50, 244, 195, 94, 43, 78, 102, 194, 115, 96, 173, 183, 131, 203, 185, 156, 199, 165, 208, 176, 114, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195, 107, 108, 232, 254, 99, 210, 33, 56, 143, 98, 37, 17, 234, 37, 146, 186, 119, 172, 210, 143, 87, 53, 101, 167, 19, 56, 138, 149, 153, 197, 189, 90, 81, 23, 145, 135, 166, 107, 112, 239, 99, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 195, 85, 228, 117, 117, 222, 47, 86, 85, 123, 17, 40, 137, 68, 123, 17, 75, 118, 154, 79, 177, 213, 186, 218, 216, 169, 22, 148, 90, 164, 39, 9, 21, 171, 94, 137, 173, 198, 206, 215, 84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 98, 117, 46, 39, 87, 11, 199, 233, 72, 149, 107, 237, 99, 210, 81, 22, 189, 44, 90, 111, 171, 197, 117, 185, 154, 117, 201, 57, 78, 182, 173, 90, 239, 184, 57, 27, 54, 61, 47, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 21, 157, 99, 137, 212, 194, 241, 186, 62, 195, 217, 137, 99, 167, 178, 150, 53, 45, 236, 90, 183, 163, 173, 175, 95, 37, 198, 76, 181, 232, 223, 240, 114, 54, 108, 90, 94, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 67, 7, 203, 222, 215, 188, 255, 0, 67, 204, 89, 101, 21, 246, 34, 82, 149, 34, 89, 107, 105, 181, 91, 110, 246, 61, 199, 167, 207, 204, 87, 7, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 22, 154, 217, 117, 223, 61, 211, 178, 231, 108, 74, 18, 138, 202, 177, 41, 140, 151, 107, 75, 57, 222, 210, 171, 154, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 107, 56, 190, 102, 198, 23, 133, 189, 79, 79, 53, 231, 71, 87, 55, 223, 210, 188, 221, 195, 236, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 41, 52, 48, 94, 231, 103, 26, 94, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 255, 196, 0, 85, 16, 0, 1, 4, 1, 2, 2, 4, 5, 12, 14, 8, 2, 11, 0, 0, 0, 1, 0, 2, 3, 4, 5, 6, 17, 7, 33, 18, 19, 49, 81, 16, 50, 65, 113, 178, 20, 34, 35, 54, 55, 80, 82, 97, 114, 115, 116, 145, 21, 22, 23, 48, 51, 53, 67, 84, 85, 96, 129, 148, 179, 194, 32, 52, 66, 117, 131, 161, 177, 210, 37, 98, 64, 83, 86, 130, 146, 147, 149, 160, 176, 193, 242, 255, 218, 0, 8, 1, 1, 0, 1, 63, 0, 255, 0, 223, 47, 37, 184, 33, 252, 36, 172, 111, 156, 169, 245, 22, 58, 14, 217, 193, 243, 41, 117, 165, 54, 120, 145, 189, 234, 93, 117, 255, 0, 85, 89, 63, 92, 91, 242, 71, 18, 126, 181, 200, 158, 194, 192, 165, 213, 153, 99, 226, 217, 217, 29, 93, 158, 30, 45, 150, 61, 125, 191, 230, 161, 252, 42, 131, 137, 118, 251, 226, 80, 241, 10, 219, 187, 99, 133, 202, 29, 124, 223, 202, 213, 80, 107, 90, 18, 120, 225, 236, 80, 106, 28, 117, 142, 76, 156, 15, 63, 37, 29, 136, 165, 27, 199, 35, 29, 230, 63, 168, 175, 158, 56, 134, 239, 123, 90, 173, 106, 26, 117, 247, 1, 221, 51, 241, 43, 58, 182, 83, 202, 24, 195, 85, 140, 229, 217, 252, 105, 156, 2, 146, 121, 36, 241, 222, 93, 231, 37, 56, 162, 138, 40, 162, 156, 17, 10, 90, 241, 73, 227, 177, 169, 248, 242, 207, 93, 94, 87, 199, 241, 38, 222, 187, 76, 251, 43, 4, 172, 239, 85, 51, 16, 79, 179, 92, 122, 14, 238, 41, 143, 228, 28, 215, 125, 74, 27, 83, 199, 226, 74, 241, 251, 85, 93, 69, 122, 14, 93, 113, 112, 238, 42, 182, 176, 61, 147, 196, 170, 231, 233, 89, 252, 167, 65, 221, 197, 50, 70, 60, 110, 199, 3, 239, 252, 175, 234, 226, 115, 251, 134, 234, 254, 126, 203, 220, 230, 68, 122, 176, 166, 179, 52, 199, 119, 200, 231, 31, 140, 167, 34, 138, 40, 162, 138, 40, 162, 138, 40, 162, 136, 223, 146, 158, 140, 82, 110, 64, 13, 114, 134, 229, 188, 107, 128, 46, 46, 103, 113, 88, 252, 164, 55, 70, 222, 36, 159, 5, 53, 53, 48, 236, 170, 223, 177, 1, 246, 57, 28, 22, 35, 61, 45, 137, 219, 12, 192, 18, 125, 254, 184, 55, 167, 47, 201, 42, 79, 29, 222, 116, 81, 69, 20, 81, 69, 20, 81, 69, 20, 81, 69, 20, 83, 154, 14, 234, 90, 206, 133, 221, 100, 36, 141, 187, 187, 86, 39, 53, 211, 45, 130, 217, 217, 222, 71, 166, 115, 9, 169, 171, 11, 203, 39, 7, 202, 247, 250, 223, 245, 73, 126, 73, 82, 120, 238, 243, 162, 138, 40, 162, 138, 40, 162, 138, 40, 248, 10, 40, 162, 138, 114, 158, 15, 237, 176, 17, 241, 44, 30, 91, 114, 43, 89, 60, 251, 24, 244, 212, 213, 134, 252, 103, 7, 202, 247, 250, 215, 245, 89, 126, 73, 82, 248, 238, 243, 162, 17, 8, 163, 224, 40, 162, 138, 33, 21, 177, 61, 131, 154, 173, 140, 179, 113, 251, 67, 27, 158, 79, 112, 84, 180, 45, 185, 249, 206, 68, 106, 30, 31, 212, 31, 132, 157, 229, 13, 11, 139, 238, 122, 151, 64, 99, 159, 226, 61, 236, 87, 56, 112, 64, 38, 172, 235, 35, 165, 50, 56, 237, 204, 144, 146, 223, 132, 20, 145, 190, 51, 179, 216, 70, 221, 234, 104, 204, 110, 233, 52, 252, 124, 150, 15, 35, 234, 200, 58, 15, 62, 204, 196, 213, 134, 252, 103, 7, 202, 247, 250, 199, 58, 242, 124, 149, 55, 225, 29, 231, 69, 20, 81, 69, 20, 81, 69, 79, 60, 112, 248, 238, 85, 133, 139, 243, 8, 234, 196, 226, 74, 194, 232, 142, 201, 178, 46, 223, 254, 69, 90, 156, 21, 35, 12, 130, 54, 177, 163, 187, 250, 78, 104, 112, 217, 192, 16, 179, 58, 58, 134, 78, 55, 152, 216, 34, 153, 102, 244, 205, 204, 60, 133, 179, 71, 187, 15, 148, 42, 150, 31, 66, 235, 30, 222, 68, 31, 93, 230, 80, 72, 217, 162, 108, 140, 59, 181, 195, 112, 176, 223, 141, 32, 249, 94, 255, 0, 76, 55, 133, 227, 226, 83, 126, 21, 254, 114, 138, 40, 162, 138, 40, 169, 94, 216, 154, 92, 242, 0, 10, 206, 76, 187, 113, 15, 33, 222, 176, 184, 91, 25, 155, 97, 128, 30, 103, 153, 43, 7, 167, 235, 225, 224, 13, 104, 14, 147, 202, 239, 189, 91, 167, 5, 216, 29, 21, 136, 218, 246, 57, 107, 29, 33, 38, 38, 67, 60, 27, 190, 2, 180, 213, 178, 248, 95, 93, 231, 155, 57, 181, 96, 198, 249, 72, 124, 254, 255, 0, 63, 156, 110, 243, 43, 3, 105, 159, 231, 69, 16, 138, 40, 132, 66, 187, 118, 58, 173, 230, 122, 82, 121, 26, 167, 179, 37, 151, 238, 253, 207, 112, 11, 29, 140, 125, 219, 13, 102, 222, 49, 28, 150, 7, 13, 14, 42, 147, 67, 90, 58, 194, 57, 159, 190, 90, 171, 21, 202, 239, 134, 102, 135, 49, 227, 98, 178, 248, 73, 52, 222, 125, 165, 131, 216, 30, 238, 71, 188, 21, 128, 0, 228, 226, 238, 242, 123, 252, 123, 10, 182, 54, 176, 255, 0, 148, 138, 40, 162, 156, 178, 57, 17, 88, 24, 217, 206, 83, 254, 75, 119, 207, 33, 36, 238, 227, 218, 84, 53, 196, 124, 207, 55, 249, 22, 139, 195, 15, 235, 114, 143, 147, 247, 237, 77, 137, 110, 91, 17, 43, 54, 222, 86, 14, 147, 10, 210, 133, 239, 179, 7, 76, 108, 64, 217, 222, 255, 0, 223, 103, 70, 228, 131, 227, 69, 31, 1, 89, 59, 194, 164, 59, 14, 114, 59, 176, 33, 211, 158, 82, 73, 220, 158, 210, 161, 133, 177, 183, 144, 84, 107, 155, 54, 217, 24, 29, 170, 133, 102, 212, 167, 28, 76, 28, 154, 62, 255, 0, 87, 29, 234, 93, 73, 35, 154, 61, 141, 224, 188, 121, 207, 191, 249, 102, 244, 114, 50, 249, 209, 69, 21, 106, 118, 86, 129, 210, 56, 236, 7, 98, 150, 89, 46, 217, 47, 62, 51, 191, 201, 67, 8, 141, 128, 15, 218, 128, 90, 58, 152, 159, 44, 215, 121, 26, 58, 94, 9, 243, 120, 186, 211, 58, 25, 242, 84, 226, 149, 157, 172, 124, 237, 4, 126, 194, 127, 161, 102, 221, 122, 112, 153, 109, 79, 20, 17, 142, 215, 200, 240, 209, 245, 149, 83, 59, 138, 191, 47, 85, 75, 39, 74, 196, 159, 2, 25, 216, 243, 245, 3, 224, 150, 104, 224, 137, 210, 205, 35, 35, 141, 131, 119, 61, 231, 96, 7, 198, 87, 219, 22, 27, 244, 181, 15, 222, 88, 153, 159, 196, 72, 240, 214, 101, 40, 185, 221, 194, 195, 60, 22, 174, 86, 163, 16, 150, 221, 136, 96, 140, 157, 186, 114, 188, 52, 111, 221, 185, 95, 108, 88, 111, 210, 212, 63, 121, 98, 251, 98, 195, 126, 150, 161, 251, 203, 21, 91, 116, 239, 239, 45, 59, 48, 88, 12, 228, 93, 20, 129, 224, 125, 72, 231, 177, 34, 83, 25, 202, 81, 18, 3, 209, 45, 51, 179, 125, 252, 54, 178, 248, 234, 82, 245, 86, 239, 213, 130, 77, 183, 232, 75, 51, 90, 118, 243, 18, 160, 158, 43, 48, 182, 104, 37, 100, 177, 59, 155, 94, 199, 7, 52, 249, 136, 240, 91, 201, 81, 160, 90, 46, 92, 175, 92, 187, 155, 68, 178, 181, 155, 253, 106, 189, 152, 109, 192, 217, 171, 77, 28, 209, 59, 177, 241, 184, 57, 167, 246, 132, 252, 254, 34, 55, 150, 63, 43, 69, 174, 105, 216, 131, 97, 128, 130, 134, 161, 195, 249, 50, 212, 63, 121, 98, 142, 70, 74, 192, 248, 220, 215, 177, 195, 112, 230, 157, 193, 240, 92, 201, 209, 199, 0, 235, 215, 43, 86, 7, 176, 205, 43, 89, 254, 170, 150, 95, 29, 146, 229, 70, 253, 91, 63, 51, 51, 95, 254, 135, 192, 252, 222, 46, 57, 204, 15, 201, 83, 108, 193, 221, 18, 195, 59, 67, 129, 238, 219, 127, 3, 156, 214, 48, 185, 228, 53, 160, 110, 73, 228, 0, 85, 243, 56, 219, 147, 8, 106, 228, 42, 77, 41, 236, 100, 115, 53, 199, 234, 5, 91, 200, 83, 160, 26, 110, 219, 130, 184, 127, 139, 214, 200, 25, 191, 155, 117, 86, 237, 91, 209, 153, 41, 217, 134, 195, 1, 216, 186, 39, 135, 128, 123, 185, 120, 39, 158, 26, 176, 186, 107, 18, 178, 40, 155, 227, 61, 238, 13, 104, 243, 146, 170, 229, 177, 247, 165, 49, 84, 189, 86, 121, 0, 220, 182, 41, 154, 227, 183, 152, 31, 121, 243, 172, 232, 223, 113, 239, 69, 20, 86, 114, 233, 158, 199, 82, 195, 235, 35, 228, 85, 104, 58, 182, 110, 123, 74, 1, 108, 180, 44, 0, 50, 89, 60, 28, 78, 247, 71, 204, 252, 240, 244, 71, 135, 136, 58, 226, 29, 19, 133, 19, 0, 37, 191, 63, 42, 208, 255, 0, 171, 143, 196, 22, 59, 9, 170, 248, 163, 147, 150, 209, 144, 207, 208, 228, 249, 231, 126, 209, 68, 178, 220, 23, 212, 248, 138, 134, 220, 6, 173, 222, 135, 50, 202, 175, 61, 53, 194, 254, 40, 219, 101, 248, 112, 121, 249, 204, 208, 204, 67, 32, 158, 95, 30, 55, 119, 57, 113, 7, 218, 6, 115, 232, 143, 90, 67, 72, 220, 214, 153, 105, 104, 80, 154, 8, 101, 142, 3, 57, 51, 146, 6, 192, 129, 228, 5, 92, 224, 94, 165, 130, 171, 230, 138, 124, 116, 229, 157, 145, 49, 239, 220, 253, 109, 92, 39, 215, 119, 176, 249, 248, 48, 57, 41, 94, 250, 22, 95, 212, 176, 75, 219, 4, 139, 142, 190, 209, 32, 250, 115, 61, 7, 173, 29, 195, 172, 158, 182, 169, 102, 122, 22, 105, 194, 32, 120, 97, 19, 151, 15, 244, 5, 125, 193, 53, 15, 233, 12, 87, 215, 39, 251, 23, 12, 180, 85, 237, 21, 139, 187, 90, 252, 240, 76, 249, 230, 15, 6, 5, 168, 125, 178, 229, 62, 151, 47, 166, 87, 12, 53, 95, 219, 78, 145, 133, 243, 191, 123, 213, 54, 130, 199, 255, 0, 78, 89, 11, 240, 98, 241, 214, 46, 219, 120, 100, 21, 227, 50, 72, 239, 136, 45, 73, 157, 159, 82, 103, 238, 101, 44, 248, 243, 191, 112, 223, 128, 222, 198, 183, 246, 5, 195, 15, 115, 140, 55, 204, 159, 76, 248, 56, 255, 0, 248, 207, 11, 243, 50, 174, 17, 123, 152, 98, 63, 198, 254, 51, 213, 218, 18, 101, 117, 212, 244, 32, 44, 108, 182, 242, 78, 129, 133, 253, 128, 186, 93, 130, 60, 5, 212, 94, 75, 248, 175, 174, 79, 246, 45, 51, 169, 179, 60, 52, 213, 47, 163, 123, 166, 32, 100, 189, 11, 149, 15, 164, 213, 196, 157, 102, 116, 182, 146, 22, 241, 228, 27, 87, 8, 142, 179, 255, 0, 204, 189, 105, 157, 15, 159, 226, 44, 182, 114, 2, 208, 216, 63, 105, 45, 91, 121, 37, 239, 89, 110, 15, 106, 172, 24, 245, 85, 49, 21, 208, 207, 45, 55, 158, 154, 225, 119, 217, 199, 232, 232, 103, 207, 217, 150, 105, 165, 36, 194, 38, 241, 217, 26, 212, 126, 234, 183, 255, 0, 189, 143, 241, 60, 25, 191, 196, 57, 15, 163, 73, 232, 149, 193, 191, 116, 154, 31, 34, 95, 64, 174, 63, 254, 3, 5, 231, 159, 249, 23, 7, 53, 95, 216, 29, 83, 234, 9, 223, 181, 60, 150, 209, 249, 165, 254, 199, 131, 142, 154, 175, 156, 26, 110, 171, 251, 167, 183, 252, 140, 92, 9, 246, 247, 63, 208, 95, 233, 179, 222, 125, 71, 30, 211, 49, 253, 225, 20, 86, 66, 200, 169, 69, 242, 30, 210, 54, 10, 180, 102, 121, 75, 221, 207, 189, 0, 128, 91, 45, 17, 253, 74, 95, 7, 19, 189, 209, 243, 63, 60, 61, 17, 225, 227, 30, 82, 75, 252, 66, 183, 15, 108, 84, 216, 200, 99, 90, 79, 11, 14, 3, 75, 208, 199, 192, 192, 58, 168, 71, 79, 227, 121, 230, 227, 224, 227, 22, 26, 44, 46, 189, 123, 234, 128, 198, 93, 136, 90, 243, 60, 146, 10, 201, 228, 223, 153, 224, 140, 247, 230, 231, 44, 216, 189, 223, 242, 182, 230, 184, 27, 106, 10, 154, 210, 227, 231, 153, 144, 131, 65, 252, 223, 243, 145, 171, 90, 147, 13, 78, 179, 231, 159, 41, 73, 145, 48, 110, 73, 153, 170, 134, 250, 151, 137, 241, 203, 65, 132, 11, 185, 67, 59, 7, 115, 12, 157, 63, 242, 11, 142, 190, 209, 32, 250, 115, 61, 7, 174, 25, 241, 26, 134, 137, 161, 118, 11, 213, 45, 78, 103, 148, 60, 24, 87, 221, 243, 7, 250, 51, 37, 245, 49, 97, 178, 145, 102, 176, 213, 50, 80, 49, 236, 138, 212, 77, 149, 173, 127, 104, 5, 75, 64, 101, 184, 134, 250, 15, 121, 99, 109, 229, 76, 5, 221, 193, 210, 236, 180, 22, 102, 125, 1, 175, 223, 71, 39, 235, 33, 124, 134, 165, 177, 232, 189, 113, 207, 86, 116, 32, 131, 78, 85, 127, 57, 118, 154, 215, 242, 53, 103, 52, 244, 216, 42, 56, 153, 44, 242, 154, 253, 111, 84, 244, 62, 3, 75, 136, 106, 225, 135, 185, 198, 27, 230, 79, 166, 124, 28, 127, 252, 103, 133, 249, 153, 87, 8, 189, 204, 49, 31, 227, 127, 25, 234, 139, 196, 92, 88, 129, 239, 32, 48, 102, 219, 252, 116, 115, 152, 182, 130, 78, 74, 144, 3, 190, 118, 174, 37, 229, 235, 106, 45, 125, 114, 124, 103, 179, 67, 235, 33, 99, 217, 249, 82, 2, 226, 134, 149, 191, 63, 14, 48, 194, 6, 25, 167, 196, 177, 130, 118, 14, 238, 128, 4, 173, 5, 196, 203, 154, 34, 25, 106, 122, 149, 151, 40, 202, 254, 180, 199, 226, 56, 57, 97, 120, 207, 166, 50, 164, 50, 204, 179, 99, 165, 238, 159, 196, 250, 194, 134, 104, 236, 66, 201, 96, 145, 146, 68, 241, 187, 94, 194, 8, 112, 239, 5, 106, 63, 117, 91, 255, 0, 222, 199, 248, 158, 12, 223, 226, 28, 135, 209, 164, 244, 74, 224, 223, 186, 77, 15, 145, 47, 160, 87, 31, 255, 0, 1, 130, 243, 207, 252, 138, 206, 2, 122, 218, 91, 31, 159, 136, 147, 4, 243, 62, 7, 159, 129, 35, 79, 47, 172, 45, 55, 196, 58, 214, 248, 106, 252, 245, 247, 239, 61, 24, 203, 44, 142, 249, 71, 251, 149, 58, 23, 181, 157, 236, 230, 94, 211, 249, 87, 130, 91, 182, 36, 248, 246, 61, 22, 174, 4, 251, 123, 159, 232, 47, 244, 217, 239, 62, 162, 143, 165, 85, 142, 238, 40, 162, 22, 164, 159, 119, 199, 0, 243, 149, 82, 46, 174, 17, 222, 121, 160, 16, 11, 101, 162, 39, 229, 44, 94, 14, 39, 123, 163, 230, 126, 120, 122, 35, 195, 198, 124, 68, 184, 237, 123, 61, 175, 200, 223, 99, 38, 103, 162, 86, 138, 207, 193, 169, 52, 165, 27, 208, 188, 23, 152, 131, 38, 31, 2, 64, 54, 112, 240, 113, 99, 59, 30, 163, 215, 146, 138, 62, 205, 21, 86, 10, 145, 150, 127, 108, 133, 151, 197, 191, 11, 193, 89, 241, 242, 120, 240, 98, 246, 127, 202, 219, 154, 210, 90, 74, 246, 178, 202, 75, 67, 27, 36, 17, 205, 28, 38, 114, 103, 36, 13, 129, 3, 200, 10, 213, 252, 61, 204, 104, 184, 160, 155, 36, 96, 150, 25, 201, 2, 72, 9, 32, 30, 227, 184, 11, 129, 152, 172, 25, 197, 79, 147, 131, 119, 230, 24, 76, 83, 244, 255, 0, 36, 60, 157, 5, 199, 95, 104, 144, 125, 57, 158, 131, 215, 7, 244, 102, 11, 83, 226, 178, 51, 102, 104, 11, 47, 134, 96, 24, 76, 175, 98, 251, 146, 232, 207, 208, 163, 247, 137, 191, 220, 168, 81, 175, 140, 161, 5, 42, 113, 245, 85, 224, 96, 142, 54, 110, 78, 205, 29, 131, 114, 177, 190, 235, 149, 127, 191, 25, 252, 117, 199, 77, 41, 206, 13, 73, 85, 157, 208, 91, 254, 71, 173, 7, 128, 179, 174, 181, 172, 34, 251, 223, 60, 17, 109, 45, 183, 191, 202, 198, 242, 13, 92, 124, 246, 205, 140, 250, 31, 243, 149, 195, 15, 115, 140, 55, 204, 159, 76, 248, 56, 255, 0, 248, 207, 11, 243, 50, 174, 17, 123, 152, 98, 63, 198, 254, 51, 213, 234, 18, 229, 117, 205, 154, 16, 22, 9, 173, 100, 93, 3, 11, 251, 1, 116, 155, 13, 215, 220, 27, 83, 126, 121, 137, 255, 0, 206, 147, 253, 139, 66, 240, 118, 13, 57, 125, 153, 60, 196, 236, 185, 114, 46, 112, 177, 158, 36, 101, 79, 106, 10, 129, 134, 204, 209, 196, 36, 120, 141, 133, 238, 13, 233, 56, 246, 1, 191, 149, 103, 120, 109, 166, 115, 229, 242, 218, 198, 178, 41, 207, 108, 208, 123, 27, 150, 191, 225, 25, 210, 184, 169, 114, 216, 235, 198, 122, 81, 16, 36, 100, 220, 158, 205, 215, 1, 51, 118, 140, 249, 28, 51, 222, 95, 89, 145, 9, 226, 92, 71, 130, 92, 63, 19, 50, 111, 239, 156, 89, 103, 237, 217, 203, 29, 126, 12, 166, 58, 189, 234, 175, 15, 130, 196, 109, 145, 135, 226, 33, 107, 156, 172, 88, 109, 21, 149, 181, 47, 230, 239, 141, 159, 27, 220, 54, 106, 224, 125, 23, 207, 174, 204, 254, 74, 181, 158, 245, 199, 255, 0, 192, 96, 188, 243, 255, 0, 34, 225, 214, 2, 13, 77, 193, 169, 241, 115, 246, 79, 44, 187, 63, 224, 63, 200, 85, 177, 127, 20, 251, 152, 137, 221, 36, 91, 76, 4, 240, 121, 11, 217, 184, 31, 86, 229, 99, 116, 167, 218, 175, 5, 178, 204, 157, 155, 94, 181, 70, 89, 236, 249, 203, 57, 53, 112, 39, 219, 220, 255, 0, 65, 127, 166, 207, 121, 242, 209, 117, 180, 36, 8, 162, 55, 87, 222, 109, 102, 31, 221, 190, 201, 160, 15, 244, 64, 32, 16, 11, 74, 89, 234, 50, 177, 143, 35, 183, 103, 237, 62, 14, 39, 123, 163, 230, 126, 120, 122, 33, 125, 218, 181, 119, 231, 21, 127, 119, 11, 238, 213, 171, 191, 56, 171, 251, 184, 90, 135, 74, 195, 175, 244, 85, 38, 92, 34, 59, 166, 6, 79, 12, 255, 0, 1, 229, 171, 170, 214, 60, 47, 201, 72, 88, 39, 169, 222, 240, 58, 112, 76, 175, 113, 47, 88, 234, 120, 78, 58, 41, 223, 180, 188, 140, 116, 160, 217, 239, 92, 50, 225, 60, 244, 46, 195, 155, 212, 113, 6, 75, 23, 58, 213, 15, 166, 245, 196, 31, 104, 25, 207, 162, 61, 112, 23, 219, 189, 223, 238, 231, 255, 0, 18, 53, 169, 112, 21, 181, 62, 2, 214, 46, 223, 137, 51, 121, 63, 202, 199, 249, 28, 180, 174, 102, 239, 13, 181, 217, 101, 224, 67, 24, 243, 5, 216, 187, 216, 184, 223, 51, 39, 208, 21, 102, 132, 135, 196, 251, 145, 22, 31, 59, 30, 180, 198, 187, 205, 105, 24, 39, 131, 19, 44, 44, 100, 239, 15, 127, 78, 32, 229, 247, 106, 213, 223, 156, 85, 253, 220, 46, 18, 107, 60, 182, 175, 135, 42, 114, 239, 137, 230, 177, 136, 51, 160, 206, 254, 146, 198, 251, 174, 85, 254, 252, 103, 241, 214, 83, 27, 91, 49, 140, 177, 66, 244, 125, 101, 123, 12, 44, 123, 86, 151, 209, 184, 157, 31, 4, 241, 98, 98, 120, 235, 220, 12, 142, 123, 247, 39, 101, 199, 223, 108, 248, 223, 161, 255, 0, 57, 92, 48, 247, 56, 195, 124, 201, 244, 207, 131, 143, 255, 0, 140, 240, 191, 51, 42, 225, 23, 185, 134, 35, 252, 111, 227, 61, 99, 125, 215, 42, 255, 0, 126, 51, 248, 254, 30, 48, 233, 108, 254, 165, 169, 76, 226, 0, 158, 173, 109, 222, 250, 221, 143, 47, 84, 181, 238, 180, 210, 59, 83, 154, 205, 166, 6, 118, 65, 122, 45, 253, 46, 107, 55, 175, 53, 70, 183, 132, 99, 38, 38, 88, 156, 127, 171, 84, 131, 199, 43, 132, 58, 22, 222, 151, 163, 102, 254, 85, 157, 11, 183, 54, 2, 31, 44, 76, 11, 138, 188, 60, 151, 86, 85, 138, 254, 47, 241, 157, 97, 183, 207, 177, 98, 117, 150, 173, 208, 91, 227, 129, 150, 6, 126, 109, 110, 21, 123, 47, 171, 184, 149, 114, 40, 8, 158, 246, 199, 214, 67, 11, 54, 137, 139, 135, 26, 28, 104, 172, 25, 100, 228, 73, 126, 209, 15, 157, 255, 0, 232, 192, 184, 255, 0, 248, 12, 23, 158, 127, 228, 92, 19, 247, 60, 139, 233, 50, 172, 143, 14, 240, 25, 77, 74, 204, 237, 170, 207, 55, 3, 152, 254, 230, 60, 183, 176, 144, 181, 223, 180, 60, 239, 208, 101, 244, 87, 2, 125, 189, 207, 244, 23, 250, 108, 247, 158, 86, 116, 226, 123, 123, 193, 10, 211, 12, 86, 30, 222, 226, 158, 238, 131, 11, 187, 185, 170, 123, 201, 117, 239, 61, 229, 0, 128, 91, 32, 19, 102, 125, 97, 214, 198, 118, 115, 15, 72, 121, 214, 58, 219, 47, 80, 134, 196, 103, 118, 189, 160, 255, 0, 73, 145, 178, 61, 250, 182, 53, 187, 247, 13, 191, 232, 210, 70, 201, 89, 209, 145, 141, 123, 123, 156, 55, 10, 40, 34, 128, 17, 12, 76, 140, 119, 49, 160, 120, 94, 198, 72, 221, 158, 214, 184, 119, 17, 186, 107, 67, 6, 205, 0, 1, 228, 30, 247, 103, 96, 234, 174, 244, 252, 142, 87, 14, 212, 230, 249, 5, 98, 219, 185, 145, 200, 4, 2, 1, 0, 156, 208, 246, 16, 124, 163, 101, 195, 236, 231, 57, 113, 83, 187, 155, 14, 241, 253, 251, 86, 235, 139, 90, 90, 119, 237, 128, 187, 114, 156, 81, 7, 201, 109, 156, 163, 106, 211, 26, 214, 254, 163, 181, 8, 126, 154, 189, 70, 156, 209, 117, 162, 220, 222, 33, 11, 75, 107, 234, 58, 179, 53, 147, 161, 70, 23, 129, 75, 196, 155, 201, 56, 220, 141, 194, 204, 241, 10, 10, 57, 89, 113, 120, 124, 101, 220, 213, 248, 57, 206, 202, 131, 148, 63, 41, 203, 19, 175, 233, 101, 116, 214, 83, 42, 106, 89, 170, 252, 88, 127, 170, 107, 79, 201, 225, 205, 11, 78, 102, 62, 207, 224, 41, 229, 58, 131, 92, 90, 103, 76, 68, 227, 185, 1, 51, 92, 214, 126, 87, 80, 212, 21, 95, 213, 96, 161, 235, 102, 159, 200, 254, 91, 236, 180, 150, 177, 165, 171, 52, 241, 202, 192, 12, 2, 34, 225, 52, 79, 59, 152, 200, 71, 138, 48, 13, 19, 6, 162, 56, 185, 246, 179, 111, 212, 176, 65, 211, 230, 245, 134, 214, 57, 124, 158, 90, 10, 147, 233, 28, 149, 24, 164, 237, 158, 111, 17, 139, 87, 106, 168, 244, 165, 42, 147, 26, 207, 181, 45, 187, 45, 173, 28, 76, 59, 18, 74, 214, 26, 170, 45, 33, 134, 101, 233, 107, 62, 201, 146, 118, 192, 200, 152, 118, 46, 113, 89, 253, 127, 46, 39, 82, 125, 132, 161, 131, 183, 148, 182, 32, 19, 188, 64, 124, 69, 46, 191, 158, 142, 152, 200, 230, 114, 216, 11, 148, 5, 66, 192, 200, 102, 127, 57, 203, 138, 171, 197, 2, 50, 116, 42, 230, 116, 238, 71, 23, 21, 247, 136, 225, 158, 110, 108, 46, 43, 49, 196, 57, 168, 106, 107, 88, 76, 110, 2, 238, 82, 122, 172, 99, 229, 48, 30, 245, 166, 243, 55, 51, 116, 165, 158, 246, 30, 206, 41, 204, 147, 160, 34, 159, 198, 112, 239, 247, 199, 61, 91, 173, 170, 30, 7, 54, 171, 163, 122, 115, 124, 130, 177, 35, 214, 73, 231, 64, 32, 16, 8, 4, 2, 200, 201, 54, 43, 49, 21, 200, 9, 105, 39, 112, 180, 214, 122, 28, 238, 53, 146, 176, 251, 40, 27, 72, 223, 190, 23, 6, 141, 202, 227, 21, 183, 253, 165, 50, 132, 28, 229, 201, 219, 138, 176, 92, 67, 203, 75, 134, 211, 180, 244, 206, 13, 146, 203, 145, 191, 24, 175, 19, 33, 230, 246, 66, 209, 179, 202, 211, 115, 156, 111, 18, 5, 90, 88, 155, 120, 222, 158, 12, 195, 4, 22, 128, 15, 123, 153, 204, 57, 112, 195, 39, 90, 167, 14, 46, 207, 86, 229, 8, 179, 29, 116, 175, 157, 247, 159, 176, 15, 242, 23, 172, 206, 179, 200, 231, 120, 77, 149, 158, 219, 41, 3, 107, 32, 40, 192, 106, 49, 236, 18, 246, 60, 187, 215, 44, 71, 168, 177, 216, 138, 116, 34, 179, 1, 21, 96, 100, 67, 103, 142, 198, 181, 50, 249, 28, 42, 213, 89, 190, 201, 243, 217, 35, 27, 62, 73, 119, 255, 0, 181, 159, 169, 111, 133, 125, 124, 53, 65, 56, 236, 222, 47, 168, 127, 252, 150, 3, 54, 37, 101, 177, 146, 154, 122, 3, 76, 86, 180, 202, 83, 136, 141, 231, 202, 240, 8, 137, 254, 58, 210, 212, 242, 245, 77, 147, 150, 212, 177, 230, 183, 13, 232, 6, 86, 142, 46, 171, 191, 197, 92, 70, 130, 222, 127, 95, 233, 156, 21, 11, 66, 172, 241, 7, 221, 235, 139, 3, 195, 59, 142, 222, 118, 44, 214, 35, 60, 117, 246, 151, 195, 102, 243, 255, 0, 101, 216, 249, 253, 86, 89, 234, 86, 68, 24, 35, 88, 216, 50, 121, 254, 33, 106, 140, 182, 43, 80, 195, 135, 49, 78, 41, 135, 190, 6, 75, 214, 181, 191, 43, 228, 46, 38, 11, 243, 233, 205, 57, 128, 55, 89, 147, 200, 223, 185, 206, 125, 131, 27, 55, 69, 80, 126, 95, 90, 241, 10, 44, 70, 171, 245, 29, 51, 129, 34, 224, 171, 84, 29, 167, 43, 75, 214, 203, 103, 179, 250, 147, 59, 137, 212, 208, 97, 196, 247, 157, 15, 175, 129, 147, 25, 24, 206, 207, 25, 99, 89, 52, 88, 218, 204, 179, 108, 92, 156, 70, 209, 37, 128, 208, 209, 43, 182, 230, 237, 135, 33, 191, 190, 51, 196, 38, 129, 236, 62, 80, 175, 215, 49, 153, 161, 61, 187, 16, 177, 77, 216, 76, 222, 231, 32, 16, 8, 4, 2, 1, 103, 106, 122, 162, 129, 115, 71, 174, 143, 154, 210, 217, 217, 176, 215, 195, 216, 227, 208, 61, 161, 98, 51, 21, 242, 245, 132, 144, 184, 116, 188, 173, 242, 143, 189, 57, 205, 99, 75, 156, 64, 1, 125, 145, 251, 41, 144, 21, 171, 254, 6, 51, 187, 207, 122, 205, 97, 51, 57, 123, 245, 102, 159, 23, 132, 156, 80, 159, 174, 166, 100, 187, 59, 11, 123, 137, 13, 102, 200, 97, 115, 195, 62, 115, 127, 98, 176, 39, 34, 98, 234, 122, 227, 126, 193, 217, 157, 192, 22, 108, 20, 248, 92, 245, 172, 245, 108, 204, 216, 172, 9, 200, 213, 97, 142, 25, 189, 95, 99, 147, 79, 196, 25, 178, 159, 64, 79, 111, 44, 114, 83, 233, 173, 52, 251, 95, 77, 159, 160, 79, 121, 103, 67, 162, 166, 208, 118, 231, 194, 193, 136, 151, 3, 129, 52, 32, 144, 203, 28, 67, 37, 107, 147, 207, 198, 26, 177, 220, 58, 155, 19, 107, 213, 52, 112, 24, 24, 166, 232, 61, 159, 140, 237, 158, 78, 4, 30, 214, 163, 163, 178, 39, 13, 79, 20, 112, 120, 19, 70, 148, 221, 124, 16, 250, 190, 215, 39, 255, 0, 224, 89, 204, 38, 119, 82, 80, 20, 178, 248, 156, 5, 152, 3, 195, 192, 55, 103, 28, 252, 225, 139, 57, 161, 238, 234, 59, 140, 181, 150, 193, 96, 103, 153, 145, 136, 129, 251, 37, 105, 155, 48, 124, 77, 96, 88, 13, 47, 150, 210, 162, 113, 133, 195, 96, 107, 117, 251, 117, 191, 241, 11, 47, 223, 111, 148, 194, 134, 27, 61, 246, 124, 230, 254, 197, 96, 78, 71, 169, 234, 58, 227, 126, 199, 137, 230, 232, 108, 159, 134, 207, 75, 159, 139, 52, 252, 86, 4, 228, 98, 136, 192, 201, 141, 235, 28, 153, 230, 232, 108, 165, 225, 96, 154, 87, 202, 253, 55, 130, 47, 127, 126, 86, 226, 139, 74, 229, 96, 159, 25, 43, 48, 184, 16, 252, 83, 11, 41, 255, 0, 196, 44, 237, 16, 63, 247, 19, 240, 25, 199, 231, 198, 108, 226, 112, 67, 36, 34, 234, 68, 226, 253, 145, 235, 60, 193, 155, 47, 185, 68, 95, 246, 103, 3, 255, 0, 170, 220, 88, 26, 214, 105, 98, 32, 171, 110, 10, 176, 24, 26, 34, 142, 58, 178, 57, 236, 107, 0, 1, 188, 220, 1, 247, 203, 61, 71, 119, 137, 219, 229, 228, 85, 88, 122, 155, 182, 226, 248, 47, 64, 32, 16, 8, 4, 2, 232, 135, 53, 193, 195, 145, 28, 213, 250, 174, 161, 146, 115, 60, 155, 244, 129, 239, 11, 21, 150, 177, 141, 156, 77, 89, 229, 96, 181, 165, 92, 136, 17, 217, 246, 41, 83, 30, 215, 183, 118, 56, 17, 222, 63, 167, 127, 49, 83, 30, 194, 102, 148, 111, 228, 104, 89, 93, 75, 62, 77, 230, 40, 119, 100, 69, 105, 172, 119, 168, 168, 7, 191, 240, 146, 115, 63, 168, 115, 68, 217, 162, 115, 31, 216, 86, 99, 26, 250, 57, 185, 78, 220, 164, 106, 1, 0, 128, 64, 32, 22, 203, 80, 227, 189, 87, 80, 74, 193, 236, 145, 42, 114, 244, 154, 88, 79, 54, 166, 18, 8, 32, 236, 86, 47, 83, 223, 199, 114, 100, 164, 179, 184, 170, 26, 250, 25, 57, 90, 143, 162, 161, 213, 120, 201, 191, 47, 178, 26, 135, 27, 249, 212, 106, 77, 77, 140, 143, 182, 192, 42, 214, 182, 165, 24, 61, 64, 47, 42, 246, 177, 187, 103, 118, 197, 180, 77, 82, 79, 36, 210, 116, 164, 121, 113, 62, 82, 180, 190, 32, 222, 182, 37, 120, 246, 54, 115, 41, 160, 53, 160, 14, 193, 250, 137, 168, 49, 98, 237, 94, 177, 131, 217, 24, 157, 31, 69, 229, 168, 32, 16, 8, 5, 178, 217, 102, 241, 199, 27, 123, 174, 140, 123, 12, 135, 145, 238, 42, 39, 137, 24, 8, 242, 166, 160, 129, 33, 53, 231, 188, 160, 79, 194, 40, 32, 177, 244, 164, 189, 105, 145, 70, 59, 74, 197, 99, 217, 142, 166, 216, 155, 219, 229, 63, 168, 187, 110, 181, 6, 23, 160, 243, 102, 22, 238, 223, 40, 65, 187, 32, 16, 8, 5, 178, 1, 91, 167, 29, 218, 206, 130, 81, 201, 223, 228, 84, 213, 230, 196, 92, 116, 51, 131, 208, 242, 59, 226, 77, 59, 128, 71, 97, 27, 130, 130, 8, 32, 130, 175, 3, 231, 148, 49, 131, 114, 86, 156, 193, 140, 117, 113, 36, 163, 121, 93, 250, 142, 246, 54, 70, 22, 184, 110, 10, 204, 225, 13, 87, 25, 97, 27, 198, 131, 80, 8, 15, 0, 8, 5, 146, 198, 67, 147, 172, 98, 155, 145, 30, 35, 187, 138, 154, 11, 24, 139, 6, 11, 32, 245, 100, 242, 114, 107, 131, 134, 224, 242, 65, 4, 20, 49, 62, 121, 3, 99, 27, 238, 180, 206, 157, 21, 24, 39, 178, 223, 94, 123, 7, 234, 76, 145, 182, 86, 22, 188, 2, 10, 203, 96, 157, 1, 50, 192, 55, 98, 232, 144, 128, 91, 32, 16, 8, 5, 106, 140, 55, 97, 49, 206, 192, 230, 149, 115, 79, 92, 198, 60, 201, 79, 217, 160, 248, 30, 80, 162, 178, 199, 158, 139, 183, 99, 254, 11, 185, 20, 21, 120, 31, 98, 81, 28, 109, 36, 149, 167, 52, 200, 166, 193, 61, 176, 12, 190, 64, 135, 234, 81, 0, 141, 143, 48, 178, 120, 33, 46, 242, 65, 203, 189, 170, 72, 95, 19, 203, 30, 8, 43, 100, 2, 1, 0, 128, 91, 43, 120, 138, 119, 71, 179, 192, 222, 151, 120, 228, 85, 109, 24, 102, 151, 104, 44, 188, 51, 185, 203, 13, 167, 43, 226, 217, 185, 1, 242, 247, 254, 167, 92, 198, 195, 113, 190, 184, 0, 238, 245, 115, 19, 53, 82, 78, 219, 183, 189, 108, 128, 64, 32, 19, 88, 231, 114, 1, 81, 196, 62, 94, 114, 250, 214, 168, 43, 199, 93, 157, 22, 15, 213, 7, 52, 60, 16, 225, 184, 42, 230, 18, 57, 55, 116, 60, 156, 167, 167, 45, 119, 17, 35, 8, 248, 208, 105, 85, 177, 179, 88, 62, 46, 195, 188, 170, 152, 216, 171, 13, 200, 233, 59, 245, 81, 241, 178, 65, 179, 218, 8, 76, 199, 192, 199, 244, 131, 2, 0, 1, 176, 31, 252, 130, 255, 0, 255, 196, 0, 44, 17, 0, 2, 1, 3, 2, 5, 4, 1, 5, 1, 1, 0, 0, 0, 0, 0, 1, 2, 0, 3, 4, 17, 33, 49, 5, 16, 18, 32, 96, 34, 48, 65, 80, 50, 19, 20, 35, 51, 64, 160, 176, 255, 218, 0, 8, 1, 2, 1, 1, 63, 0, 255, 0, 185, 112, 166, 10, 108, 96, 162, 96, 183, 48, 91, 193, 109, 13, 180, 54, 240, 219, 183, 196, 106, 78, 177, 153, 150, 126, 190, 55, 159, 185, 88, 43, 33, 129, 129, 240, 92, 24, 180, 201, 139, 66, 10, 34, 4, 2, 5, 19, 3, 158, 103, 87, 62, 144, 97, 183, 67, 42, 216, 6, 218, 87, 176, 101, 143, 73, 214, 7, 101, 139, 118, 203, 22, 248, 124, 196, 185, 70, 129, 129, 240, 10, 116, 132, 8, 4, 199, 189, 212, 68, 32, 48, 149, 172, 195, 203, 171, 50, 155, 66, 152, 58, 195, 9, 34, 37, 195, 39, 204, 182, 188, 235, 61, 39, 239, 151, 120, 155, 127, 128, 17, 51, 55, 141, 73, 95, 67, 47, 184, 113, 221, 99, 169, 67, 131, 200, 203, 49, 252, 162, 15, 189, 27, 202, 123, 127, 131, 78, 66, 24, 125, 99, 6, 95, 216, 252, 137, 81, 58, 76, 214, 89, 255, 0, 96, 131, 239, 70, 242, 158, 222, 225, 117, 88, 215, 3, 226, 126, 226, 27, 134, 159, 174, 208, 92, 52, 91, 163, 22, 186, 176, 138, 115, 42, 83, 12, 39, 17, 181, 40, 114, 35, 28, 75, 31, 236, 16, 125, 232, 222, 38, 222, 192, 133, 192, 143, 114, 171, 30, 236, 183, 227, 1, 99, 191, 176, 149, 217, 101, 42, 225, 229, 229, 1, 85, 37, 205, 18, 143, 45, 52, 170, 32, 251, 209, 41, 237, 219, 142, 111, 84, 40, 149, 238, 226, 150, 170, 98, 32, 81, 237, 6, 35, 105, 66, 183, 80, 233, 51, 139, 91, 224, 228, 75, 33, 252, 130, 15, 189, 18, 158, 221, 162, 28, 1, 42, 220, 5, 18, 173, 209, 138, 77, 70, 148, 211, 164, 123, 128, 144, 114, 37, 208, 21, 105, 75, 53, 197, 95, 191, 167, 183, 105, 32, 9, 94, 227, 18, 173, 98, 76, 99, 153, 107, 75, 26, 251, 223, 24, 130, 159, 77, 111, 191, 167, 183, 49, 9, 196, 173, 91, 2, 86, 171, 147, 25, 165, 21, 235, 104, 139, 129, 143, 124, 166, 95, 63, 127, 75, 110, 202, 181, 49, 43, 214, 201, 133, 137, 48, 203, 53, 201, 240, 250, 39, 78, 108, 112, 37, 213, 92, 71, 124, 192, 97, 50, 200, 105, 225, 244, 79, 33, 43, 190, 4, 184, 124, 152, 79, 59, 63, 199, 195, 233, 29, 121, 29, 4, 187, 169, 42, 62, 79, 101, 145, 211, 195, 208, 224, 197, 143, 180, 188, 110, 219, 22, 240, 241, 41, 153, 91, 241, 151, 71, 88, 123, 44, 219, 15, 7, 135, 209, 50, 177, 244, 203, 163, 175, 109, 22, 195, 196, 245, 32, 62, 31, 72, 224, 202, 223, 140, 186, 62, 168, 59, 20, 224, 206, 30, 225, 211, 17, 208, 169, 240, 224, 112, 99, 28, 164, 189, 30, 169, 241, 219, 195, 171, 244, 180, 100, 21, 23, 49, 148, 143, 111, 30, 6, 27, 76, 75, 225, 172, 207, 109, 26, 133, 26, 88, 215, 14, 152, 142, 128, 198, 166, 71, 176, 1, 48, 46, 35, 31, 4, 191, 95, 153, 158, 195, 203, 134, 221, 116, 176, 6, 43, 6, 16, 129, 26, 144, 48, 210, 51, 160, 206, 131, 58, 12, 253, 51, 2, 64, 35, 183, 130, 220, 210, 235, 89, 80, 20, 108, 119, 83, 169, 208, 115, 56, 109, 224, 113, 136, 227, 26, 207, 142, 246, 108, 66, 115, 224, 215, 182, 153, 245, 8, 70, 15, 117, 157, 193, 164, 217, 150, 215, 107, 89, 123, 201, 140, 217, 240, 118, 80, 70, 12, 187, 179, 233, 245, 8, 119, 228, 79, 101, 149, 225, 164, 101, 181, 216, 170, 59, 78, 68, 102, 207, 132, 178, 134, 24, 50, 238, 199, 30, 165, 132, 16, 117, 133, 135, 35, 51, 164, 201, 6, 91, 222, 181, 57, 105, 196, 213, 180, 104, 149, 81, 181, 16, 182, 99, 28, 70, 168, 79, 133, 144, 12, 186, 176, 15, 170, 202, 180, 26, 153, 214, 3, 14, 179, 110, 106, 253, 59, 74, 55, 245, 16, 203, 75, 183, 169, 11, 146, 60, 58, 181, 178, 85, 18, 230, 193, 233, 234, 33, 210, 111, 49, 54, 139, 73, 156, 233, 44, 248, 105, 58, 188, 165, 69, 105, 140, 15, 16, 101, 12, 48, 101, 199, 13, 71, 213, 101, 197, 165, 74, 81, 67, 147, 140, 74, 28, 57, 234, 239, 45, 236, 146, 144, 128, 120, 155, 83, 86, 222, 45, 165, 37, 57, 196, 10, 6, 223, 250, 11, 255, 0, 255, 196, 0, 43, 17, 0, 1, 4, 1, 2, 5, 4, 3, 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 2, 3, 17, 4, 16, 49, 5, 18, 32, 33, 96, 19, 34, 48, 80, 20, 50, 65, 81, 97, 160, 176, 255, 218, 0, 8, 1, 3, 1, 1, 63, 0, 255, 0, 188, 185, 112, 70, 86, 132, 103, 11, 242, 2, 252, 132, 114, 10, 245, 156, 189, 103, 175, 93, 235, 242, 28, 191, 36, 161, 148, 134, 67, 74, 18, 52, 171, 30, 10, 92, 2, 116, 237, 106, 118, 82, 57, 46, 43, 213, 37, 115, 30, 155, 10, 194, 177, 167, 40, 70, 48, 81, 101, 43, 33, 9, 72, 77, 152, 161, 50, 15, 7, 192, 9, 160, 164, 201, 55, 65, 62, 82, 85, 223, 198, 53, 7, 74, 69, 138, 144, 64, 166, 185, 53, 223, 124, 253, 147, 191, 101, 95, 32, 232, 8, 104, 66, 164, 16, 76, 223, 239, 159, 178, 127, 237, 240, 87, 192, 52, 5, 90, 181, 90, 4, 207, 190, 126, 201, 255, 0, 183, 192, 45, 90, 13, 209, 152, 207, 122, 24, 165, 187, 175, 68, 33, 8, 94, 147, 87, 162, 17, 132, 35, 21, 34, 218, 87, 160, 76, 251, 231, 236, 159, 251, 124, 28, 201, 141, 47, 217, 65, 195, 229, 144, 166, 112, 216, 226, 22, 245, 44, 204, 29, 152, 17, 113, 61, 101, 128, 167, 71, 74, 144, 76, 223, 239, 157, 178, 147, 246, 61, 64, 233, 143, 136, 233, 157, 75, 15, 131, 6, 119, 42, 103, 195, 136, 207, 249, 89, 25, 78, 153, 223, 27, 217, 163, 62, 249, 219, 41, 63, 99, 211, 186, 229, 255, 0, 22, 7, 13, 116, 198, 202, 196, 225, 172, 128, 89, 89, 19, 54, 54, 90, 202, 200, 116, 206, 249, 92, 218, 81, 239, 247, 199, 101, 47, 238, 81, 232, 99, 44, 246, 92, 51, 134, 58, 87, 89, 80, 99, 179, 29, 189, 147, 164, 46, 11, 137, 100, 217, 228, 31, 49, 22, 154, 40, 253, 252, 226, 157, 163, 116, 22, 77, 46, 21, 195, 204, 143, 183, 40, 97, 100, 13, 160, 139, 173, 100, 75, 200, 194, 84, 175, 47, 113, 39, 231, 174, 255, 0, 127, 148, 61, 218, 176, 210, 193, 197, 51, 61, 97, 226, 182, 22, 4, 227, 106, 215, 19, 150, 153, 94, 31, 150, 61, 218, 4, 25, 206, 104, 46, 11, 130, 24, 206, 98, 164, 52, 185, 187, 33, 238, 92, 85, 222, 234, 240, 252, 208, 155, 178, 11, 134, 99, 250, 178, 5, 11, 61, 54, 0, 17, 55, 166, 203, 137, 155, 127, 135, 229, 182, 218, 130, 11, 128, 99, 255, 0, 74, 115, 168, 82, 189, 10, 226, 77, 247, 95, 135, 206, 45, 139, 250, 161, 109, 188, 5, 194, 225, 17, 196, 19, 187, 158, 142, 38, 206, 215, 225, 238, 22, 20, 173, 167, 44, 65, 114, 5, 140, 42, 32, 134, 232, 157, 114, 153, 204, 196, 225, 71, 195, 242, 153, 70, 215, 15, 23, 32, 81, 246, 140, 34, 175, 75, 82, 11, 106, 201, 142, 157, 225, 249, 44, 182, 174, 31, 218, 80, 129, 246, 4, 118, 67, 83, 178, 201, 141, 57, 180, 124, 57, 194, 197, 40, 7, 36, 192, 40, 205, 198, 17, 61, 57, 45, 176, 157, 31, 55, 100, 246, 22, 159, 140, 179, 148, 89, 240, 51, 29, 60, 57, 97, 203, 205, 16, 69, 94, 161, 60, 115, 39, 183, 149, 200, 196, 36, 82, 227, 22, 124, 12, 133, 207, 217, 69, 140, 214, 11, 114, 200, 127, 51, 168, 120, 39, 13, 127, 106, 79, 61, 144, 232, 10, 118, 218, 97, 165, 65, 201, 248, 205, 114, 126, 35, 134, 200, 227, 189, 122, 47, 67, 29, 231, 248, 155, 134, 242, 163, 194, 104, 221, 53, 129, 163, 178, 202, 154, 133, 120, 46, 52, 188, 142, 76, 33, 205, 190, 167, 11, 79, 20, 84, 103, 182, 148, 169, 6, 4, 26, 21, 45, 202, 158, 79, 77, 170, 71, 151, 155, 240, 108, 76, 170, 246, 148, 13, 244, 148, 90, 8, 70, 193, 77, 61, 149, 244, 189, 225, 130, 202, 200, 156, 200, 124, 28, 26, 54, 177, 178, 239, 218, 80, 54, 53, 181, 122, 57, 168, 18, 19, 93, 104, 106, 94, 27, 186, 201, 200, 231, 52, 60, 36, 18, 13, 133, 141, 151, 252, 114, 105, 14, 23, 161, 208, 34, 139, 85, 210, 107, 144, 70, 64, 193, 221, 100, 228, 243, 154, 30, 25, 6, 81, 103, 98, 153, 32, 114, 189, 111, 74, 91, 39, 207, 200, 165, 156, 191, 195, 163, 149, 204, 81, 100, 181, 195, 186, 14, 7, 160, 188, 5, 46, 71, 248, 156, 226, 237, 252, 64, 26, 81, 228, 22, 238, 163, 156, 57, 23, 132, 252, 128, 19, 230, 46, 241, 64, 72, 70, 71, 31, 253, 6, 63, 255, 217 } },
                    { 3, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4029), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4035), 2, "Putujte Pametnije, Putujte S Nama", "DreamTravel Agency", "DreamTravel vam donosi nevjerojatne aranžmane i popuste na putovanja širom svijeta. Rezervirajte svoje snove još danas!", null },
                    { 4, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4042), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4049), 2, "Inovacije Koje Mijenjaju Život", "TechNova Innovations", "TechNova donosi vam najnovije tehnološke inovacije koje olakšavaju svakodnevni život. Budite dio budućnosti već danas!", null }
                });

            migrationBuilder.InsertData(
                table: "Voznje",
                columns: new[] { "Id", "Cijena", "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka", "DogadjajId", "GradDoId", "GradOdId", "KlijentId", "KuponId", "Napomena", "StateMachine", "VozacId" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTime(2025, 2, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 1, null, null, "Draft vožnja za Vozac 1.", "draft", 1 },
                    { 2, 20.0, new DateTime(2025, 2, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 3, 2, null, null, "Active vožnja za Vozac 1.", "active", 1 },
                    { 4, 30.0, new DateTime(2025, 2, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 5, 4, 2, null, "InProgress vožnja za Vozac 1.", "inprogress", 1 },
                    { 6, 0.0, new DateTime(2025, 2, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 1, null, null, "Draft vožnja za Vozac 2.", "draft", 2 },
                    { 7, 15.0, new DateTime(2025, 2, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 2, null, null, "Active vožnja za Vozac 2.", "active", 2 },
                    { 8, 15.0, new DateTime(2025, 2, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, 2, 1, null, "booked vožnja za Vozac 2.", "booked", 2 },
                    { 9, 15.0, new DateTime(2025, 2, 25, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(636), new DateTime(2025, 2, 26, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(590), new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(630), 1, 3, 2, 1, null, "inprogress vožnja za Vozac 2.", "inprogress", 2 },
                    { 10, 15.0, new DateTime(2025, 2, 25, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(660), new DateTime(2025, 2, 26, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(646), new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(653), 3, 3, 2, 1, null, "completed vožnja za Vozac 2.", "completed", 2 }
                });

            migrationBuilder.InsertData(
                table: "VrstaZalbe",
                columns: new[] { "Id", "DatumIzmjene", "KorisnikId", "Naziv" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1363), 1, "Na vožnju" },
                    { 2, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1423), 1, "Na vozača" },
                    { 3, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1432), 1, "Na aplikaciju" },
                    { 4, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1439), 1, "Ostalo" }
                });

            migrationBuilder.InsertData(
                table: "Recenzije",
                columns: new[] { "Id", "DatumKreiranja", "Komentar", "KorisnikId", "Ocjena", "VoznjaId" },
                values: new object[] { 1, new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(889), "Odlična vožnja, prezadovoljan sam vozačem.", 1, 5, 10 });

            migrationBuilder.InsertData(
                table: "Voznje",
                columns: new[] { "Id", "Cijena", "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka", "DogadjajId", "GradDoId", "GradOdId", "KlijentId", "KuponId", "Napomena", "StateMachine", "VozacId" },
                values: new object[,]
                {
                    { 3, 25.0, new DateTime(2025, 2, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), null, null, 4, 3, 2, 1, "Booked vožnja za Vozac 1.", "booked", 1 },
                    { 5, 40.0, new DateTime(2025, 2, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, 2, 2, "Completed vožnja za Vozac 1.", "completed", 1 }
                });

            migrationBuilder.InsertData(
                table: "Zalbe",
                columns: new[] { "Id", "AdministratorId", "DatumIzmjene", "DatumKreiranja", "DatumPreuzimanja", "KorisnikId", "Naslov", "OdgovorNaZalbu", "Sadrzaj", "StateMachine", "VrstaZalbeId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1736), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1744), null, 1, "Problem prilikom prijave", null, "Prilikom pokušaja prijave na aplikaciju, ne mogu da se prijavim iako unosim ispravne podatke.", "active", 3 },
                    { 2, null, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1756), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1762), null, 1, "Vozač ne uzvraća poruke", null, "Potrebno je da dogovorim lokaciju polaska sa vozačem vožnje ID: 2 ali ne mogu da dobijem povratnu informaciju od vozača.", "active", 2 },
                    { 3, null, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1770), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1777), null, 1, "Vožnja nije bila do navedene lokacije", null, "Vožnja je naznačena da je do Sarajeva, a vozili smo se do Kaknja, molim za povrat novca.", "active", 1 },
                    { 4, null, new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1785), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1791), null, 1, "Neiskoristiv kupon", null, "Naznačeno je da koristimo kupon 'WELCOME', ali on ne radi.", "active", 4 }
                });

            migrationBuilder.InsertData(
                table: "Recenzije",
                columns: new[] { "Id", "DatumKreiranja", "Komentar", "KorisnikId", "Ocjena", "VoznjaId" },
                values: new object[] { 2, new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(900), "Okej vožnja, nisam zadivljen posebno, ali stigli smo relativno brzo..", 2, 3, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_RecieverId",
                table: "ChatMessages",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_KorisnikId",
                table: "FAQs",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciDostignuca_DostignuceId",
                table: "KorisniciDostignuca",
                column: "DostignuceId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciDostignuca_KorisnikId",
                table: "KorisniciDostignuca",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikId",
                table: "KorisniciUloge",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaId",
                table: "KorisniciUloge",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kuponi_KorisnikId",
                table: "Kuponi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavjestenja_KorisnikId",
                table: "Obavjestenja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_KorisnikId",
                table: "Recenzije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_VoznjaId",
                table: "Recenzije",
                column: "VoznjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reklame_KorisnikId",
                table: "Reklame",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_DogadjajId",
                table: "Voznje",
                column: "DogadjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_GradDoId",
                table: "Voznje",
                column: "GradDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_GradOdId",
                table: "Voznje",
                column: "GradOdId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_KlijentId",
                table: "Voznje",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_KuponId",
                table: "Voznje",
                column: "KuponId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_VozacId",
                table: "Voznje",
                column: "VozacId");

            migrationBuilder.CreateIndex(
                name: "IX_VrstaZalbe_KorisnikId",
                table: "VrstaZalbe",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_AdministratorId",
                table: "Zalbe",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_KorisnikId",
                table: "Zalbe",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalbe_VrstaZalbeId",
                table: "Zalbe",
                column: "VrstaZalbeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "KorisniciDostignuca");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Obavjestenja");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Reklame");

            migrationBuilder.DropTable(
                name: "Zalbe");

            migrationBuilder.DropTable(
                name: "Dostignuca");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Voznje");

            migrationBuilder.DropTable(
                name: "VrstaZalbe");

            migrationBuilder.DropTable(
                name: "Dogadjaji");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Kuponi");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
