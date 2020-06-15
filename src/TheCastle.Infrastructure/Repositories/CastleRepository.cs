using System;
using System.Collections.Generic;
using System.Text;
using TheCastle.Infrastructure.Data;
using TheCastle.Infrastructure.Interfaces;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure.Repositories
{
    public class CastleRepository : GenericRepository<Castle>, ICastleRepository
    {
        public CastleRepository(IGenericService dbContext) : base(dbContext)
        {
        }
    }
}
