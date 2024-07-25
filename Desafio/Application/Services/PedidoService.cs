using Application.DTOs;
using Application.DTOs.AlterarPedido;
using Application.Interfaces;
using AutoMapper;
using Domain.Commands.Pedidos.Adicionar;
using Domain.Commands.Pedidos.Alterar;
using Domain.Commands.Pedidos.Excluir;
using Domain.Shared;
using MediatR;

namespace Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPedidoQuery _pedidoQuery;

    public PedidoService(IMediator mediator, IMapper mapper, IPedidoQuery pedidoQuery)
    {
        _mediator = mediator;
        _mapper = mapper;
        _pedidoQuery = pedidoQuery;
    }

    public async Task<Response<PedidoCommand>>? AdicionarPedidoAsync(PedidoRequestDto pedidoRequest)
    {
        var command = _mapper.Map<AdicionarPedidoCommand>(pedidoRequest);
        var pedido = await _mediator.Send(command);
        return pedido;
    }

    public async Task<Response<PedidoCommand>> AlterarPedidoAsync(AlterarPedidoRequestDto pedidoRequest)
    {
        var command = _mapper.Map<AlterarPedidoCommand>(pedidoRequest);
        var pedido = await _mediator.Send(command);
        return pedido;        
    }

    public Task<PedidoResponseDto> ObterPedidoAsync(int idPedido)
    {
        var pedido = _pedidoQuery.ObterPorId(idPedido);
        return pedido;
    }

    public async Task<IEnumerable<PedidoResponseDto>> ObterPedidosAsync()
    {        
        var pedidos = await _pedidoQuery.ObterTodos();
        return pedidos.Select(pedido => _mapper.Map<PedidoResponseDto>(pedido));
    }

    public async Task<Response<PedidoCommand>>? RemoverPedidoAsync(int idPedido)
    {
        var command = new ExcluirPedidoCommand(idPedido);
        var pedido = await _mediator.Send(command);
        return pedido;
    }
}
