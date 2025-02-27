﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPrestamoBack.Model;

namespace WebPrestamoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly prestamosContext _context;

        public PrestamoController(prestamosContext context)
        {
            _context = context;
        }

        // GET: api/Prestamo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
          if (_context.Prestamos == null)
          {
              return NotFound();
          }
            return await _context.Prestamos.ToListAsync();
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
          if (_context.Prestamos == null)
          {
              return NotFound();
          }
            var prestamo = await _context.Prestamos.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // PUT: api/Prestamo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.PrestamoId)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Prestamo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
          if (_context.Prestamos == null)
          {
              return Problem("Entity set 'prestamosContext.Prestamos'  is null.");
          }
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrestamo", new { id = prestamo.PrestamoId }, prestamo);
        }

        // DELETE: api/Prestamo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            if (_context.Prestamos == null)
            {
                return NotFound();
            }
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestamoExists(int id)
        {
            return (_context.Prestamos?.Any(e => e.PrestamoId == id)).GetValueOrDefault();
        }
    }
}
