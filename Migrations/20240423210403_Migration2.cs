using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightClub.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Clients_IdClient1",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "IdClient1",
                table: "Tickets",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_IdClient1",
                table: "Tickets",
                newName: "IX_Tickets_IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Clients_IdClient",
                table: "Tickets",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Clients_IdClient",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Tickets",
                newName: "IdClient1");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_IdClient",
                table: "Tickets",
                newName: "IX_Tickets_IdClient1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Clients_IdClient1",
                table: "Tickets",
                column: "IdClient1",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
