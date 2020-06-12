using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCastle.Kernel;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Core.Services
{
    public class GenericService<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _GenericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _GenericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }


        public Task Create(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TEntity>> ListAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
