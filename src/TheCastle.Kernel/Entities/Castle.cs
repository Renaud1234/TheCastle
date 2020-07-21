using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Castle : BaseEntity
    {
        // Entity properties
        public string Name { get; set; }

        public int? ArmyId { get; set; }


        // Navigation properties
        public Army Army { get; set; }
    }
}
