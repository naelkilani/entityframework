using CodeFirst.Core.Models;
using CodeFirst.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public CourseRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return ApplicationDbContext.Courses.OrderByDescending(c => c.Price).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return ApplicationDbContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}