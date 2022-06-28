using Microsoft.EntityFrameworkCore;
using MvcSemple.Models;

namespace MvcSemple.Data
{
    public class MvcBookTicketContext : DbContext
    {
        public MvcBookTicketContext(DbContextOptions<MvcBookTicketContext> options) : base(options)
        { }
        public DbSet<BookTicket> BookTicket { get; set; }
    }
}


