using System;
using System.ComponentModel.DataAnnotations;

namespace TheCastle.Kernel.Entities.Base
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }

        public int TeamId { get; set; }


        #region Navigation properties
        public Team Team { get; set; }

        #endregion
    }
}
