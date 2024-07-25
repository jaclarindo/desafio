using Domain.Commands.Pedidos.Adicionar;
using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Domain.Commands.Pedidos.Excluir;

public class ExcluirPedidoCommandHandler : IRequestHandler<ExcluirPedidoCommand, Response<PedidoCommand>>
{
    private readonly IValidator<ExcluirPedidoCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;
    private Response<PedidoCommand> _response;

    public ExcluirPedidoCommandHandler(IValidator<ExcluirPedidoCommand> validator, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<PedidoCommand>> Handle(ExcluirPedidoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
                _response = new Response<PedidoCommand>(new PedidoCommand(request.IdPedido), validationResult);
        if (_response.HasError())
        {
            _response.SetNotFound();
            return _response;
        }

        _response.SetOk();

        var pedido = await _unitOfWork.PedidoRepository.ObterPorId(request.IdPedido);
        pedido.RemoverPedido();
        await _unitOfWork.CommitAsync();

        return _response;
    }
}