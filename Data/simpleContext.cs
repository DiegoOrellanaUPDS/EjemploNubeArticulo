using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simple.Entidades;
using simple.Models;

namespace simple.Data
{
    public class simpleContext : DbContext
    {
        public simpleContext(DbContextOptions<simpleContext> options)
            : base(options)
        {
        }

        public DbSet<SistemasAlumno> SistemasAlumnos { get; set; } = default!;

        public DbSet<Articulo> Articulo { get; set; } = default!;
        public DbSet<RegistroEstudiante> RegistroEstudiantes { get; set; }
        public DbSet<BibliotecaLibro> BibliotecaLibros { get; set; } = default!;
        public DbSet<ContabilidadFactura> ContabilidadFacturas { get; set; } = default!;
        public DbSet<SecretariaGeneralDocumento> SecretariaGeneralDocumentos { get; set; } = default!;
        public DbSet<BecasEstudiante> BecasEstudiantes { get; set; } = default!;
        public DbSet<ArchivosArchivo> ArchivosArchivos { get; set; } = default!;
        public DbSet<ModalidadGrado> ModalidadesGrado { get; set; } = default!;
        public DbSet<RectoradoAutoridad> RectoradoAutoridades { get; set; }= default!;
        public DbSet<ProduccionContenido> ProduccionContenidos { get; set; } = default!;
        public DbSet<ContabilidadUsuario> ContabilidadUsuarios { get; set; } = default!;
        public DbSet<ConsistenciaArchivo> ConsistenciaArchivos { get; set; } = default!;
        public DbSet<CajaFactura> CajaFacturas { get; set; } = default!;

        //Para valores de fechas en Postgres

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Recorre todas las entidades y propiedades DateTime
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    // Si la propiedad es DateTime o DateTime?
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("date"); // Se guarda como "date" en PostgreSQL
                    }
                }
            }
        }
    }
} 
