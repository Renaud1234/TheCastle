using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            if (context.Armies.Any() == false)
            {
                var armies = new Army[]
                {
                    new Army { Name = "Humans" },
                    new Army { Name = "Orcs" }
                };
                foreach (Army item in armies)
                {
                    context.Armies.Add(item);
                }
                context.SaveChanges();
            }

            if (context.Castles.Any() == false)
            {
                var castles = new Castle[]
                {
                    new Castle { Name = "Minas Tirith", ArmyId = context.Armies.Where(x => x.Name == "Humans").FirstOrDefault().Id },
                    new Castle { Name = "Minas Morgul", ArmyId = context.Armies.Where(x => x.Name == "Orcs").FirstOrDefault().Id }
                };
                foreach (Castle item in castles)
                {
                    context.Castles.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
