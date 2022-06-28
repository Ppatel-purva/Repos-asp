#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoggerMvcCounter.Models;

namespace LoggerMvcCounter.Data
{
    public class LoggerMvcCounterContext : DbContext
    {
        public LoggerMvcCounterContext (DbContextOptions<LoggerMvcCounterContext> options)
            : base(options)
        {
        }

        public DbSet<LoggerMvcCounter.Models.LoginModel> LoginModel { get; set; }
    }
}
