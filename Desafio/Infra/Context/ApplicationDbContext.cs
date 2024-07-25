using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ItensPedido> ItensPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
