using Microsoft.EntityFrameworkCore;
using VeiculosApp.Models; // << Certifique-se que o namespace está correto

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Veiculos> Veiculo { get; set; }
}