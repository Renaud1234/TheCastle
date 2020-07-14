using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Teams.Any() == false)
            {
                var teams = new Team[]
                {
                    new Team { Name = "Admin" }
                };
                foreach (var item in teams)
                {
                    context.Teams.Add(item);
                }
                context.SaveChanges();
            }

            if (context.Players.Any() == false)
            {
                var players = new Player[]
                {
                    new Player{ Name = "Administrator", 
                                TeamId = context.Teams.FirstOrDefault(t => t.Name == "Admin").Id }
                };
                foreach (var item in players)
                {
                    context.Players.Add(item);
                }
                context.SaveChanges();
            }


            if (context.Armies.Any() == false)
            {
                var armies = new Army[]
                {
                    new Army { Name = "Humans", TeamId = context.Teams.FirstOrDefault(t => t.Name == "Admin").Id },
                    new Army { Name = "Orcs", TeamId = context.Teams.FirstOrDefault(t => t.Name == "Admin").Id }
                };
                foreach (var item in armies)
                {
                    context.Armies.Add(item);
                }

                context.SaveChanges();
            }

            if (context.Castles.Any() == false)
            {
                var castles = new Castle[]
                {
                    new Castle { Name = "Minas Tirith", 
                                 ArmyId = context.Armies.Where(x => x.Name == "Humans").FirstOrDefault().Id,
                                 TeamId = context.Teams.FirstOrDefault(t => t.Name == "Admin").Id },
                    new Castle { Name = "Minas Morgul", 
                                 ArmyId = context.Armies.Where(x => x.Name == "Orcs").FirstOrDefault().Id,
                                 TeamId = context.Teams.FirstOrDefault(t => t.Name == "Admin").Id }
                };
                foreach (var item in castles)
                {
                    context.Castles.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
