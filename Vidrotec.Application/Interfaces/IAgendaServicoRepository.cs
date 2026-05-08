using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IAgendaServicoRepository : IRepositoryBase<AgendaServico>
    {
        Task<IEnumerable<AgendaServico>> GetAllActiveAsync();
        Task<IEnumerable<AgendaServico>> GetByMonthAsync(int ano, int mes);
    }
}
