using Microsoft.EntityFrameworkCore;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque => Set<MovimentacaoEstoque>();
        public DbSet<Orcamento> Orcamentos => Set<Orcamento>();
        public DbSet<OrcamentoItem> OrcamentoItens => Set<OrcamentoItem>();
        public DbSet<ProdutoOrcamento> ProdutosOrcamento => Set<ProdutoOrcamento>();
        public DbSet<AgendaServico> AgendaServicos => Set<AgendaServico>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Cliente>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<Produto>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<MovimentacaoEstoque>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<Orcamento>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<OrcamentoItem>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<ProdutoOrcamento>().HasQueryFilter(x => !x.Excluido);
            modelBuilder.Entity<AgendaServico>().HasQueryFilter(x => !x.Excluido);
            base.OnModelCreating(modelBuilder);
        }
    }
}
