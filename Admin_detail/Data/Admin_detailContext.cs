#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Admin_detail;

namespace Admin_detail.Data
{
    public class Admin_detailContext : DbContext
    {
        public Admin_detailContext (DbContextOptions<Admin_detailContext> options)
            : base(options)
        {
        }

        public DbSet<Admin_detail.Admin> Admin { get; set; }
    }
}
