using Domain.Commands.Pedidos.Adicionar;
using Domain.Shared;
using MediatR;

namespace Domain.Commands.Pedidos.Excluir;

public class ExcluirPedidoCommand : IRequest<Response<PedidoCommand>>
{
    public int IdPedido { get; set; }

    public ExcluirPedidoCommand(int idPedido)
    {        
        IdPedido = idPedido;
    }
}
