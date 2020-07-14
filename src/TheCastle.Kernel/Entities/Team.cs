using System;
using System.Collections.Generic;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }


        #region Navigation properties
        public ICollection<Player> Players { get; set; }
        #endregion
    }
}
