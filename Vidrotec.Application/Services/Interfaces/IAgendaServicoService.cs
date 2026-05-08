using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Application.DTOs.Agenda;

namespace Vidrotec.Application.Services.Interfaces
{
    public interface IAgendaServicoService
    {
        Task<IEnumerable<AgendaResponseDto>> GetAllAsync();
        Task<IEnumerable<AgendaResponseDto>> GetByMonthAsync(int ano, int mes);
        Task<AgendaResponseDto> CreateAsync(AgendaCreateDto request);
    }
}
