namespace simple.Entidades
{
    public class SecretariaGeneralDocumento
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Responsable { get; set; }
        public bool Vigente { get; set; }
    }
}
