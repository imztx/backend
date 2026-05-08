using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IProdutoOrcamentoRepository : IRepositoryBase<ProdutoOrcamento>
    {
        Task<IEnumerable<ProdutoOrcamento>> GetAllActiveAsync();
    }
}
