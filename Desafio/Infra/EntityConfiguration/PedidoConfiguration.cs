using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(p => p.NomeCliente).HasColumnName("nome_cliente").HasMaxLength(60).IsRequired();
        builder.Property(p => p.EmailCliente).HasColumnName("email_cliente").HasMaxLength(60).IsRequired();
        builder.Property(p => p.DataCriacao).HasColumnName("data_criacao").IsRequired();
        builder.Property(p => p.Pago).HasColumnName("pago").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnName("create_at").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName("update_at").IsRequired();
        builder.Property(p => p.IsDeleted).HasColumnName("is_deleted").IsRequired();

        builder.HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey(p => p.IdPedido)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}