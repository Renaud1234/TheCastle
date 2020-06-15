using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Core.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        Task Delete(int id);
        Task Delete(TEntity entity);
        bool EntityExist(int id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetOne(int? id);
        Task<List<TEntity>> ListAll();
        Task Update(TEntity entity);
    }
}