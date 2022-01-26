using AmanahTask.Core.Constants;
using AmanahTask.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);

        Product Find(Expression<Func<Product, bool>> filter);
        IEnumerable<Product> FindAll(Expression<Func<Product, bool>> filter);
        IEnumerable<Product> FindAll(Expression<Func<Product, bool>> filter, string[] includes = null,
            Expression<Func<Product, object>> orderBy = null, string orderDir = OrderBy.Ascending);

        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);

        #region Asynchronous Methods

        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);

        Task<Product> FindAsync(Expression<Func<Product, bool>> filter);
        Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> filter);
        Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> filter, string[] includes = null,
            Expression<Func<Product, object>> orderBy = null, string orderDir = OrderBy.Ascending);

        Task<Product> AddAsync(Product product);
        Task<Product> DeleteAsync(int id);
        #endregion
    }
}
