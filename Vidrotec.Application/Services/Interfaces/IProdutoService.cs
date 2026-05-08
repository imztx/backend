using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs.Estoque;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoResponseDto>> GetAllAsync();
        Task<IEnumerable<ProdutoResponseDto>> GetReposicaoAsync();
        Task<ProdutoResponseDto> CreateAsync(ProdutoCreateDto request);
        Task<ProdutoResponseDto?> UpdateAsync(System.Guid id, ProdutoUpdateDto request);
        Task DeleteAsync(System.Guid id);
    }
}
