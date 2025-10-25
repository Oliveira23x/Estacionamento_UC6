using CadastroDeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.Data
{
    internal class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        { 
            
        
        }
        public DbSet<Usuario> Usuario { get; set; } 
        public DbSet<Produtos> Produtos { get; set; }   

    }

  
}
