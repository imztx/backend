using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class OrcamentoItemConfiguration : IEntityTypeConfiguration<OrcamentoItem>
    {
        public void Configure(EntityTypeBuilder<OrcamentoItem> builder)
        {
            builder.ToTable("OrcamentoItens");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrcamentoId).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(300);
            builder.Property(x => x.PrecoUnitario).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Largura).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Altura).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.TipoVidro).HasMaxLength(150);
            builder.Property(x => x.NumeroFolhas).IsRequired();
            builder.Property(x => x.Abertura).HasMaxLength(100);
            builder.Property(x => x.Fechadura).HasMaxLength(100);
            builder.Property(x => x.Mola).HasMaxLength(100);
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
