using Microsoft.EntityFrameworkCore;
using EDIReadFile.Models;

namespace EDIReadFile.Data
{
    public class EDIContext:DbContext
    {
        public EDIContext(DbContextOptions<EDIContext> options) : base(options)
        { }
        public DbSet<EdiItems> EDI { get; set; }
    }
}
