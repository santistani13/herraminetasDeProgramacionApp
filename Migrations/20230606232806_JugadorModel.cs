using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquiposDeFutbol.Migrations
{
    /// <inheritdoc />
    public partial class JugadorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "EquipoJugador",
                columns: table => new
                {
                    EquiposId = table.Column<int>(type: "INTEGER", nullable: false),
                    JugadoresJugadorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoJugador", x => new { x.EquiposId, x.JugadoresJugadorId });
                    table.ForeignKey(
                        name: "FK_EquipoJugador_Equipo_EquiposId",
                        column: x => x.EquiposId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipoJugador_Jugador_JugadoresJugadorId",
                        column: x => x.JugadoresJugadorId,
                        principalTable: "Jugador",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipoJugador_JugadoresJugadorId",
                table: "EquipoJugador",
                column: "JugadoresJugadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipoJugador");

            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
