using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PedidoRepository : IPedidoRepository
{
    protected readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> Adicionar(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        return pedido;
    }

    public async Task Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
    }

    public async Task<Pedido?> ObterPorId(int id)
    {
        return await _context.Pedidos
            .Include(x => x.Itens)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistePedidoPorId(int id)     
    {
        return await _context.Pedidos.AsNoTracking().AnyAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Pedido>> ObterTodos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido> Remover(Pedido pedido)
    {
        _context.Pedidos.Remove(pedido);
        return pedido;
    }

    public async Task<Produto?> ObterProdutoPorId(int id)
    {
        var result = await _context.Produtos.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        return result;
    }
}
