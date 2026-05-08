using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
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
