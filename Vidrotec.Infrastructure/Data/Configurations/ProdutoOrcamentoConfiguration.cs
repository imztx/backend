using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class ProdutoOrcamentoConfiguration : IEntityTypeConfiguration<ProdutoOrcamento>
    {
        public void Configure(EntityTypeBuilder<ProdutoOrcamento> builder)
        {
            builder.ToTable("ProdutosOrcamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
