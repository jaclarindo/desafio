using Domain.Interfaces;
using Domain.Shared;
using FluentValidation;

namespace Domain.Commands.Pedidos.Adicionar;

public class ItemCommandValidator : AbstractValidator<ItemCommand>
{
    public ItemCommandValidator(IPedidoRepository pedidoRepository)
    {
        RuleFor(x => x.IdProduto)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(PedidoConstants.IdProdutoRequired)
            .MustAsync(async (idProduto, cancellationToken) => await pedidoRepository.ObterProdutoPorId(idProduto) != null)
            .WithMessage(PedidoConstants.ProdutoNotFound);

        RuleFor(x => x.Quantidade)
            .NotEmpty().WithMessage(PedidoConstants.QuantidadeRequired);
    }
}
