namespace Domain.Entities;

public sealed class Pedido : Entity
{
    public string NomeCliente { get; private set; }
    public string EmailCliente { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public bool Pago { get; private set; }
    public List<ItensPedido> Itens { get; private set; }


    public Pedido()
    {
        Itens = new List<ItensPedido>();
    }

    public Pedido(string nomeCliente, string emailcliente, DateTime dataCriacao, List<ItensPedido> itens, bool pago)
    {
        NomeCliente = nomeCliente;
        EmailCliente = emailcliente;
        DataCriacao = dataCriacao;
        Itens = itens;
        Pago = pago;
        Create();
    }

    public void AdicionarItens(List<ItensPedido> itens, string nomeCliente, string emailCliente, DateTime dataCriacao, bool pago)
    {
        Itens = itens;
        NomeCliente = nomeCliente;
        EmailCliente = emailCliente;
        DataCriacao = dataCriacao;
        Pago = pago;
    }

    public void RemoverPedido()
    {
        ChangeRemoved(true);
        RemoverItens();
    }

    public void RemoverItens()
    {
        foreach (var item in Itens)
        {
            item.ChangeRemoved(true);
        }
    }

    public void AtualizarQuantidade(Produto produto, int quantidade)
    {
        var itemPedido = Itens.FirstOrDefault(x => x.Produto == produto);
        itemPedido!.AtualizarQuantidade(quantidade);
    }
}
