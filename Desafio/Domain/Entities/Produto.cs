namespace Domain.Entities;

public sealed class Produto : Entity
{
    public string Nome { get; private set; }
    public decimal Valor { get; private set; }

    public Produto(int id, string nome, decimal valor)
    {
        Id = id;
        Nome = nome;
        Valor = valor;
        CreatedAt = DateTime.Now;
        IsDeleted = false;
        UpdatedAt = DateTime.Now;
    }
}
