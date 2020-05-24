using System.Collections.Generic;

namespace CodeFirst.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Category()
        {
            Courses = new HashSet<Course>();
        }
    }
}