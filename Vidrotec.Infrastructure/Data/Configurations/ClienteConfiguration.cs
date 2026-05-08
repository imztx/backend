using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Telefone).HasMaxLength(50);
            builder.Property(x => x.Endereco).HasMaxLength(500);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
            builder.HasMany(x => x.Orcamentos).WithOne(x => x.Cliente).HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
