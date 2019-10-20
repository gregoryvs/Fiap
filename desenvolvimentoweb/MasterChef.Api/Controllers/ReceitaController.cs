using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterChef.Api.Models;

namespace MasterChef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public ReceitaController(ReceitaContext context)
        {
            _context = context;
        }

        // GET: api/Receita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceita()
        {
            return await _context.Receita.ToListAsync();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(long id)
        {
            var receita = await _context.Receita.FindAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(long id, Receita receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }
             receita.DataDeCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        {
            receita.DataDeCadastro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            _context.Receita.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }

        // DELETE: api/Receita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receita>> DeleteReceita(long id)
        {
            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();

            return receita;
        }

        private bool ReceitaExists(long id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}
