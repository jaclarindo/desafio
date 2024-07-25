namespace Application.DTOs.AlterarPedido;

public class AlterarPedidoRequestDto : PedidoRequestDto
{
    public int IdPedido { get; set; }
    public bool Pago { get; set; }
}
