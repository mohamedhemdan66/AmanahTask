using AmanahTask.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.EF
{
    public class AmanahDbContext : DbContext
    {
        public AmanahDbContext(DbContextOptions<AmanahDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
