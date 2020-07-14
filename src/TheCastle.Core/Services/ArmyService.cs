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
    }
}
