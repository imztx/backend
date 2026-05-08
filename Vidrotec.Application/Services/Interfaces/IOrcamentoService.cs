using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs.Orcamentos;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoResponseDto>> GetAllAsync();
        Task<OrcamentoResponseDto> CreateAsync(OrcamentoCreateDto request);
        Task DeleteAsync(System.Guid id);
    }
}
