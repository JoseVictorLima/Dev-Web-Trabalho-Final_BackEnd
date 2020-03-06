using System.Collections.Generic;
namespace DevWebBackEnd.Models{
    public class Usuario{
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Imagem{get;set;}
        public List<Receita> Receitas{get;set;}
    }
}