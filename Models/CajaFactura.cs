using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class CajaFactura
    {
        [Key]
        public int Id { get; set; } = -1;
        public string NumeroFactura { get; set; } = null!;
        public DateTime FechaFactura { get; set; }
        public decimal SubTotal { get; set; } = 0;
        public decimal Impuesto { get; set; } = 0;
        public decimal Total { get; set; } = -1;
        //public int UsuarioId { get; set; } = -1; //FK de Usuario, sin utilizar hasta que "Usuario" exista
        public string Observaciones { get; set; } = "";
        public bool Estado { get; set; } = true;
    }
}
