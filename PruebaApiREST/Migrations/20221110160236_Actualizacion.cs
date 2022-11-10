using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaApiREST.Migrations
{
    public partial class Actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "Usuarios",
                newName: "Oficina");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "Oficina",
                table: "Usuarios",
                newName: "Ubicacion");
        }
    }
}
