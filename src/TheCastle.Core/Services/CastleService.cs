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
    }
}
