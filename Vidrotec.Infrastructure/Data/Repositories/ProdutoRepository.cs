using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
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
}
