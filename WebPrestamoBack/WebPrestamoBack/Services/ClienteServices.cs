using Microsoft.EntityFrameworkCore;
using WebPrestamoBack.Dto;
using WebPrestamoBack.Model;

namespace WebPrestamoBack.Services
{
    public class ClienteServices
    {
        private readonly prestamosContext _context;
         public ClienteServices(prestamosContext context)
        {
            _context = context;
        }

        public async Task<ClienteDto> CreateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Email = clienteDto.Email,
                NumeroTelefono = clienteDto.NumeroTelefono,
                Direccion = clienteDto.Direccion,
                HistorialCrediticio = clienteDto.HistorialCrediticio
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return clienteDto;
        }

        // Read - Obtener todos los clientes
        public async Task<List<ClienteDto>> GetClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes.Select(c => new ClienteDto
            {
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Email = c.Email,
                NumeroTelefono = c.NumeroTelefono,
                Direccion = c.Direccion,
                HistorialCrediticio = c.HistorialCrediticio
            }).ToList();
        }

        public async Task<ClienteDto?> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                NumeroTelefono = cliente.NumeroTelefono,
                Direccion = cliente.Direccion,
                HistorialCrediticio = cliente.HistorialCrediticio
            };
        }
        public async Task<bool> UpdateClienteAsync(int id, ClienteDto clienteDto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }

            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Email = clienteDto.Email;
            cliente.NumeroTelefono = clienteDto.NumeroTelefono;
            cliente.Direccion = clienteDto.Direccion;
            cliente.HistorialCrediticio = clienteDto.HistorialCrediticio;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete - Eliminar cliente
        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
