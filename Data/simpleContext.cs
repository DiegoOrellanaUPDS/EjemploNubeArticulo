<<<<<<< HEAD
using EjemploNubeArticulo.Models;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 11ee6010fb6a713065f7df63c1be1f98b3c78ddf
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

        
        public DbSet<Articulo> Articulo { get; set; } = default!;
        public DbSet<BibliotecaLibro> BibliotecaLibros { get; set; } = default!;
        public DbSet<ContabilidadFactura> ContabilidadFacturas { get; set; } = default!;
        public DbSet<SecretariaGeneralDocumento> SecretariaGeneralDocumentos { get; set; } = default!;
        public DbSet<BecasEstudiante> BecasEstudiantes { get; set; } = default!;
<<<<<<< HEAD
=======

        public DbSet<RectoradoAutoridad> RectoradoAutoridades { get; set; }= default!;



>>>>>>> 11ee6010fb6a713065f7df63c1be1f98b3c78ddf
        public DbSet<ProduccionContenido> ProduccionContenidos { get; set; } = default!;

        public DbSet<ProduccionContenido> ProduccionContenido { get; set; } = default!;
        public DbSet<ContabilidadUsuario> ContabilidadUsuarios { get; set; } = default!;
        public DbSet<ConsistenciaArchivo> ConsistenciaArchivos { get; set; } = default!;
<<<<<<< HEAD
=======



>>>>>>> 11ee6010fb6a713065f7df63c1be1f98b3c78ddf
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
<<<<<<< HEAD
=======

>>>>>>> 11ee6010fb6a713065f7df63c1be1f98b3c78ddf
    }
}

