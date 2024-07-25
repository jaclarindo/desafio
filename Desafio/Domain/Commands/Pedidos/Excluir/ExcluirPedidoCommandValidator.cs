using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;

namespace Domain.Commands.Pedidos.Excluir;

public class ExcluirPedidoCommandValidator : AbstractValidator<ExcluirPedidoCommand>
{
    public ExcluirPedidoCommandValidator(IPedidoRepository pedidoRepository)
    {
        RuleFor(x => x.IdPedido)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(PedidoConstants.IdPedidoRequired)
            .MustAsync(async (idPedido, cancellationToken) => await pedidoRepository.ExistePedidoPorId(idPedido) == true)
            .WithMessage(PedidoConstants.PedidoNotFound);
    }
}
