using AmanahTask.Core;
using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using FileSharingApp.BL.Repositories;
using System;

namespace AmanahTask.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmanahDbContext _context;

        public IAuthorRepository Authors { private set; get; }
        public IBaseRepository<int, Blog> Blogs { private set; get; }

        public UnitOfWork(AmanahDbContext context)
        {
            this._context = context;
            this.Authors = new AuthorRepository(_context);
            this.Blogs = new BaseRepository<int, Blog>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this); 
        }
    }
}
