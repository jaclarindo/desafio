namespace Application.DTOs;

public class PedidoRequestDto
{
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ItemRequestDto> Itens { get; set; }
}
