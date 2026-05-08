using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> GetAllActiveAsync()
        {
            return await Context.Clientes.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> SearchByNameAsync(string nome)
        {
            return await Context.Clientes.Where(x => x.Nome.Contains(nome)).ToListAsync();
        }
    }

    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllActiveAsync()
        {
            return await Context.Produtos.Include(x => x.Movimentacoes).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetReposicaoAsync()
        {
            return await Context.Produtos.Where(x => x.Quantidade <= x.QuantidadeMinima).ToListAsync();
        }
    }

    public class OrcamentoRepository : RepositoryBase<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Orcamento>> GetAllActiveWithItensAsync()
        {
            return await Context.Orcamentos.Include(x => x.Itens).ToListAsync();
        }
    }

    public class AgendaServicoRepository : RepositoryBase<AgendaServico>, IAgendaServicoRepository
    {
        public AgendaServicoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AgendaServico>> GetAllActiveAsync()
        {
            return await Context.AgendaServicos.ToListAsync();
        }

        public async Task<IEnumerable<AgendaServico>> GetByMonthAsync(int ano, int mes)
        {
            return await Context.AgendaServicos.Where(x => x.DataServico.Year == ano && x.DataServico.Month == mes).ToListAsync();
        }
    }

    public class MovimentacaoEstoqueRepository : RepositoryBase<MovimentacaoEstoque>, IMovimentacaoEstoqueRepository
    {
        public MovimentacaoEstoqueRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> GetByProdutoIdAsync(Guid produtoId)
        {
            return await Context.MovimentacoesEstoque.Where(x => x.ProdutoId == produtoId).ToListAsync();
        }
    }

    public class ProdutoOrcamentoRepository : RepositoryBase<ProdutoOrcamento>, IProdutoOrcamentoRepository
    {
        public ProdutoOrcamentoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProdutoOrcamento>> GetAllActiveAsync()
        {
            return await Context.ProdutosOrcamento.ToListAsync();
        }
    }
}
