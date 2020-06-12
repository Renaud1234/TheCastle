using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> ListAll();
        Task<TEntity> GetOne(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Delete(TEntity entity);
    }
}
