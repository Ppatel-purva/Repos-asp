using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class webapiContext : DbContext
    {
        public webapiContext (DbContextOptions<webapiContext> options)
            : base(options)
        {
        }

        public DbSet<webapi.Models.ToDoItem> ToDoItem { get; set; }
    }
}
