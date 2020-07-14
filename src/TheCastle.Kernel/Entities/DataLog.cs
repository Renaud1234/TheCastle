using Microsoft.EntityFrameworkCore;
using System;

namespace TheCastle.Kernel.Entities
{
    public class DataLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ActionType { get; set; }

        public string TableName { get; set; }

        public string RecordId { get; set; }

        public string OriginalValue { get; set; }

        public string NewValue { get; set; }

        public DateTime ActionDateTime { get; set; }


        #region Navigation properties
        public Player Player { get; set; }

        #endregion
    }
}
