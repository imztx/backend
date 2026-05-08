using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
    public class AgendaServicoRepository : RepositoryBase<AgendaServico>, IAgendaServicoRepository
    {
        public AgendaServicoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AgendaServico>> GetAllActiveAsync()
        {
            return await Context.AgendaServicos.ToListAsync();
        }

        public async Task<IEnumerable<AgendaServico>> GetByMonthAsync(int ano, int mes)
        {
            return await Context.AgendaServicos.Where(x => x.DataServico.Year == ano && x.DataServico.Month == mes).ToListAsync();
        }
    }
}
