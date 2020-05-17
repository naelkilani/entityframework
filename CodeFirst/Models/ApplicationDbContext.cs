﻿using System.Data.Entity;

namespace CodeFirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext()
        : base("name=DefaultConnection")
        {
        }
    }
}
