using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCastle.Infrastructure.Data;
using TheCastle.Infrastructure.Interfaces;
using TheCastle.Kernel.Entities;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await Save();
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await Save();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public async Task<TEntity> GetOne(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> ListAll()
        {
            return await _dbContext.Set<TEntity>()
                .ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
