using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheCastle.Core.Interfaces;
using TheCastle.Infrastructure.Interfaces;
using TheCastle.Kernel.Entities;

namespace TheCastle.Core.Services
{
    public class CastleService : GenericService<Castle>, ICastleService
    {
        private readonly ICastleRepository _castleRepository;

        public CastleService(ICastleRepository castleRepo) : base(castleRepo)
        {
            _castleRepository = castleRepo;
        }


        public override Task Create(Castle castle)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Add TeamId to entity
            castle.TeamId = teamId;

            // Update entity
            return base.Create(castle);
        }

        public override Task Delete(Castle castle)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Check old/new TeamId


            // Update entity
            return base.Delete(castle);
        }

        public async Task<Castle> GetOneWithDetails(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id null", nameof(id));
            }

            return await _castleRepository.GetAll()
                .AsNoTracking()
                .Include(x => x.Army)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task Update(Castle castle)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Check old/new TeamId


            // Add TeamId to entity
            castle.TeamId = teamId;

            // Update entity
            return base.Update(castle);
        }
    }
}
