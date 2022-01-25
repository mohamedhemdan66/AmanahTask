using AmanahTask.Core.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmanahTask.Core.Interfaces
{
    public interface IBaseRepository<TKey, T> where T : class
    {

        T GetById(TKey id);
        IEnumerable<T> GetAll();

        T Find(Expression<Func<T, bool>> filter, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, string orderDir = OrderBy.Ascending);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, string[] includes = null, int? skip = null, int? take = null,
            Expression<Func<T, object>> orderBy = null, string orderDir = OrderBy.Ascending);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, int skip, int take, string orderBy);

        T Add(T entity);
        T Update(T entity);
        T Delete(TKey id);

        int Count();
        int Count(Expression<Func<T, bool>> filter);


        #region Asynchronous Methods

        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] includes = null);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, string orderDir = OrderBy.Ascending);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[] includes = null, int? skip = null, int? take = null,
            Expression<Func<T, object>> orderBy = null, string orderDir = OrderBy.Ascending);

        Task<T> AddAsync(T entity);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> filter); 
        #endregion
    }
}
