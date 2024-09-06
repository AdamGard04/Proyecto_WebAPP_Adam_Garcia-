namespace WebPrestamoFront1.Models
{
    public class ClienteView
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Email { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Direccion { get; set; }
        public string? HistorialCrediticio { get; set; }
    }
}
