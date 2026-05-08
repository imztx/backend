using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vidrotec.Domain.Entities;

namespace Vidrotec.Application.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllActiveAsync();
        Task<IEnumerable<Cliente>> SearchByNameAsync(string nome);
    }
}
