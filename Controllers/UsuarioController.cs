using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _context;
        public UsuarioController(Context context)
        {
            _context = context;
        }

    // GET: 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // GET with id: 
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    // POST: 
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario item)
    {
        _context.Usuarios.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuarios), new { id = item.Id }, item);
    }

    // PUT: 
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario item)
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
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}