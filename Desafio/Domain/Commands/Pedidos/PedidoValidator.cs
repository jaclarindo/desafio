using Domain.Shared;
using FluentValidation;

namespace Domain.Commands.Pedidos;

public class PedidoValidator<T> : AbstractValidator<AdicionarAlterarCommand<T>>
{
    public PedidoValidator()
    {
        RuleFor(x => x.NomeCliente)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(PedidoConstants.NomeClienteRequired)
            .MaximumLength(60).WithMessage(PedidoConstants.NomeClienteMaxLengthMessage)
            .MinimumLength(5).WithMessage(PedidoConstants.NomeClienteMinLengthMessage);

        RuleFor(x => x.EmailCliente)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(PedidoConstants.EmailClienteRequired)
            .EmailAddress()
            .WithMessage(PedidoConstants.EmailClienteInvalid)
            .MaximumLength(PedidoConstants.EmailClienteMaxLength)
            .WithMessage(PedidoConstants.EmailClienteMaxLengthMessage)
            .Must(MetodosComuns.NotContainAccentedCharacters)
            .WithMessage(PedidoConstants.EmailClienteInvalid);

        RuleFor(x => x.DataPedido)
            .NotEmpty().WithMessage(PedidoConstants.DataPedidoRequired);

        RuleFor(x => x.Itens)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(PedidoConstants.PedidoItensRequired)
            .Must(x => x.Count > 0).WithMessage(PedidoConstants.PedidoItensRequired);
    }
}
