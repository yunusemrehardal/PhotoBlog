using Microsoft.EntityFrameworkCore;

namespace PhotoBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    Id = 1,
                    Title = "Mountains and Sea",
                    Description = "As the sun sets behind the hills, I watch the unique blue of the sea.",
                    Photo = "sample.jpg"
                }
            );
        }
    }
}
