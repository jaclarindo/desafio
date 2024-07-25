namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IPedidoRepository PedidoRepository { get; }
    Task<bool> CommitAsync();
    Task RollbackAsync();
}
