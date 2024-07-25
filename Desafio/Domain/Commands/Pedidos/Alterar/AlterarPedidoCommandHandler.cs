using Domain.Commands.Pedidos.Adicionar;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Domain.Commands.Pedidos.Alterar;

public class AlterarPedidoCommandHandler : IRequestHandler<AlterarPedidoCommand, Response<PedidoCommand>>
{
    private readonly IValidator<AlterarPedidoCommand> _validator;
    private readonly IValidator<ItemCommand> _itemValidator;
    private Response<PedidoCommand> _response;
    private readonly IUnitOfWork _unitOfWork;

    public AlterarPedidoCommandHandler(IValidator<AlterarPedidoCommand> validator, IUnitOfWork unitOfWork, IValidator<ItemCommand> itemValidator)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
        _itemValidator = itemValidator;
    }

    public async Task<Response<PedidoCommand>> Handle(AlterarPedidoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        _response = new Response<PedidoCommand>(new PedidoCommand(request.IdPedido), validationResult);
        if (_response.HasError())
            return _response;

        var pedido = await _unitOfWork.PedidoRepository.ObterPorId(request.IdPedido);
        pedido.RemoverItens();

        var itens = new List<ItensPedido>();
        foreach (var item in request.Itens)
        {
            var itemValidationResult = await _itemValidator.ValidateAsync(item);
            if (!itemValidationResult.IsValid)
            {
                _response.AddErrors(itemValidationResult);
            }
            else
            {
                var produto = await _unitOfWork.PedidoRepository.ObterProdutoPorId(item.IdProduto);
                itens.Add(new ItensPedido(produto!.Id, item.Quantidade));
            }
        }

        if (_response.HasError())
            return _response;

        pedido.AdicionarItens(itens, request.NomeCliente, request.EmailCliente, request.DataPedido, request.Pago);
        await _unitOfWork.CommitAsync();
        _response.SetOk();

        return _response;
    }
}
