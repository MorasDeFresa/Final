using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NightClub.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEvent = table.Column<DateOnly>(type: "date", nullable: false),
                    MaximumClientCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "HealthcareProviders",
                columns: table => new
                {
                    IdHealthcareProvider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameHealthcareProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneEmergency = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcareProviders", x => x.IdHealthcareProvider);
                });

            migrationBuilder.CreateTable(
                name: "StatusWorkers",
                columns: table => new
                {
                    IdStatusWorker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusWorkers", x => x.IdStatusWorker);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocuments",
                columns: table => new
                {
                    IdTypeDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeDocument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocuments", x => x.IdTypeDocument);
                });

            migrationBuilder.CreateTable(
                name: "TypeMoneys",
                columns: table => new
                {
                    IdTypeMoney = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeMoney = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMoneys", x => x.IdTypeMoney);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurnameUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTypeDocument = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_TypeDocuments_IdTypeDocument",
                        column: x => x.IdTypeDocument,
                        principalTable: "TypeDocuments",
                        principalColumn: "IdTypeDocument",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypesWorkers",
                columns: table => new
                {
                    IdTypesWorker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeWorker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryForHour = table.Column<float>(type: "real", nullable: false),
                    idTypeMoney = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesWorkers", x => x.IdTypesWorker);
                    table.ForeignKey(
                        name: "FK_TypesWorkers_TypeMoneys_idTypeMoney",
                        column: x => x.idTypeMoney,
                        principalTable: "TypeMoneys",
                        principalColumn: "IdTypeMoney",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    EmailClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordClient = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHealthcareProviders = table.Column<int>(type: "int", nullable: false),
                    IdTypesWorker = table.Column<int>(type: "int", nullable: false),
                    IdStatusWorker = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IdWorker);
                    table.ForeignKey(
                        name: "FK_Workers_HealthcareProviders_IdHealthcareProviders",
                        column: x => x.IdHealthcareProviders,
                        principalTable: "HealthcareProviders",
                        principalColumn: "IdHealthcareProvider",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_StatusWorkers_IdStatusWorker",
                        column: x => x.IdStatusWorker,
                        principalTable: "StatusWorkers",
                        principalColumn: "IdStatusWorker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_TypesWorkers_IdTypesWorker",
                        column: x => x.IdTypesWorker,
                        principalTable: "TypesWorkers",
                        principalColumn: "IdTypesWorker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryClientVisitss",
                columns: table => new
                {
                    IdClientVisits = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateJoin = table.Column<TimeOnly>(type: "time", nullable: false),
                    DateOut = table.Column<TimeOnly>(type: "time", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryClientVisitss", x => x.IdClientVisits);
                    table.ForeignKey(
                        name: "FK_HistoryClientVisitss_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryClientVisitss_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient1 = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Clients_IdClient1",
                        column: x => x.IdClient1,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesWorkers",
                columns: table => new
                {
                    IdSchedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    DateEndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    IdWorker = table.Column<int>(type: "int", nullable: false),
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesWorkers", x => x.IdSchedule);
                    table.ForeignKey(
                        name: "FK_SchedulesWorkers_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulesWorkers_Workers_IdWorker",
                        column: x => x.IdWorker,
                        principalTable: "Workers",
                        principalColumn: "IdWorker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdUser",
                table: "Clients",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryClientVisitss_IdClient",
                table: "HistoryClientVisitss",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryClientVisitss_IdEvent",
                table: "HistoryClientVisitss",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesWorkers_IdEvent",
                table: "SchedulesWorkers",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesWorkers_IdWorker",
                table: "SchedulesWorkers",
                column: "IdWorker");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdClient1",
                table: "Tickets",
                column: "IdClient1");

            migrationBuilder.CreateIndex(
                name: "IX_TypesWorkers_idTypeMoney",
                table: "TypesWorkers",
                column: "idTypeMoney");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdTypeDocument",
                table: "Users",
                column: "IdTypeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdHealthcareProviders",
                table: "Workers",
                column: "IdHealthcareProviders");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdStatusWorker",
                table: "Workers",
                column: "IdStatusWorker");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_IdTypesWorker",
                table: "Workers",
                column: "IdTypesWorker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryClientVisitss");

            migrationBuilder.DropTable(
                name: "SchedulesWorkers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "HealthcareProviders");

            migrationBuilder.DropTable(
                name: "StatusWorkers");

            migrationBuilder.DropTable(
                name: "TypesWorkers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TypeMoneys");

            migrationBuilder.DropTable(
                name: "TypeDocuments");
        }
    }
}
