using System.ComponentModel.DataAnnotations;

namespace simple.Entidades
{
    public class BibliotecaLibro
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }
        public bool Disponible { get; set; }
    }
}
