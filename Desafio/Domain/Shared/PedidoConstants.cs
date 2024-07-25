namespace Domain.Shared;

public class PedidoConstants
{
    public const int NomeClienteMaxLength = 60;
    public const string NomeClienteRequired = "Nome do cliente é obrigatório.";
    public const string NomeClienteMaxLengthMessage = "Nome do cliente deve ter no máximo 60 caracteres.";
    public const string NomeClienteMinLengthMessage = "Nome do cliente deve ter no mínimo 5 caracteres.";

    public const int EmailClienteMaxLength = 60;
    public const string EmailClienteRequired = "Email do cliente é obrigatório.";
    public const string EmailClienteInvalid = "Email do cliente é inválido.";
    public const string EmailClienteMaxLengthMessage = "Email do cliente deve ter no máximo 60 caracteres.";

    public const string DataPedidoRequired = "Data do pedido é obrigatória.";
    public const string PedidoItensRequired = "Pedido deve conter ao menos um item.";

    public const string IdProdutoRequired = "IdProduto é obrigatório.";
    public const string QuantidadeRequired = "Quantidade é obrigatória.";
    public const string ProdutoNotFound = "Produto não encontrado.";

    public const string IdPedidoRequired = "IdPedido é obrigatório.";
    public const string PedidoNotFound = "Pedido não encontrado.";
}
