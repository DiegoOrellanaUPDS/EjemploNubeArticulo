using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class SistemasEquipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public bool EnMantenimiento { get; set; }

        public int AnioCompra { get; set; } // Evita usar 'ñ' en nombres de variables
    }
}