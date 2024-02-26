using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Class_Library.Models;
using Tickets_Detalles.API.DAL;

namespace Tickets_Detalles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsDetalleController : ControllerBase
    {
        private readonly Contexto _context;

        public TicketsDetalleController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TicketsDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketsDetalle>>> GetTicketsDetalle()
        {
            return await _context.TicketsDetalle.ToListAsync();
        }

        // GET: api/TicketsDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketsDetalle>> GetTicketsDetalle(int id)
        {
            var ticketsDetalle = await _context.TicketsDetalle.FindAsync(id);

            if (ticketsDetalle == null)
            {
                return NotFound();
            }

            return ticketsDetalle;
        }

        // PUT: api/TicketsDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketsDetalle(int id, TicketsDetalle ticketsDetalle)
        {
            if (id != ticketsDetalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(ticketsDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsDetalleExists(id))
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

        // POST: api/TicketsDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketsDetalle>> PostTicketsDetalle(TicketsDetalle ticketsDetalle)
        {
            _context.TicketsDetalle.Add(ticketsDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketsDetalle", new { id = ticketsDetalle.DetalleId }, ticketsDetalle);
        }

        // DELETE: api/TicketsDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketsDetalle(int id)
        {
            var ticketsDetalle = await _context.TicketsDetalle.FindAsync(id);
            if (ticketsDetalle == null)
            {
                return NotFound();
            }

            _context.TicketsDetalle.Remove(ticketsDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool TicketsDetalleExists(int id)
        {
            return _context.TicketsDetalle.Any(e => e.DetalleId == id);
        }

    }
}
