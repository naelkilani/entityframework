using CodeFirst.Models;
using System.Linq;

namespace CodeFirst
{
    class Program
    {   
        static void Main(string[] args)
        {
            var context = new ApplicationDbContext();

            var innerJoin = context.Courses.Join(
                context.Authors,
                c => c.AuthorId,
                a => a.Id,
                (course, author) => new
                    {
                        CourseTitle = course.Title,
                        AuthorName = author.Name
                    });

            //https://dotnettutorials.net/lesson/left-outer-join-in-linq/
            var outerJoin = 
                from a in context.Authors
                join c in context.Courses
                    on a.Id equals c.AuthorId
                    into g
                from course in g.DefaultIfEmpty()
                select new { a, course };
        }
    }
}
