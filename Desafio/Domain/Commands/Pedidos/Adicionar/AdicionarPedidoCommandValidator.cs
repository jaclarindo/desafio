using FluentValidation;

namespace Domain.Commands.Pedidos.Adicionar;

public class AdicionarPedidoCommandValidator : AbstractValidator<AdicionarPedidoCommand>
{
    public AdicionarPedidoCommandValidator()
    {
        RuleFor(c => c)
            .SetValidator(new PedidoValidator<AdicionarPedidoCommand>());
    }
}
