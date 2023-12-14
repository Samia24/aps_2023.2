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
    public class PagamentoComCartaoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PagamentoComCartaoController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/PagamentoComCartao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoComCartao>>> GetPagamentoComCartao()
        {
            return await _context.PagamentoComCartao.ToListAsync();
        }

        // GET: api/PagamentoComCartao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoComCartao>> GetPagamentoComCartao(int id)
        {
            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);

            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            return pagamentoComCartao;
        }

        // PUT: api/PagamentoComCartao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamentoComCartao(int id, PagamentoComCartao pagamentoComCartao)
        {
            if (id != pagamentoComCartao.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamentoComCartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoComCartaoExists(id))
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

        // POST: api/PagamentoComCartao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PagamentoComCartao>> PostPagamentoComCartao(PagamentoComCartao pagamentoComCartao)
        {
            _context.PagamentoComCartao.Add(pagamentoComCartao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamentoComCartao", new { id = pagamentoComCartao.Id }, pagamentoComCartao);
        }

        // DELETE: api/PagamentoComCartao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentoComCartao(int id)
        {
            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            _context.PagamentoComCartao.Remove(pagamentoComCartao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoComCartaoExists(int id)
        {
            return _context.PagamentoComCartao.Any(e => e.Id == id);
        }
    }
}
