using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentieTurism.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statiuni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statiuni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    NumarCI = table.Column<string>(nullable: true),
                    SerieCI = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    NrTel = table.Column<string>(nullable: true),
                    PerioadaSejurDoritaStart = table.Column<DateTime>(nullable: true),
                    PerioadaSejurDoritaSfarsit = table.Column<DateTime>(nullable: true),
                    StatiuneDoritaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clienti_Statiuni_StatiuneDoritaId",
                        column: x => x.StatiuneDoritaId,
                        principalTable: "Statiuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sejururi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStart = table.Column<DateTime>(nullable: false),
                    DataSfarsit = table.Column<DateTime>(nullable: false),
                    StatiuneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sejururi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sejururi_Statiuni_StatiuneId",
                        column: x => x.StatiuneId,
                        principalTable: "Statiuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_StatiuneDoritaId",
                table: "Clienti",
                column: "StatiuneDoritaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sejururi_StatiuneId",
                table: "Sejururi",
                column: "StatiuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Sejururi");

            migrationBuilder.DropTable(
                name: "Statiuni");
        }
    }
}
