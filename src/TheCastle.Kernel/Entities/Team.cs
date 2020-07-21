using System;
using System.Collections.Generic;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Team
    {
        // Init Collections
        public Team()
        {
            Players = new HashSet<Player>();
        }

        // Entity properties
        public int Id { get; set; }

        public string Name { get; set; }


        // Navigation properties
        public ICollection<Player> Players { get; private set; }
    }
}
