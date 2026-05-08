using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs.Clientes;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto?> GetByIdAsync(Guid id);
        Task<ClienteResponseDto> CreateAsync(ClienteCreateDto request);
        Task<ClienteResponseDto?> UpdateAsync(Guid id, ClienteUpdateDto request);
        Task DeleteAsync(Guid id);
        Task<ClienteImportResultDto> ImportCsvAsync(ClienteImportacaoDto request);
    }
}
