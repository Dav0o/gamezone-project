namespace api_gamezone.Entities
{
    public class Juego
    {
        public int Id { get; set; }          //PK
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public decimal Precio { get; set; }   // → DECIMAL(18,2)
        public bool Disponible { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    }
}
