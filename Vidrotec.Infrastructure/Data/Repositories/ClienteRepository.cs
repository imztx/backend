using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Infrastructure.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> GetAllActiveAsync()
        {
            return await Context.Clientes.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> SearchByNameAsync(string nome)
        {
            return await Context.Clientes.Where(x => x.Nome.Contains(nome)).ToListAsync();
        }
    }
}
