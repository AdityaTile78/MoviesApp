using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Data
{
    public class MoviesContext:DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {}
        public DbSet<Models.Movie> Movies { get; set; }
        
    }
}
