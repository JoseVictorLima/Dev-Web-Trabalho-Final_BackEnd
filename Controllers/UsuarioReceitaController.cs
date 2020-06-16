using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/usuario-receita")]
    [ApiController]
    public class UsuarioReceita : ControllerBase
    {
        private readonly Context _context;
        public UsuarioReceita(Context context)
        {
            _context = context;
        }
    // Get: 
    [HttpGet("{id}")]
    public async Task<ActionResult<Object>> GetReceitaByUsuario(int id)
    {

        var receitaList = _context.Receitas
            .Where(o => o.UsuarioId == id) 
            .Distinct() 
            .ToList();

        var usuario = await _context.Usuarios.FindAsync(id);

        if (receitaList == null || usuario== null)
        {
            return NotFound();
        }

        return receitaList;
    }
    }
}