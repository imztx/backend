using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<IEnumerable<ProdutoDto>> GetReposicaoAsync();
        Task<ProdutoDto> CreateAsync(CreateProdutoDto request);
        Task<ProdutoDto?> UpdateAsync(System.Guid id, UpdateProdutoDto request);
        Task DeleteAsync(System.Guid id);
    }
}
