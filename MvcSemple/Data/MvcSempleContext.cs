using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSemple.Models;

namespace MvcSemple.Data
{
    public class MvcSempleContext : DbContext
    {
        public MvcSempleContext (DbContextOptions<MvcSempleContext> options): base(options)
        {
        }

        public DbSet<MvcSemple.Models.Movies> Movies { get; set; }

        public DbSet<MvcSemple.Models.BookTicket> BookTicket { get; set; }
    }
}
