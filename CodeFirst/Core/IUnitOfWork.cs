using CodeFirst.Core.Repositories;
using System;

namespace CodeFirst.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        int Save();
    }
}