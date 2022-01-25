using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using AmanahTask.Core.Constants;
using AmanahTask.Core.Interfaces;

namespace AmanahTask.EF.Repositories
{
    public class BaseRepository<TKey, T> : IBaseRepository<TKey, T> where T : class
    {
        private readonly DbSet<T> _entity;

        public BaseRepository(AmanahDbContext context)
        {
            this._entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _entity.ToList(); // arrow function to short syntax
        public T GetById(TKey id) => _entity.Find(id);

        public T Find(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            IQueryable<T> query = _entity;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(filter);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, string orderDir = OrderBy.Ascending)
        {
            IQueryable<T> query = _entity.Where(filter);

            if (orderDir == OrderBy.Ascending)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);

            return query.ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, string[] includes = null, int? skip = null, int? take = null,
                  Expression<Func<T, object>> orderBy = null, string orderDir = "ASC")
        {
            IQueryable<T> query = _entity.Where(filter);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderDir == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter, int skip, int take, string orderBy)
        {
            return _entity.Where(filter).Skip(skip).Take(take).OrderBy(orderBy).ToList();
        }

        public T Add(T entity)
        {
            _entity.Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _entity.Update(entity);
            return entity;
        }
        public T Delete(TKey id)
        {
            T obj = _entity.Find(id);
            _entity.Remove(GetById(id));
            return obj;
        }

        public int Count() => _entity.Count();
        public int Count(Expression<Func<T, bool>> filter) => _entity.Count(filter);


        #region Asynchronous Methods 

        public async Task<T> GetByIdAsync(TKey id) => await _entity.FindAsync(id); // arrow function to short syntax
        public async Task<IEnumerable<T>> GetAllAsync() => await _entity.ToListAsync();

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            IQueryable<T> query = _entity;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            IQueryable<T> query = _entity.Where(filter);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, string orderDir = OrderBy.Ascending)
        {
            IQueryable<T> query = _entity.Where(filter);

            if (orderDir == OrderBy.Ascending)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter, string[] includes = null, int? skip = null, int? take = null,
               Expression<Func<T, object>> orderBy = null, string orderDir = "ASC")
        {
            IQueryable<T> query = _entity.Where(filter);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (skip.HasValue && take.HasValue)
                query = query.Skip(skip.Value).Take(take.Value);

            if (orderBy != null)
            {
                if (orderDir == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public async Task<int> CountAsync() => await _entity.CountAsync(); //arrow function to short syntax
        public async Task<int> CountAsync(Expression<Func<T, bool>> filter) => await _entity.CountAsync(filter);
        #endregion

    }
}
