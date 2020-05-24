using System.Collections.Generic;
using System.Data.Entity.Migrations;
using CodeFirst.Core.Models;

namespace CodeFirst.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Authors.AddOrUpdate(a => a.Name,
            new Author
            {
                Name = "Mosh Hamedani",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Title = "Entity Framework",
                        Description = "DB First VS Code First",
                        Category = new Category
                        {
                            Name = "C#"
                        }
                    }
                }
            });
        }
    }
}
