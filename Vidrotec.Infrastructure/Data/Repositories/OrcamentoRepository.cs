using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
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
}
