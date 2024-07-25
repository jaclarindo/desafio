using Application.DTOs;
using Application.DTOs.AlterarPedido;
using Domain.Commands.Pedidos.Adicionar;
using Domain.Shared;

namespace Application.Interfaces;

public interface IPedidoService
{
    Task<Response<PedidoCommand>>? AdicionarPedidoAsync(PedidoRequestDto pedidoRequest);
    Task<PedidoResponseDto> ObterPedidoAsync(int idPedido);
    Task<IEnumerable<PedidoResponseDto>> ObterPedidosAsync();
    Task<Response<PedidoCommand>> AlterarPedidoAsync(AlterarPedidoRequestDto pedidoRequest);
    Task<Response<PedidoCommand>>? RemoverPedidoAsync(int idPedido);
}
