using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightClub.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_IdUserWorker",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_IdUserWorker",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IdUserWorker",
                table: "Workers");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdUser",
                table: "Workers",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_IdUser",
                table: "Workers",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_IdUser",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_IdUser",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "IdUserWorker",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdUserWorker",
                table: "Workers",
                column: "IdUserWorker");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_IdUserWorker",
                table: "Workers",
                column: "IdUserWorker",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
