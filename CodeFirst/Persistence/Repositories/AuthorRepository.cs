using CodeFirst.Core.Models;
using CodeFirst.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public AuthorRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return ApplicationDbContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
        }

    }
}