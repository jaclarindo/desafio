using Domain.Commands.Pedidos;
using Domain.Commands.Pedidos.Adicionar;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.ComponentModel;
using Xunit;

namespace Unit.Test;

public class AdicionarPedidoCommandHandlerTests
{
    private readonly Mock<IValidator<AdicionarPedidoCommand>> _validatorMock;
    private readonly Mock<IValidator<ItemCommand>> _itemValidatorMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly AdicionarPedidoCommandHandler _handler;

    public AdicionarPedidoCommandHandlerTests()
    {
        _validatorMock = new Mock<IValidator<AdicionarPedidoCommand>>();
        _itemValidatorMock = new Mock<IValidator<ItemCommand>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();

        _handler = new AdicionarPedidoCommandHandler(_validatorMock.Object, _itemValidatorMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    [DisplayName("Testar se o handler retorna erro de validação ao receber um comando inválido")]
    public async Task Handle_ShouldReturnValidationErrors_WhenCommandIsInvalid()
    {
        // Arrange
        var command = new AdicionarPedidoCommand();
        var validationResult = new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("NomeCliente", "NomeCliente is required")
        });

        _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        result.Should().NotBeNull();
        result.HasError().Should().BeTrue();
    }


    [Fact]
    [DisplayName("Testar se o handler retorna erro de validação de itens ao receber um item inválido")]
    public async Task Handle_ShouldReturnValidationErrors_WhenItemIsInvalid()
    {
        // Arrange
        var command = new AdicionarPedidoCommand
        {
            NomeCliente = "John Doe",
            EmailCliente = "john.doe@example.com",
            DataPedido = DateTime.UtcNow,
            Itens = new List<ItemCommand>
            {
                new ItemCommand { IdProduto = 1, Quantidade = 0 } // Invalid item
            }
        };

        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

        var itemValidationResult = new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Quantidade", PedidoConstants.QuantidadeRequired)
        });

        _itemValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<ItemCommand>(), CancellationToken.None)).ReturnsAsync(itemValidationResult);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.HasError().Should().BeTrue();
    }

    [Fact]
    [DisplayName("Testar se o handler adiciona um pedido quando o comando é válido")]
    public async Task Handle_ShouldAddPedido_WhenCommandIsValid()
    {
        // Arrange
        var command = new AdicionarPedidoCommand
        {
            NomeCliente = "John Doe",
            EmailCliente = "john.doe@example.com",
            DataPedido = DateTime.UtcNow,
            Itens = new List<ItemCommand>
        {
            new ItemCommand { IdProduto = 1, Quantidade = 2 }
        }
        };

        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

        var itemValidationResult = new ValidationResult();
        _itemValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<ItemCommand>(), CancellationToken.None)).ReturnsAsync(itemValidationResult);

        var produto = new Produto(1, "Product 1", 10.0m );
        _unitOfWorkMock.Setup(u => u.PedidoRepository.ObterProdutoPorId(It.IsAny<int>())).ReturnsAsync(produto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.HasError().Should().BeFalse();
        result.Data.Should().NotBeNull();
        _unitOfWorkMock.Verify(u => u.PedidoRepository.Adicionar(It.IsAny<Pedido>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }
}