using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using userapi.Models;

namespace userapi.Data
{
    public class userapiContext : DbContext
    {
        public userapiContext (DbContextOptions<userapiContext> options)
            : base(options)
        {
        }

        public DbSet<userapi.Models.UserItems> UserItems { get; set; }
    }
}
