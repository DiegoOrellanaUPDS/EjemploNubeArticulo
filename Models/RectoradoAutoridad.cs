using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class RectoradoAutoridad
    {
        public int Id { get; set; } // Llave primaria

        // Propiedad 1: Nombre de la autoridad
        public string NombreCompleto { get; set; } = string.Empty;

        // Propiedad 2: Cargo (Rector, Vicerrector, Secretario General)
        public string Cargo { get; set; } = string.Empty;

        // Propiedad 3: Grado académico (PhD, Magíster, Licenciado)
        public string TituloAcademico { get; set; } = string.Empty;

        // Propiedad 4: Correo de contacto
        public string EmailInstitucional { get; set; } = string.Empty;

        // Propiedad 5: Desde cuándo ocupa el cargo
        public DateTime FechaInicioGestion { get; set; }
    }
}