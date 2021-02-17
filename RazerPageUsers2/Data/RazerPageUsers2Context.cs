using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazerPageUsers2.Models;

namespace RazerPageUsers2.Data
{
    public class RazerPageUsers2Context : DbContext
    {
        public RazerPageUsers2Context (DbContextOptions<RazerPageUsers2Context> options)
            : base(options)
        {
        }

        public DbSet<RazerPageUsers2.Models.User> User { get; set; }
    }
}
