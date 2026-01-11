using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class BecasEstudiante
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string CodigoEstudiante { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public decimal MontoMensualBeca { get; set; }
        public DateTime FechaInicioBeca { get; set; }
        public bool BecaActiva { get; set; }
        public string TipoBeca { get; set; } = string.Empty;
    }
}