using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheCastle.Kernel.Entities.Base;

namespace TheCastle.Kernel.Entities
{
    public class Army : BaseEntity
    {
        public string Name { get; set; }

        #region Navigation properties
        public ICollection<Castle> Castles { get; set; }
        #endregion
    }
}
