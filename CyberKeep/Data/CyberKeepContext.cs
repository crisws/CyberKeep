using CyberKeep.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Data
{
    public class CyberKeepContext : DbContext
    {
        public CyberKeepContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Histories> Histories { get; set; }

    }
}
