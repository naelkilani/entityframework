using CodeFirst.EntityConfiguration;
using System.Data.Entity;

namespace CodeFirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
        : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
