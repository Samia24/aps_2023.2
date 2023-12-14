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
    public class PagamentoComChequeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PagamentoComChequeController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/PagamentoComCheque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoComCheque>>> GetPagamentoComCheque()
        {
            return await _context.PagamentoComCheque.ToListAsync();
        }

        // GET: api/PagamentoComCheque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoComCheque>> GetPagamentoComCheque(int id)
        {
            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);

            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return pagamentoComCheque;
        }

        // PUT: api/PagamentoComCheque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamentoComCheque(int id, PagamentoComCheque pagamentoComCheque)
        {
            if (id != pagamentoComCheque.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamentoComCheque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoComChequeExists(id))
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

        // POST: api/PagamentoComCheque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PagamentoComCheque>> PostPagamentoComCheque(PagamentoComCheque pagamentoComCheque)
        {
            _context.PagamentoComCheque.Add(pagamentoComCheque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamentoComCheque", new { id = pagamentoComCheque.Id }, pagamentoComCheque);
        }

        // DELETE: api/PagamentoComCheque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentoComCheque(int id)
        {
            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            _context.PagamentoComCheque.Remove(pagamentoComCheque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoComChequeExists(int id)
        {
            return _context.PagamentoComCheque.Any(e => e.Id == id);
        }
    }
}
