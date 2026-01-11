using System;
using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class ModalidadGrado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int DuracionMeses { get; set; }
        public bool RequiereTesis { get; set; }
        public decimal Costo { get; set; }
    }
}
