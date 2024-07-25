using Application.DTOs;

namespace Application.Interfaces;

public interface IPedidoQuery
{
    Task<PedidoResponseDto> ObterPorId(int id);
    Task<IEnumerable<PedidoResponseDto>> ObterTodos();
}
