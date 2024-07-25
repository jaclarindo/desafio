
namespace Domain.Entities;

public sealed class ItensPedido : Entity
{
    public ItensPedido()
    {        
    }

    public ItensPedido(int idProduto, int quantidade)
    {
        IdProduto = idProduto;
        Quantidade = quantidade;
        this.Create();
    }

    public int IdPedido { get; private set; }
    public int IdProduto { get; private set; }
    public int Quantidade { get; private set; }
    public Produto Produto { get; private set; }

    internal void AtualizarQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }
}
