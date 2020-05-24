using CodeFirst.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst
{
    class Program
    {   
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                // Example1
                var course = unitOfWork.CourseRepository.Get(1);

                // Example2
                var courses = unitOfWork.CourseRepository.GetCoursesWithAuthors(1, 4);

                // Example3
                var author = unitOfWork.AuthorRepository.GetAuthorWithCourses(1);
                unitOfWork.CourseRepository.RemoveRange(author.Courses);
                unitOfWork.AuthorRepository.Remove(author);
                unitOfWork.Save();
            }

            IList<Student> studentList = new List<Student>
            {
                new Student { StudentID = 1, StudentName = "John", age = 13 } ,
                new Student { StudentID = 2, StudentName = "Steve",  age = 15 } ,
                new Student { StudentID = 3, StudentName = "Bill",  age = 18 } ,
                new Student { StudentID = 4, StudentName = "Ram" , age = 12 } ,
                new Student { StudentID = 5, StudentName = "Ron" , age = 21 }
            };

            var teenAgerStudents = GetStudents(studentList);

            foreach (var student in teenAgerStudents)
            {
                Console.WriteLine("Student Name: {0}", student.StudentName);
            }

            studentList.Add(new Student { StudentID = 6, StudentName = "Nael", age = 18 });

            foreach (var student in teenAgerStudents)
            {
                Console.WriteLine("Student Name: {0}", student.StudentName);
            }

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

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int age { get; set; }
        }

        public static IEnumerable<Student> GetStudents(IList<Student> studentList)
        {
            return studentList.Where(s => s.age > 12 && s.age < 20).ToList();
        }
    }
}
