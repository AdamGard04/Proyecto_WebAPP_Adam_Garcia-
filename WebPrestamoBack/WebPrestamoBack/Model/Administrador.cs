using System;
using System.Collections.Generic;

namespace WebPrestamoBack.Model
{
    public partial class Administrador
    {
        public int AdministradorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Email { get; set; }
        public string? Rol { get; set; }
    }
}
