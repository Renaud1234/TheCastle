﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Castle> Castles { get; set; }
        public DbSet<Army> Armies { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<DataLog> DataLogs { get; set; }
        

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }

        
        public override int SaveChanges()
        {
            throw new NotImplementedException();
            //return base.SaveChanges();
        }

        // Override the SaveChangesAsync to log data entry changes
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // Documentation: https://www.meziantou.net/entity-framework-core-history-audit-table.htm
            
            var auditEntries = OnBeforeSaveChanges();
            
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            
            await OnAfterSaveChanges(auditEntries);
            
            return result;
        }

        // Use OnBeforeSaveChanges if all the values are known before actually saving the row -> saved at the same time as other entries
        private List<DataLogEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var dataLogEntries = new List<DataLogEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is DataLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var dataLogEntry = new DataLogEntry(entry)
                {
                    TableName = entry.Metadata.Name,
                    ActionType = entry.State.ToString()
                };
                dataLogEntries.Add(dataLogEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        dataLogEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        dataLogEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            dataLogEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            dataLogEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                dataLogEntry.OldValues[propertyName] = property.OriginalValue;
                                dataLogEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save dataLog entities that have all the modifications
            foreach (var dataLogEntry in dataLogEntries.Where(_ => !_.HasTemporaryProperties))
            {
                DataLogs.Add(dataLogEntry.ToDataLog());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return dataLogEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        // Use OnAfterSaveChanges if some entries have temporary values
        private Task OnAfterSaveChanges(List<DataLogEntry> dataLogEntries)
        {
            if (dataLogEntries == null || dataLogEntries.Count == 0)
                return Task.CompletedTask;
    
            foreach (var dataLogEntry in dataLogEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in dataLogEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        dataLogEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        dataLogEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the DataLog entry
                DataLogs.Add(dataLogEntry.ToDataLog());
            }

            return SaveChangesAsync();
        }
    }
}
