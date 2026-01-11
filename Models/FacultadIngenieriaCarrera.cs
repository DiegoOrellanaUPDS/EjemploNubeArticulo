using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class FacultadIngenieriaCarrera
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modalidad { get; set; }
        public int Semestres { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}