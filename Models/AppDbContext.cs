using Microsoft.EntityFrameworkCore;

namespace dealforgeApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // public DbSet<Produto> Produtos => Set<Produto>();
}