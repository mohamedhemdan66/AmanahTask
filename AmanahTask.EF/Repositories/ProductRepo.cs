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
    public class ProductRepo : IProductRepo
    {
        private readonly AmanahDbContext _dbContext;

        public ProductRepo(AmanahDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Product> GetAll() => _dbContext.Products.ToList();

        public Product GetById(int id) => _dbContext.Products.Find(id);

        public Product Find(Expression<Func<Product, bool>> filter) => _dbContext.Products.SingleOrDefault(filter);
        public IEnumerable<Product> FindAll(Expression<Func<Product, bool>> filter) => _dbContext.Products.Where(filter);

        public IEnumerable<Product> FindAll(Expression<Func<Product, bool>> filter, string[] includes = null,
             Expression<Func<Product, object>> orderBy = null, string orderDir = OrderBy.Ascending)
        {
            try
            {
                var query = _dbContext.Products.Where(filter);

                if (includes != null)
                    foreach (var include in includes)
                        query = query.Include(include);

                if (orderBy != null)
                {
                    if (orderDir == OrderBy.Ascending)
                        query = query.OrderBy(orderBy);
                    else
                        query = query.OrderByDescending(orderBy);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return null;
            }
        }

        public Product Add(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return null;
            }
        }
        public Product Update(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return null;
            }
        }
        public Product Delete(int id)
        {
            try
            {
                Product product = GetById(id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return null;
            }
        }

        #region Asynchronous Methods

        public async Task<IEnumerable<Product>> GetAllAsync() => await _dbContext.Products.ToListAsync();
        public async Task<Product> GetByIdAsync(int id) => await _dbContext.Products.FindAsync(id);

        public async Task<Product> FindAsync(Expression<Func<Product, bool>> filter) 
        {
            return await _dbContext.Products.SingleOrDefaultAsync(filter);
        }
        public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> filter)
        {
            return await _dbContext.Products.Where(filter).ToListAsync();
        }
        public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> filter, string[] includes = null,
            Expression<Func<Product, object>> orderBy = null, string orderDir = OrderBy.Ascending)
        {
            var query = _dbContext.Products.Where(filter);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if(orderBy != null)
            {
                if (orderDir == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            _dbContext.SaveChanges();
            return product;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            try
            {
                Product product = await GetByIdAsync(id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", $"Error Message: {ex.Message} - Time: {DateTime.Now}\n");
                return null;
            }
        }
        #endregion
    }
}
