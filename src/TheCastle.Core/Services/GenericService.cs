using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCastle.Core.Interfaces;
using TheCastle.Infrastructure.Interfaces;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Core.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> 
        where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _GenericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepo)
        {
            _GenericRepository = genericRepo ?? throw new ArgumentNullException(nameof(genericRepo));
        }


        public virtual async Task Create(TEntity entity)
        {
            await _GenericRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            TEntity entity = await GetOne(id);

            if (entity != null)
            {
                await _GenericRepository.Delete(entity);
            }
            else
            {
                throw new ArgumentException(string.Format("Id {0} not found.", id), nameof(id));
            }
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _GenericRepository.Delete(entity);
        }

        public bool EntityExist(int id)
        {
            return GetAll().Any(x => x.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _GenericRepository.GetAll();
        }

        public Task<TEntity> GetOne(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id null", nameof(id));
            }

            return _GenericRepository.GetOne(id.GetValueOrDefault());
        }

        //public Task<List<TEntity>> ListAll()
        //{
        //    return _GenericRepository.ListAll();
        //}

        public virtual async Task Update(TEntity entity)
        {
            await _GenericRepository.Update(entity);
        }
    }
}
