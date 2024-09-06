using System;
using System.Collections.Generic;

namespace WebPrestamoBack.Model
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            Pagos = new HashSet<Pago>();
        }

        public int PrestamoId { get; set; }
        public int? ClienteId { get; set; }
        public string? TipoPrestamo { get; set; }
        public decimal? MontoSolicitado { get; set; }
        public int? Plazo { get; set; }
        public decimal? TasaInteres { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaSolicitud { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
