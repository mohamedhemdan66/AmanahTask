using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using AmanahTask.EF;
using AmanahTask.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FileSharingApp.BL.Repositories
{
    public class AuthorRepository : BaseRepository<int, Author>, IAuthorRepository
    {
        private readonly AmanahDbContext _context;

        public AuthorRepository(AmanahDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Author> SpecialMethod(int userId)
        {
            return _context.Authors.AsTracking(); // only select without any modifications
        }
    }
}
