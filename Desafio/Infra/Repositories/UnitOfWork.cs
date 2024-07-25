using Domain.Interfaces;
using Infra.Context;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

[ExcludeFromCodeCoverage]
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    private PedidoRepository? _pedidoRepository;
    
    public IPedidoRepository PedidoRepository => _pedidoRepository ??= new PedidoRepository(_context);

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task RollbackAsync()
    {
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
