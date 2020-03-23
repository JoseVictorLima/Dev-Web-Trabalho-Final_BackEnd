using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/novos")]
    [ApiController]
    public class Novo : ControllerBase
    {
        private readonly Context _context;
        public Novo(Context context)
        {
            _context = context;
        }
    // Get: 
    [HttpGet]
    public async Task<ActionResult<Object>> GetNovos()
    {
        var novos = Task.Run( () => 
            _context.Receitas.OrderByDescending(p => p.DataCriacao)
            .Distinct() 
            // .Take(1)
            // .Take(2)
            // .Take(3)
            .ToList()
            
        );
        var resp = await novos;
        Object[] newList = new Object[3];
        if(resp==null){
            return NotFound();
        } else{
            int i = 0;
            foreach(var top in resp){
                if(i==3) break;
                newList[i] = top;
                i++;
            }
            // newList[0] = resp1[0];
            // newList[1] = resp2[0];
            // newList[2] = resp3[0];
            return newList;
        }
        // Console.WriteLine(usuario);
        // return myTask;
        // if(usuario.Count==0){
        //     return new {
        //         Token = "Invalid",
        //         Response = "Authentication Error"
        //     };
        // }else{
        //     return new {
        //         Usuario = usuario,
        //         Token = "1000",
        //         Response = "Authentication Success"
        //     };
        // }
        // await _context.SaveChangesAsync();
        // return CreatedAtAction(nameof(GetIgredientes), new { id = item.Id }, item);
        // return primeiroTop3;
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