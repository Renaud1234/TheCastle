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
    public class ArmyService : GenericService<Army>, IArmyService
    {
        private readonly IArmyRepository _armyRepository;

        public ArmyService(IArmyRepository armyRepo) : base(armyRepo)
        {
            _armyRepository = armyRepo;
        }


        public override Task Create(Army army)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Add TeamId to entity
            army.TeamId = teamId;

            // Update entity
            return base.Create(army);
        }

        public override Task Delete(Army army)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Check old/new TeamId


            // Update entity
            return base.Delete(army);
        }

        public async Task<Army> GetOneWithDetails(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id null", nameof(id));
            }

            return await _armyRepository.GetAll()
                .AsNoTracking()
                .Include(x => x.Castles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task Update(Army army)
        {
            // Recover UserId/TeamId
            var teamId = 1;

            // Check old/new TeamId


            // Add TeamId to entity
            army.TeamId = teamId;

            // Update entity
            return base.Update(army);
        }
    }
}
