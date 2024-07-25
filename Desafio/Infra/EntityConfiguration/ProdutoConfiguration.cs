using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(p => p.Id).HasName("id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(p => p.Nome).HasColumnName("nome").IsRequired().HasMaxLength(20); 
        builder.Property(p => p.Valor).HasColumnName("valor").IsRequired().HasPrecision(14, 2);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
        builder.Property(p => p.IsDeleted).HasColumnName("is_deleted").IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Produto (1, "Produto 1", 10.00m),
            new Produto (2, "Produto 2", 20.00m),
            new Produto (3, "Produto 3", 30.00m)
        );
    }
}
