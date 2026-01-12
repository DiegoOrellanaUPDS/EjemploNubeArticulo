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

        
        public DbSet<Articulo> Articulo { get; set; } = default!;
        public DbSet<BibliotecaLibro> BibliotecaLibros { get; set; } = default!;
        public DbSet<ContabilidadFactura> ContabilidadFacturas { get; set; } = default!;
        public DbSet<SecretariaGeneralDocumento> SecretariaGeneralDocumentos { get; set; } = default!;
        public DbSet<BecasEstudiante> BecasEstudiantes { get; set; } = default!;

        public DbSet<RectoradoAutoridad> RectoradoAutoridades { get; set; }
        public DbSet<ProduccionContenido> ProduccionContenidos { get; set; } = default!;
    }
}

