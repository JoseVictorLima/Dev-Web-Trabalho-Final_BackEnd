using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevWebBackEnd.Models;

namespace DevWebBackEnd.Controllers
{
    [Route("api/top3")]
    [ApiController]
    public class Top3 : ControllerBase
    {
        private readonly Context _context;
        public Top3(Context context)
        {
            _context = context;
        }
    // Get: 
    [HttpGet]
    public async Task<ActionResult<Object>> GetTop3()
    {
            // .Where(o => o.Nome == user.Nome && o.Senha==user.Senha) 
        var top1 = Task.Run( () => 
            _context.Receitas.OrderByDescending(p => p.Pontuacao)
            .Distinct() 
            // .Take(1)
            // .Take(2)
            // .Take(3)
            .ToList()
        );
        // var top2 = Task.Run( () => 
        //     _context.Receitas.OrderByDescending(p => p.Pontuacao)
        //     .Distinct() 
        //     .Take(2)
        //     .ToList()
        // );
        // var top3 = Task.Run( () => 
        //     _context.Receitas.OrderByDescending(p => p.Pontuacao)
        //     .Distinct() 
        //     .Take(3)
        //     .ToList()
        // );
        // var usuario =  _context.Usuarios
        //     .Where(o => o.Nome == user.Nome && o.Senha==user.Senha) 
        //     .Distinct() 
        //     .ToList();
        // return usuario;
        var resp = await top1;
        // if(resp1!=null){
            
        // }
        // var resp2 = await top2;
        // if(resp2!=null){
        // }
        // var resp3 = await top3;
        // return resp;
        Object[] newList = new Object[3];
        // && resp2.Count==0 && resp3.Count==0
        if(resp.Count==0 ){
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