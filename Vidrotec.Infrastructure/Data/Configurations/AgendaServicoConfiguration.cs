using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class AgendaServicoConfiguration : IEntityTypeConfiguration<AgendaServico>
    {
        public void Configure(EntityTypeBuilder<AgendaServico> builder)
        {
            builder.ToTable("AgendaServicos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataServico).IsRequired();
            builder.Property(x => x.Turno).IsRequired();
            builder.Property(x => x.Cliente).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Endereco).HasMaxLength(500);
            builder.Property(x => x.Responsavel).HasMaxLength(200);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
