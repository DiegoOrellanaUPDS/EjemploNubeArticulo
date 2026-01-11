using System.ComponentModel.DataAnnotations;

namespace simple.Models
{
    public class ProduccionContenido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        public string TipoFormato { get; set; } = string.Empty; // Ej: Video, Podcast

        public int DuracionMinutos { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public bool EsPublicado { get; set; }
    }
}