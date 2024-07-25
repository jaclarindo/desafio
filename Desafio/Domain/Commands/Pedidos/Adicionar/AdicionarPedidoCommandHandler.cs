using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Domain.Commands.Pedidos.Adicionar;

public class AdicionarPedidoCommandHandler : IRequestHandler<AdicionarPedidoCommand, Response<PedidoCommand>>
{
    private readonly IValidator<AdicionarPedidoCommand> _validator;
    private readonly IValidator<ItemCommand> _itemValidator;
    private Response<PedidoCommand> _response;
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarPedidoCommandHandler(IValidator<AdicionarPedidoCommand> validator, IValidator<ItemCommand> itemValidator, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _itemValidator = itemValidator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<PedidoCommand>> Handle(AdicionarPedidoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        _response = new Response<PedidoCommand>(new PedidoCommand(), validationResult);
        if (_response.HasError())
            return _response;

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

        var pedido = new Pedido(request.NomeCliente, request.EmailCliente, request.DataPedido, itens, false);
        await _unitOfWork.PedidoRepository.Adicionar(pedido);

        await _unitOfWork.CommitAsync();

        _response.Data.IdPedido = pedido.Id;

        return _response;
    }
}
