using System;
using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class SistemasAlumno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Carrera { get; set; }

        public int Semestre { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
