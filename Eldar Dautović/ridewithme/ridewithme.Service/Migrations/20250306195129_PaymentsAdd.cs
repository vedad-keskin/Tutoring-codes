using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ridewithme.Service.Migrations
{
    /// <inheritdoc />
    public partial class PaymentsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoznjaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1471), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1468) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1477), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1481), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1484), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1349), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1351) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1361), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1362) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1364), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1367), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1370), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1371) });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 504, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumKreiranja",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 504, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "KorisniciDostignuca",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 504, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 504, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Kuponi",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumPocetka" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9126), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "Kuponi",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumPocetka" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9134), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9135) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9215), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9216), new DateTime(2025, 3, 8, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9217) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9221), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9223), new DateTime(2025, 3, 6, 22, 51, 29, 505, DateTimeKind.Local).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9226), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9227), new DateTime(2025, 3, 7, 1, 51, 29, 505, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "Recenzije",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "Recenzije",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumKreiranja",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9262), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9431), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9580), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9581) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9583), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cijena",
                value: 25.0);

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 6,
                column: "Cijena",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka" },
                values: new object[] { new DateTime(2025, 3, 4, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5917), new DateTime(2025, 3, 5, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5902), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka" },
                values: new object[] { new DateTime(2025, 3, 4, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5923), new DateTime(2025, 3, 5, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5920), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(5921) });

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9166), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9172), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9175), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9178), new DateTime(2025, 3, 6, 20, 51, 29, 505, DateTimeKind.Local).AddTicks(9179) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4733), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4725) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4755), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4749) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4770), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "Dogadjaji",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4785), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4779) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4368), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4376) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4386), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4399), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4413), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4427), new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 480, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumKreiranja",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 480, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "KorisniciDostignuca",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 482, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 481, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "KorisniciUloge",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 481, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Kuponi",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumPocetka" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1614), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Kuponi",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumPocetka" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1629), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1905), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1912), new DateTime(2025, 3, 1, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1933), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1939), new DateTime(2025, 2, 27, 12, 0, 42, 485, DateTimeKind.Local).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Obavjestenja",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja", "DatumZavrsetka" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1954), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1960), new DateTime(2025, 2, 27, 15, 0, 42, 485, DateTimeKind.Local).AddTicks(1965) });

            migrationBuilder.UpdateData(
                table: "Recenzije",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumKreiranja",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Recenzije",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumKreiranja",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(2065), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(3020), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(3027) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4029), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4035) });

            migrationBuilder.UpdateData(
                table: "Reklame",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4042), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cijena",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 6,
                column: "Cijena",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka" },
                values: new object[] { new DateTime(2025, 2, 25, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(636), new DateTime(2025, 2, 26, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(590), new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(630) });

            migrationBuilder.UpdateData(
                table: "Voznje",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DatumKreiranja", "DatumVrijemePocetka", "DatumVrijemeZavrsetka" },
                values: new object[] { new DateTime(2025, 2, 25, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(660), new DateTime(2025, 2, 26, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(646), new DateTime(2025, 2, 27, 10, 0, 42, 484, DateTimeKind.Local).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "VrstaZalbe",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1736), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1756), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1770), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Zalbe",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatumIzmjene", "DatumKreiranja" },
                values: new object[] { new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1785), new DateTime(2025, 2, 27, 10, 0, 42, 485, DateTimeKind.Local).AddTicks(1791) });
        }
    }
}
