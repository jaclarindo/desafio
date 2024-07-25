using Domain.Commands.Pedidos.Adicionar;
using Domain.Shared;
using MediatR;

namespace Domain.Commands.Pedidos;

public class AdicionarAlterarCommand<T> : IRequest<Response<PedidoCommand>>
{
    public int IdPedido { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ItemCommand> Itens { get; set; }
    public bool Pago { get; set; } = false;

    public AdicionarAlterarCommand()
    {
    }
}
