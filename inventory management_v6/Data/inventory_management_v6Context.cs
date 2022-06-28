#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory_management_v6.Models;

namespace inventory_management_v6.Data
{
    public class inventory_management_v6Context : DbContext
    {
        public inventory_management_v6Context (DbContextOptions<inventory_management_v6Context> options)
            : base(options)
        {
        }

        public DbSet<inventory_management_v6.Models.ProductItems> ProductItems { get; set; }

        public DbSet<inventory_management_v6.Models.Login> Login { get; set; }
    }
}
