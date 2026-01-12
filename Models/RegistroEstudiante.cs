using System;
using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class RegistroEstudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string CodigoEstudiante { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Carrera { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Range(1, 10)]
        public decimal PromedioCalificaciones { get; set; }

        public bool Activo { get; set; } = true;
    }
}
