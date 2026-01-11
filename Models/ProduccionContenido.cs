using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple.Models
{
    public class ProduccionContenido
    {
        public int Id {get;set;}
        public string? Titulo {get; set;}
        public string? Descripcion {get; set;}
        public string? Plataforma {get;set;}
        public DateTime FechaPublicacion {get;set;}
        public string? Encargado {get;set;}
    }
}