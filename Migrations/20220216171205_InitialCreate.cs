using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicosDB",
                columns: table => new
                {
                    MedicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosDB", x => x.MedicoID);
                });

            migrationBuilder.CreateTable(
                name: "PacientesDB",
                columns: table => new
                {
                    PacienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesDB", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaDB",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoID = table.Column<int>(type: "int", nullable: false),
                    PacienteID = table.Column<int>(type: "int", nullable: false),
                    HorarioStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFinish = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaDB", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_ConsultaDB_MedicosDB_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "MedicosDB",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultaDB_PacientesDB_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "PacientesDB",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedicosDB",
                columns: new[] { "MedicoID", "MedicoName" },
                values: new object[,]
                {
                    { 1, "Rogerio" },
                    { 2, "Carlos" },
                    { 3, "Alberto" }
                });

            migrationBuilder.InsertData(
                table: "PacientesDB",
                columns: new[] { "PacienteID", "PacienteName" },
                values: new object[,]
                {
                    { 1, "Carla" },
                    { 2, "Rosana" },
                    { 3, "Maria" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_MedicoID",
                table: "ConsultaDB",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_PacienteID",
                table: "ConsultaDB",
                column: "PacienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaDB");

            migrationBuilder.DropTable(
                name: "MedicosDB");

            migrationBuilder.DropTable(
                name: "PacientesDB");
        }
    }
}
