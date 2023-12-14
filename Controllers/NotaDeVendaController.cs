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
    public class NotaDeVendaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public NotaDeVendaController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/NotaDeVenda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaDeVenda>>> GetNotaDeVenda()
        {
            return await _context.NotaDeVenda.ToListAsync();
        }

        // GET: api/NotaDeVenda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaDeVenda>> GetNotaDeVenda(int id)
        {
            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);

            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return notaDeVenda;
        }

        // PUT: api/NotaDeVenda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaDeVenda(int id, NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.Id)
            {
                return BadRequest();
            }

            _context.Entry(notaDeVenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaDeVendaExists(id))
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

        // POST: api/NotaDeVenda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotaDeVenda>> PostNotaDeVenda(NotaDeVenda notaDeVenda)
        {
            _context.NotaDeVenda.Add(notaDeVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaDeVenda", new { id = notaDeVenda.Id }, notaDeVenda);
        }

        // DELETE: api/NotaDeVenda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaDeVenda(int id)
        {
            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            _context.NotaDeVenda.Remove(notaDeVenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotaDeVenda.Any(e => e.Id == id);
        }
    }
}
