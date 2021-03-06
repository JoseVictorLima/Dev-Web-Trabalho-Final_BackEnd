using System;
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
    public async Task<ActionResult<IEnumerable<Object>>> GetReceitas()
    {
        var receitaList = await _context.Receitas.ToListAsync();
        Object[] newReceitaList = new Object[receitaList.Count];
        Usuario usuario = new Usuario();
        int i = 0;
        foreach(var receita in receitaList){
            // Receita newReceita = new Receita();
            // usuario  = await _context.Usuarios.FindAsync(receita.UsuarioId);
            var json = new {
                Id = receita.Id,
                Nome = receita.Nome,
                Imagem = receita.Imagem,
                Rendimento = receita.Rendimento,
                Tempo = receita.Tempo,
                Pontuacao = receita.Pontuacao,
                UsuarioId = receita.UsuarioId,
            };
            newReceitaList[i] = json;
            i++;
        }
        return newReceitaList;
    }

    // GET with id: 
    [HttpGet("{id}")]
    public async Task<ActionResult<Object>> GetReceita(int id)
    {
        var igredienteList = _context.Igredientes
            .Where(o => o.ReceitaId == id) 
            .Distinct() 
            .ToList();

        var receita = await _context.Receitas.FindAsync(id);

        if (receita == null || igredienteList == null)
        {
            return NotFound();
        }
        Object[] newIgredienteList = new Object[igredienteList.Count];
        int i = 0;
        foreach(var igrediente in igredienteList){
            var json = new {
                Id = igrediente.Id,
                Unidade = igrediente.Unidade,
                Label = igrediente.Label,
                Value = igrediente.Value,
            };
            newIgredienteList[i] = json;
            i++;
        }
        var newReceita = new {
            Id = receita.Id,
            DataCriacao = receita.DataCriacao,
            Nome = receita.Nome,
            Imagem = receita.Imagem,
            Rendimento = receita.Rendimento,
            Tempo = receita.Tempo,
            Preparo = receita.Preparo,
            Pontuacao = receita.Pontuacao,
            Igredientes = newIgredienteList,
            UsuarioId = receita.UsuarioId,
        };

        return newReceita;
    }

    // POST: 
    [HttpPost]
    public async Task<ActionResult<Receita>> PostReceita(Receita item)
    {
        item.DataCriacao = DateTime.Now;
        _context.Receitas.Add(item);
        if(item.Igredientes.Count>0){
            foreach(var igrediente in item.Igredientes){
                _context.Igredientes.Add(igrediente);
            }
        }
        await _context.SaveChangesAsync();
        var json = new{
            Id = item.Id,
            Nome = item.Nome,
            Imagem = item.Imagem,
            Rendimento = item.Rendimento,
            Tempo = item.Tempo,
            Preparo = item.Preparo,
            Pontuacao = item.Pontuacao,
            DataCriacao = item.DataCriacao,
            UsuarioId = item.UsuarioId,
        };
        return CreatedAtAction(nameof(GetReceitas), new { id = item.Id }, json);
    }

    // PUT: 
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReceita(int id, Receita item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }
        if(item.Igredientes.Count>0){
            foreach(var igrediente in item.Igredientes){
                _context.Igredientes.Update(igrediente);
            }
        }
        _context.Receitas.Update(item);
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
        var igredienteList = _context.Igredientes
            .Where(o => o.ReceitaId == id) 
            .Distinct() 
            .ToList();
        if(igredienteList.Count>0){
            foreach(var igrediente in igredienteList){
                _context.Igredientes.Remove(igrediente);
            }
        }
        _context.Receitas.Remove(receita);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
}