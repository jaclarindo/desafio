using Application.DTOs;
using Application.DTOs.AlterarPedido;
using AutoMapper;
using Domain.Commands.Pedidos;
using Domain.Commands.Pedidos.Adicionar;
using Domain.Commands.Pedidos.Alterar;

namespace Application.Mappings;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<PedidoRequestDto, AdicionarPedidoCommand>();
        CreateMap<ItemRequestDto, ItemCommand>();

        CreateMap<AlterarPedidoRequestDto, AlterarPedidoCommand>();
    }
}
