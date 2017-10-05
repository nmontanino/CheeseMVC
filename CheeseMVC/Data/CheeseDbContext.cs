using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Models;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {

        public DbSet<Cheese> Cheeses { get; set; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        {
        }
    }
}
