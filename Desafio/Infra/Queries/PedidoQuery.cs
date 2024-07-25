using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Queries;

public class PedidoQuery : IPedidoQuery
{
    private readonly ApplicationDbContext _context;

    public PedidoQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    /*
    public async Task<PedidoResponseDto> ObterPorId(int id)
    {
        var query = await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Produto)
            .Select(x => new PedidoResponseDto
            {
                Id = x.Id,
                NomeCliente = x.NomeCliente,
                EmailCliente = x.EmailCliente,
                Pago = x.Pago,
                ValorTotal = x.Itens.Sum(i => i.Produto.Valor * i.Quantidade),
                ItensPedido = x.Itens.Select(i => new ItemResponseDto
                {
                    Id = i.Id,
                    IdProduto = i.Produto.Id,
                    NomeProduto = i.Produto.Nome,
                    ValorUnitario = i.Produto.Valor,
                    Quantidade = i.Quantidade
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);

        return query;
    }

    public async Task<IEnumerable<PedidoResponseDto>> ObterTodos()
    {
        var query = await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Produto)
            .Select(x => new PedidoResponseDto
            {
                Id = x.Id,
                NomeCliente = x.NomeCliente,
                EmailCliente = x.EmailCliente,
                Pago = x.Pago,
                ValorTotal = x.Itens.Sum(i => i.Produto.Valor * i.Quantidade),
                ItensPedido = x.Itens.Select(i => new ItemResponseDto
                {
                    Id = i.Id,
                    IdProduto = i.Produto.Id,
                    NomeProduto = i.Produto.Nome,
                    ValorUnitario = i.Produto.Valor,
                    Quantidade = i.Quantidade
                }).ToList()
            }).ToListAsync();

        return query;
    }
    */

    public async Task<PedidoResponseDto> ObterPorId(int id)
    {
        var pedido = await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Produto)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pedido == null)
        {
            return null;
        }

        return MapToPedidoResponseDto(pedido);
    }

    public async Task<IEnumerable<PedidoResponseDto>> ObterTodos()
    {
        var pedidos = await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Produto)
            .ToListAsync();

        return pedidos.Select(MapToPedidoResponseDto).ToList();
    }

    private static PedidoResponseDto MapToPedidoResponseDto(Pedido pedido)
    {
        return new PedidoResponseDto
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            EmailCliente = pedido.EmailCliente,
            Pago = pedido.Pago,
            ValorTotal = pedido.Itens.Sum(i => i.Produto.Valor * i.Quantidade),
            ItensPedido = pedido.Itens.Select(i => new ItemResponseDto
            {
                Id = i.Id,
                IdProduto = i.Produto.Id,
                NomeProduto = i.Produto.Nome,
                ValorUnitario = i.Produto.Valor,
                Quantidade = i.Quantidade
            }).ToList()
        };
    }
}
