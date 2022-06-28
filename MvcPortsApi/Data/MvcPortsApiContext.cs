using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPortsApi.Models;


namespace MvcPortsApi.Data
{
    public class MvcPortsApiContext : DbContext
    {
        public MvcPortsApiContext (DbContextOptions<MvcPortsApiContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPortsApi.Models.Ports> Ports { get; set; }
    }
}
