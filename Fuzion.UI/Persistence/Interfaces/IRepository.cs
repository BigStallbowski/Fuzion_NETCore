using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}