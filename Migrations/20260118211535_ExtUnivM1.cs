using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace simple.Migrations
{
    /// <inheritdoc />
    public partial class ExtUnivM1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtunivTalleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    Facilitador = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HorasTotales = table.Column<int>(type: "integer", nullable: false),
                    Modalidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CupoMaximo = table.Column<int>(type: "integer", nullable: false),
                    InscritosActuales = table.Column<int>(type: "integer", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtunivTalleres", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtunivTalleres");
        }
    }
}
