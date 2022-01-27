using AmanahTask.Core.Constants;
using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.EF.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AmanahDbContext _dbContext;
        private readonly ILogService _logService;

        public BlogRepository(AmanahDbContext dbContext,ILogService logService)
        {
            this._dbContext = dbContext;
            this._logService = logService;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Blogs.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logService.Log("BlogRepository", "GetByIdAsync", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Blog>> GetAllAsync(Expression<Func<Blog, object>> orderBy = null, string orderDir = OrderBy.Ascending)
        {
            try
            {
                if(orderBy != null)
                {
                    if (orderDir == OrderBy.Ascending)
                        return await _dbContext.Blogs.OrderBy(orderBy).ToListAsync();
                    else
                        return await _dbContext.Blogs.OrderByDescending(orderBy).ToListAsync();
                }
                return await _dbContext.Blogs.ToListAsync();

            }
            catch (Exception ex)
            {
                _logService.Log("BlogRepository", "GetAllAsync", ex.Message);
                throw;
            }
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            try
            {
                await _dbContext.Blogs.AddAsync(blog);
                _dbContext.SaveChanges();
                return blog;
            }
            catch (Exception ex)
            {
                _logService.Log("BlogRepository", "AddAsync", ex.Message);
                throw;
            }
        }

        public Blog Update(Blog blog)
        {
            try
            {
                _dbContext.Blogs.Update(blog);
                _dbContext.SaveChanges();
                return blog;
            }
            catch (Exception ex)
            {
                _logService.Log("BlogRepository", "Update", ex.Message);
                throw;
            }
        }

        public Blog Delete(int id)
        {
            try
            {
                Blog blog = _dbContext.Blogs.Find(id);
                _dbContext.Blogs.Remove(blog);
                _dbContext.SaveChanges();
                return blog;
            }
            catch (Exception ex)
            {
                _logService.Log("BlogRepository", "Delete", ex.Message);
                throw;
            }
        }

    }
}
