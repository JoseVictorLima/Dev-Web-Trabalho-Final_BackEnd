using Microsoft.EntityFrameworkCore;
namespace DevWebBackEnd.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)         
            :base(options)         
        {   
        }
        public DbSet<Usuario> Usuarios {get; set;}  
        public DbSet<Receita> Receitas {get; set;}   
        public DbSet<Igrediente> Igredientes {get; set;}
        // public DbSet<Novo> Novos {get; set;}
        // public DbSet<Top3> Top3 {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)         
        {             optionsBuilder.UseSqlite("Data Source=DevWebBackend.db");         
        }    
        
    }
}