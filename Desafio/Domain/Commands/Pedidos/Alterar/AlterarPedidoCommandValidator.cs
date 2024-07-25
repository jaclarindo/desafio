using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;

namespace Domain.Commands.Pedidos.Alterar;

public class AlterarPedidoCommandValidator : AbstractValidator<AlterarPedidoCommand>
{
    public AlterarPedidoCommandValidator(IPedidoRepository pedidoRepository)
    {
        RuleFor(c => c)
            .SetValidator(new PedidoValidator<AlterarPedidoCommand>());

        RuleFor(x => x.IdPedido)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(PedidoConstants.IdPedidoRequired)
            .MustAsync(async (idPedido, cancellationToken) => await pedidoRepository.ExistePedidoPorId(idPedido) == true)
            .WithMessage(PedidoConstants.PedidoNotFound);
    }
}
