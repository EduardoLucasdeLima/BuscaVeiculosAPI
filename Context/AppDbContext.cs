using BuscaVeiculosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaVeiculosAPI.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Veiculo>? Veiculos { get; set; }
}
