using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevWebBackEnd.Models{
    public class Receita{
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Imagem{get;set;}
        public string Rendimento{get;set;}
        public string Tempo{get;set;}
        public string Preparo{get;set;}
        public int Pontuacao{get;set;}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString  = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao{get;set;}
        public List<Igrediente> Igredientes{get;set;}
        [ForeignKey("Usuario")]
        public int UsuarioId{get;set;}
        public virtual Usuario Usuario{get;set;}
    }
}