using CodeFirst.Core;
using CodeFirst.Core.Repositories;
using CodeFirst.Persistence.Repositories;

namespace CodeFirst.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICourseRepository CourseRepository { get; }
        public IAuthorRepository AuthorRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CourseRepository = new CourseRepository(_context);
            AuthorRepository = new AuthorRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}