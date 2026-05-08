using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(Guid id);
        Task<ClienteDto> CreateAsync(CreateClienteDto request);
        Task<ClienteDto?> UpdateAsync(Guid id, UpdateClienteDto request);
        Task DeleteAsync(Guid id);
        Task<ClienteImportResultDto> ImportCsvAsync(ImportClienteCsvDto request);
    }
}
