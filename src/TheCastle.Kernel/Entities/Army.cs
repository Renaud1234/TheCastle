using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Army : BaseEntity
    {
        // Init Collection
        public Army()
        {
            Castles = new HashSet<Castle>();
        }

        // Entity properties
        public string Name { get; set; }


        // Navigation properties
        public ICollection<Castle> Castles { get; private set; }
    }
}
