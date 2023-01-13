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
        public DbSet<Tag> Tags => Set<Tag>();

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

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1, Name = "nature" },
                new Tag() { Id = 2, Name = "sea" },
                new Tag() { Id = 3, Name = "hiking" },
                new Tag() { Id = 4, Name = "sunset" },
                new Tag() { Id = 5, Name = "walk" },
                new Tag() { Id = 6, Name = "rain" }
                );
        }
    }
}
