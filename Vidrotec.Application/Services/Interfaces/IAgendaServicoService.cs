using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IAgendaServicoService
    {
        Task<IEnumerable<AgendaServicoDto>> GetAllAsync();
        Task<IEnumerable<AgendaServicoDto>> GetByMonthAsync(int ano, int mes);
        Task<AgendaServicoDto> CreateAsync(CreateAgendaServicoDto request);
    }
}
