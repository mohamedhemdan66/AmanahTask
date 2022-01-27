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
    public interface IBlogRepository
    {
        Task<Blog> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllAsync(Expression<Func<Blog, object>> orderBy = null, string orderDir = OrderBy.Ascending);
        Task<Blog> AddAsync(Blog product);
        Blog Update(Blog blog); 
        Blog Delete(int id);
    }
}
