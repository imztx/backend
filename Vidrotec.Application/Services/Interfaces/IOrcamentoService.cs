using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoDto>> GetAllAsync();
        Task<OrcamentoDto> CreateAsync(CreateOrcamentoDto request);
        Task DeleteAsync(System.Guid id);
    }
}
