using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCastle.Infrastructure.Data;
using TheCastle.Kernel;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetOne(int id)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> ListAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
