using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration;

public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItensPedido>
{
    public void Configure(EntityTypeBuilder<ItensPedido> builder)
    {
        builder.ToTable("ItensPedido");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(p => p.IdPedido).HasColumnName("id_pedido").IsRequired();
        builder.Property(p => p.IdProduto).HasColumnName("id_produto").IsRequired();
        builder.Property(p => p.Quantidade).HasColumnName("quantidade").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").IsRequired();
        builder.Property(p => p.IsDeleted).HasColumnName("is_deleted").IsRequired();

        builder.HasOne(p => p.Produto)
            .WithMany()
            .HasForeignKey(p => p.IdProduto)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
