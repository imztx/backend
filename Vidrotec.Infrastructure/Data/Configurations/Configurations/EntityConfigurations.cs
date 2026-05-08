using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Configurations
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
