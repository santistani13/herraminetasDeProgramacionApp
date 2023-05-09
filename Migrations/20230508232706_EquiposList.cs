using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquiposDeFutbol.Migrations
{
    /// <inheritdoc />
    public partial class EquiposList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Equipo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_EquipoId",
                table: "Equipo",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Equipo_EquipoId",
                table: "Equipo",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Equipo_EquipoId",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_EquipoId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Equipo");
        }
    }
}
