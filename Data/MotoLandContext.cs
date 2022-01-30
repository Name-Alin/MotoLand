using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MotoLand.Models;

namespace MotoLand.Data
{
    public class MotoLandContext : DbContext
    {
        public MotoLandContext (DbContextOptions<MotoLandContext> options)
            : base(options)
        {
        }

        public DbSet<MotoLand.Models.Motorcycle> Motorcycle { get; set; }

        public DbSet<MotoLand.Models.DealerMoto> DealerMoto { get; set; }

        public DbSet<MotoLand.Models.Category> Category { get; set; }
    }
}
