using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IOrcamentoRepository : IRepositoryBase<Orcamento>
    {
        Task<IEnumerable<Orcamento>> GetAllActiveWithItensAsync();
    }
}
