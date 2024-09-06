using System;
using System.Collections.Generic;

namespace WebPrestamoBack.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Email { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Direccion { get; set; }
        public string? HistorialCrediticio { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
