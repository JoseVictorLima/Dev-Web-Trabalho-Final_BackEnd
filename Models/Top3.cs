using System.ComponentModel.DataAnnotations.Schema;
namespace DevWebBackEnd.Models{
    public class Top3{
        public int Id{get;set;}
        [ForeignKey("Receita")]
        public int ReceitaId{get;set;}
        public Receita Receita{get;set;}

    }
}