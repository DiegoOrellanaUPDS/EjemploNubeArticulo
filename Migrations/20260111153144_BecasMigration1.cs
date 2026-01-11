using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace simple.Migrations
{
    /// <inheritdoc />
    public partial class BecasMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "ContabilidadFacturas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BecasEstudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCompleto = table.Column<string>(type: "text", nullable: false),
                    CodigoEstudiante = table.Column<string>(type: "text", nullable: false),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    MontoMensualBeca = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaInicioBeca = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BecaActiva = table.Column<bool>(type: "boolean", nullable: false),
                    TipoBeca = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BecasEstudiantes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BecasEstudiantes");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "ContabilidadFacturas");
        }
    }
}
