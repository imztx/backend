using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
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
}
