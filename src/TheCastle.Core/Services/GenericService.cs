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


        public async Task Create(TEntity entity)
        {
            await _GenericRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _GenericRepository.Delete(id);
        }

        public async Task Delete(TEntity entity)
        {
            await _GenericRepository.Delete(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _GenericRepository.GetAll();
        }

        public Task<TEntity> GetOne(int id)
        {
            return _GenericRepository.GetOne(id);
        }

        public Task<List<TEntity>> ListAll()
        {
            return _GenericRepository.ListAll();
        }

        public async Task Update(TEntity entity)
        {
            await _GenericRepository.Update(entity);
        }
    }
}
