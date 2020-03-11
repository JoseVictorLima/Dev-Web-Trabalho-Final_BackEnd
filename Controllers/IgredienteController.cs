using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/igredientes")]
    [ApiController]
    public class IgredienteController : ControllerBase
    {
        private readonly Context _context;
        public IgredienteController(Context context)
        {
            _context = context;
        }

    // GET: 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Igrediente>>> GetIgredientes()
    {
        return await _context.Igredientes.ToListAsync();
    }

    // GET with id: 
    [HttpGet("{id}")]
    public async Task<ActionResult<Igrediente>> GetIgrediente(int id)
    {
        var receita = await _context.Igredientes.FindAsync(id);

        if (receita == null)
        {
            return NotFound();
        }

        return receita;
    }

    // POST: 
    [HttpPost]
    public async Task<ActionResult<Igrediente>> PostIgrediente(Igrediente item)
    {
        _context.Igredientes.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIgredientes), new { id = item.Id }, item);
    }

    // PUT: 
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIgrediente(int id, Igrediente item)
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
    public async Task<IActionResult> DeleteIgrediente(int id)
    {
        var receita = await _context.Igredientes.FindAsync(id);

        if (receita == null)
        {
            return NotFound();
        }

        _context.Igredientes.Remove(receita);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}