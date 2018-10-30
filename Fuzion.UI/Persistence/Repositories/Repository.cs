using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.UI.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _ctx;

        public Repository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _ctx.Set<TEntity>().Remove(entity);
        }
    }
}