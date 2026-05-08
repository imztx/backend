using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IMovimentacaoEstoqueRepository : IRepositoryBase<MovimentacaoEstoque>
    {
        Task<IEnumerable<MovimentacaoEstoque>> GetByProdutoIdAsync(System.Guid produtoId);
    }
}
