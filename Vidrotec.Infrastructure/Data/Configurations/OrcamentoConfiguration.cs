using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class OrcamentoConfiguration : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamentos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCliente).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Desconto).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ValorFinal).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
            builder.HasMany(x => x.Itens).WithOne(x => x.Orcamento).HasForeignKey(x => x.OrcamentoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
