using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/receitas")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly Context _context;
        public ReceitaController(Context context)
        {
            _context = context;
        }

    // GET: 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
    {
        return await _context.Receitas.ToListAsync();
    }

    // GET with id: 
    [HttpGet("{id}")]
    public async Task<ActionResult<Receita>> GetReceita(int id)
    {
        var receita = await _context.Receitas.FindAsync(id);

        if (receita == null)
        {
            return NotFound();
        }

        return receita;
    }

    // POST: 
    [HttpPost]
    public async Task<ActionResult<Receita>> PostReceita(Receita item)
    {
        _context.Receitas.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReceitas), new { id = item.Id }, item);
    }

    // PUT: 
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReceita(int id, Receita item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE with id:
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceita(int id)
    {
        var receita = await _context.Receitas.FindAsync(id);

        if (receita == null)
        {
            return NotFound();
        }

        _context.Receitas.Remove(receita);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}