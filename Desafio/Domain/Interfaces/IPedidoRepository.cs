using Domain.Entities;

namespace Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido> ObterPorId(int id);
    Task<IEnumerable<Pedido>> ObterTodos();
    Task<Pedido> Adicionar(Pedido pedido);
    Task Atualizar(Pedido pedido);
    Task<Pedido> Remover(Pedido pedido);
    Task<Produto?> ObterProdutoPorId(int id);
    Task<bool> ExistePedidoPorId(int id);
}
