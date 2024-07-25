namespace Domain.Commands.Pedidos.Adicionar;

public class PedidoCommand
{
    public int IdPedido { get; set; }

    public PedidoCommand()
    {
    }

    public PedidoCommand(int idPedido)
    {
        IdPedido = idPedido;
    }
}
