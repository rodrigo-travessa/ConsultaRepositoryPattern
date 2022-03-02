using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Migrations
{
    public partial class RepoPattern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDB_MedicosDB_MedicoID",
                table: "ConsultaDB");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDB_PacientesDB_PacienteID",
                table: "ConsultaDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacientesDB",
                table: "PacientesDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicosDB",
                table: "MedicosDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultaDB",
                table: "ConsultaDB");

            migrationBuilder.RenameTable(
                name: "PacientesDB",
                newName: "Pacientes");

            migrationBuilder.RenameTable(
                name: "MedicosDB",
                newName: "Medicos");

            migrationBuilder.RenameTable(
                name: "ConsultaDB",
                newName: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteName",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "PacienteID",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MedicoName",
                table: "Medicos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "MedicoID",
                table: "Medicos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdConsulta",
                table: "Consultas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDB_PacienteID",
                table: "Consultas",
                newName: "IX_Consultas_PacienteID");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDB_MedicoID",
                table: "Consultas",
                newName: "IX_Consultas_MedicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoID",
                table: "Consultas",
                column: "MedicoID",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteID",
                table: "Consultas",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoID",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteID",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicos",
                table: "Medicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "PacientesDB");

            migrationBuilder.RenameTable(
                name: "Medicos",
                newName: "MedicosDB");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "ConsultaDB");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PacientesDB",
                newName: "PacienteName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PacientesDB",
                newName: "PacienteID");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MedicosDB",
                newName: "MedicoName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MedicosDB",
                newName: "MedicoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConsultaDB",
                newName: "IdConsulta");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteID",
                table: "ConsultaDB",
                newName: "IX_ConsultaDB_PacienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_MedicoID",
                table: "ConsultaDB",
                newName: "IX_ConsultaDB_MedicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacientesDB",
                table: "PacientesDB",
                column: "PacienteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicosDB",
                table: "MedicosDB",
                column: "MedicoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultaDB",
                table: "ConsultaDB",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDB_MedicosDB_MedicoID",
                table: "ConsultaDB",
                column: "MedicoID",
                principalTable: "MedicosDB",
                principalColumn: "MedicoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDB_PacientesDB_PacienteID",
                table: "ConsultaDB",
                column: "PacienteID",
                principalTable: "PacientesDB",
                principalColumn: "PacienteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
