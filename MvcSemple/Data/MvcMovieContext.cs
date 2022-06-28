using Microsoft.EntityFrameworkCore;
using MvcSemple.Models;

namespace MvcSemple.Data
{
    public class MvcMovieContext :DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options):base(options)
        { }
        public DbSet<Movies> Movies { get; set; }
    }
}
