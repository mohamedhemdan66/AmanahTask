using AmanahTask.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AmanahTask.Core.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<int, Author>
    {
        //Special Methods over than Generic
        IEnumerable<Author> SpecialMethod(int userId); 
    }
}
