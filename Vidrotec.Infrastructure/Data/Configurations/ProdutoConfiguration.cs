using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cor).HasMaxLength(100);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.QuantidadeMinima).IsRequired();
            builder.Property(x => x.ValorUnitario).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
            builder.HasMany(x => x.Movimentacoes).WithOne(x => x.Produto).HasForeignKey(x => x.ProdutoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
