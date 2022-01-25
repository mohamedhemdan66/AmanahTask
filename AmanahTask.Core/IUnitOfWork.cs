using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using System;

namespace AmanahTask.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<int, Blog> Blogs { get; } 
        public IAuthorRepository Authors { get; }

        int Save();

    }
}
