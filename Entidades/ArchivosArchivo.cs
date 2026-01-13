namespace simple.Entidades
{
    public class ArchivosArchivo
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
