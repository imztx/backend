using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> GetAllActiveAsync();
        Task<IEnumerable<Produto>> GetReposicaoAsync();
    }
}
