﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Castle : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int? ArmyId { get; set; }


        #region Navigation properties
        public Army Army { get; set; }
        #endregion
    }
}
