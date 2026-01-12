using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace simple.Migrations
{
    /// <inheritdoc />
    public partial class ConsisteciaArchivos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsistenciaArchivos",
                columns: table => new
                {
                    Id_Archivo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Fecha_Creacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsistenciaArchivos", x => x.Id_Archivo);
                });

            migrationBuilder.CreateTable(
                name: "ContabilidadUsuarios",
                columns: table => new
                {
                    CON_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CON_Nombre = table.Column<string>(type: "text", nullable: false),
                    CON_Email = table.Column<string>(type: "text", nullable: false),
                    CON_Rol = table.Column<string>(type: "text", nullable: false),
                    CON_FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CON_Departamento = table.Column<string>(type: "text", nullable: false),
                    CON_Telefono = table.Column<string>(type: "text", nullable: false),
                    CON_Activo = table.Column<bool>(type: "boolean", nullable: false),
                    CON_Salario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContabilidadUsuarios", x => x.CON_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsistenciaArchivos");

            migrationBuilder.DropTable(
                name: "ContabilidadUsuarios");
        }
    }
}
