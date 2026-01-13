using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace simple.Migrations
{
    /// <inheritdoc />
    public partial class ArchivosMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "Encargado",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "FechaPublicacion",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "ProduccionContenidos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEmision",
                table: "SecretariaGeneralDocumentos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "ProduccionContenidos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuracionMinutos",
                table: "ProduccionContenidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EsPublicado",
                table: "ProduccionContenidos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ProduccionContenidos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TipoFormato",
                table: "ProduccionContenidos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEmision",
                table: "ContabilidadFacturas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioBeca",
                table: "BecasEstudiantes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "ArchivosArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    TipoDocumento = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosArchivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CajaFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroFactura = table.Column<string>(type: "text", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "date", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Impuesto = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaFacturas", x => x.Id);
                });

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
                    CON_FechaRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    CON_Departamento = table.Column<string>(type: "text", nullable: false),
                    CON_Telefono = table.Column<string>(type: "text", nullable: false),
                    CON_Activo = table.Column<bool>(type: "boolean", nullable: false),
                    CON_Salario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContabilidadUsuarios", x => x.CON_Id);
                });

            migrationBuilder.CreateTable(
                name: "RectoradoAutoridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCompleto = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    TituloAcademico = table.Column<string>(type: "text", nullable: false),
                    EmailInstitucional = table.Column<string>(type: "text", nullable: false),
                    FechaInicioGestion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RectoradoAutoridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroEstudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCompleto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CodigoEstudiante = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Carrera = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    PromedioCalificaciones = table.Column<decimal>(type: "numeric", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEstudiantes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosArchivos");

            migrationBuilder.DropTable(
                name: "CajaFacturas");

            migrationBuilder.DropTable(
                name: "ConsistenciaArchivos");

            migrationBuilder.DropTable(
                name: "ContabilidadUsuarios");

            migrationBuilder.DropTable(
                name: "RectoradoAutoridades");

            migrationBuilder.DropTable(
                name: "RegistroEstudiantes");

            migrationBuilder.DropColumn(
                name: "DuracionMinutos",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "EsPublicado",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ProduccionContenidos");

            migrationBuilder.DropColumn(
                name: "TipoFormato",
                table: "ProduccionContenidos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEmision",
                table: "SecretariaGeneralDocumentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "ProduccionContenidos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ProduccionContenidos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Encargado",
                table: "ProduccionContenidos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPublicacion",
                table: "ProduccionContenidos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "ProduccionContenidos",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEmision",
                table: "ContabilidadFacturas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicioBeca",
                table: "BecasEstudiantes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
