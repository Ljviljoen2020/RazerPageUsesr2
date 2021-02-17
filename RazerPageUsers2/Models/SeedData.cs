using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazerPageUsers2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerPageUsers2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazerPageUsers2Context(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazerPageUsers2Context>>()))
            {
                if (context.User.Any())
                {
                    return; // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Surname = "Viljoen",
                        Fullname = "Leonard Johannes",
                        DateofBirth = DateTime.Parse("1979-4-28"),
                        IdentificationNuber = "790428507086"
                    },

                    new User
                    {
                        Surname = "Viljoen",
                        Fullname = "Chantel",
                        DateofBirth = DateTime.Parse("1979-10-06"),
                        IdentificationNuber = "791006",
                    }

                    );

                context.SaveChanges();
                
            }
        }
    }

}
