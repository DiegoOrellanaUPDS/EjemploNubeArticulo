using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple.Entidades
{
    [Table("ExtunivTalleres")]
    public class ExtunivTaller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        [StringLength(100)]
        public string Facilitador { get; set; }

        [Required]
        public int HorasTotales { get; set; }

        [Required]
        [StringLength(50)]
        public string Modalidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }

        [Required]
        public int CupoMaximo { get; set; }

        public int InscritosActuales { get; set; } = 0;

        [Required]
        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; }
    }
}