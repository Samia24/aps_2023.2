#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samiabraga.Models;

namespace samiabraga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadoraController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TransportadoraController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Transportadora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transportadora>>> GetTransportadora()
        {
            return await _context.Transportadora.ToListAsync();
        }

        // GET: api/Transportadora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transportadora>> GetTransportadora(int id)
        {
            var transportadora = await _context.Transportadora.FindAsync(id);

            if (transportadora == null)
            {
                return NotFound();
            }

            return transportadora;
        }

        // PUT: api/Transportadora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportadora(int id, Transportadora transportadora)
        {
            if (id != transportadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportadoraExists(id))
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

        // POST: api/Transportadora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transportadora>> PostTransportadora(Transportadora transportadora)
        {
            _context.Transportadora.Add(transportadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportadora", new { id = transportadora.Id }, transportadora);
        }

        // DELETE: api/Transportadora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportadora(int id)
        {
            var transportadora = await _context.Transportadora.FindAsync(id);
            if (transportadora == null)
            {
                return NotFound();
            }

            _context.Transportadora.Remove(transportadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransportadoraExists(int id)
        {
            return _context.Transportadora.Any(e => e.Id == id);
        }
    }
}
