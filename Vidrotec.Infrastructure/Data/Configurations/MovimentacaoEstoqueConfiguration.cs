using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class MovimentacaoEstoqueConfiguration : IEntityTypeConfiguration<MovimentacaoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            builder.ToTable("MovimentacoesEstoque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProdutoId).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.QuantidadeAnterior).IsRequired();
            builder.Property(x => x.QuantidadeNova).IsRequired();
            builder.Property(x => x.ValorAnterior).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ValorNovo).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DataMovimentacao).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
