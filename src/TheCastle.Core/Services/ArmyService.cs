using System;
using System.Collections.Generic;
using System.Text;
using TheCastle.Core.Interfaces;
using TheCastle.Infrastructure.Interfaces;
using TheCastle.Kernel.Entities;

namespace TheCastle.Core.Services
{
    public class ArmyService : GenericService<Army>, IArmyService
    {
        public ArmyService(IArmyRepository armyRepo) : base(armyRepo)
        {
        }
    }
}
