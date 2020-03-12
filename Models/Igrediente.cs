namespace DevWebBackEnd.Models{
    public class Igrediente{

        public int Id{get;set;}
        public string Label{get;set;}
        public string Value{get;set;}
        public int? ReceitaId{get;set;}
        public virtual Receita Receita{get;set;}
    }
}