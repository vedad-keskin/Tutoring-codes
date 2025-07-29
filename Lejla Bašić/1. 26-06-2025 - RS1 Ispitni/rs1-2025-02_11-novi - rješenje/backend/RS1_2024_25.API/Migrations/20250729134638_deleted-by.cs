using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class deletedby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeletedById",
                table: "Students",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MyAppUsers_DeletedById",
                table: "Students",
                column: "DeletedById",
                principalTable: "MyAppUsers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_MyAppUsers_DeletedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeletedById",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Students");
        }
    }
}
