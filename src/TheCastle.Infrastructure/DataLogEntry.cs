using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure
{
    class DataLogEntry
    {
        public DataLogEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public string ActionType { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public DataLog ToDataLog()
        {
            var dataLog = new DataLog()
            {
                TableName = TableName,
                ActionType = ActionType,
                ActionDateTime = DateTime.UtcNow,
                RecordId = JsonConvert.SerializeObject(KeyValues),
                OriginalValue = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValue = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues)
            };

            return dataLog;
        }
    }
}
