using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrotec.Application.Interfaces;

namespace Vidrotec.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
