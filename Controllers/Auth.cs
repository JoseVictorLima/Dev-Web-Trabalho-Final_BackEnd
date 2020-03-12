using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly Context _context;
        public Auth(Context context)
        {
            _context = context;
        }
    // POST: 
    [HttpPost]
    public async Task<ActionResult<Object>> Authentication(Usuario user)
    {
        var myTask = Task.Run( () => 
            _context.Usuarios
            .Where(o => o.Nome == user.Nome && o.Senha==user.Senha) 
            .Distinct() 
            .ToList()
        );
        // var usuario =  _context.Usuarios
        //     .Where(o => o.Nome == user.Nome && o.Senha==user.Senha) 
        //     .Distinct() 
        //     .ToList();
        // return usuario;
        var usuario = await myTask;
        // Console.WriteLine(usuario);
        // return myTask;
        if(usuario.Count==0){
            return new {
                Token = "Invalid",
                Response = "Authentication Error"
            };
        }else{
            return new {
                Token = "1000",
                Response = "Authentication Success"
            };
        }
        // await _context.SaveChangesAsync();
        // return CreatedAtAction(nameof(GetIgredientes), new { id = item.Id }, item);
    }
    // GET: 
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Igrediente>>> GetIgredientes()
    // {
    //     return await _context.Igredientes.ToListAsync();
    // }

    // GET with id: 
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Igrediente>> GetIgrediente(int id)
    // {
    //     var receita = await _context.Igredientes.FindAsync(id);

    //     if (receita == null)
    //     {
    //         return NotFound();
    //     }

    //     return receita;
    // }
    }
}