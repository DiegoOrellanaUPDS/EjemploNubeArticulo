using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class ContabilidadFactura
    {
        [Key]
        public int Id { get; set; }

        public string NumeroFactura { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public decimal MontoTotal { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public bool Pagada { get; set; }
    }
}