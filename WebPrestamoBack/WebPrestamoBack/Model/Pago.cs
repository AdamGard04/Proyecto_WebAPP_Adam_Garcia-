using System;
using System.Collections.Generic;

namespace WebPrestamoBack.Model
{
    public partial class Pago
    {
        public int PagoId { get; set; }
        public int? PrestamoId { get; set; }
        public decimal? MontoPago { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal? CapitalAmortizado { get; set; }
        public decimal? Intereses { get; set; }
        public decimal? Comisiones { get; set; }

        public virtual Prestamo? Prestamo { get; set; }
    }
}
