using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ports.Data;

namespace ports.Data
{
    public class portsContext : DbContext
    {
        public portsContext (DbContextOptions<portsContext> options)
            : base(options)
        {
        }

        public DbSet<ports.Models.MvcPorts> MvcPorts { get; set; }
    }
}
