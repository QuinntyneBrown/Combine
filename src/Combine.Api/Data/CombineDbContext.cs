using Combine.Api.Models;
using Combine.Api.Core;
using Combine.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Combine.Api.Data
{
    public class CombineDbContext: DbContext, ICombineDbContext
    {
        public DbSet<Product> Products { get; private set; }
        public CombineDbContext(DbContextOptions options)
            :base(options) { }

    }
}
