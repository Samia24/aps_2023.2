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
    public class TipoDePagamentoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TipoDePagamentoController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoDePagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDePagamento>>> GetTipoDePagamento()
        {
            return await _context.TipoDePagamento.ToListAsync();
        }

        // GET: api/TipoDePagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDePagamento>> GetTipoDePagamento(int id)
        {
            var tipoDePagamento = await _context.TipoDePagamento.FindAsync(id);

            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            return tipoDePagamento;
        }

        // PUT: api/TipoDePagamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDePagamento(int id, TipoDePagamento tipoDePagamento)
        {
            if (id != tipoDePagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoDePagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDePagamentoExists(id))
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

        // POST: api/TipoDePagamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDePagamento>> PostTipoDePagamento(TipoDePagamento tipoDePagamento)
        {
            _context.TipoDePagamento.Add(tipoDePagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDePagamento", new { id = tipoDePagamento.Id }, tipoDePagamento);
        }

        // DELETE: api/TipoDePagamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDePagamento(int id)
        {
            var tipoDePagamento = await _context.TipoDePagamento.FindAsync(id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            _context.TipoDePagamento.Remove(tipoDePagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDePagamentoExists(int id)
        {
            return _context.TipoDePagamento.Any(e => e.Id == id);
        }
    }
}
