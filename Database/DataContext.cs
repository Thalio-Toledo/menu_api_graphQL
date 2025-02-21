using MenuGraphQl_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuGraphQl_API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menu { get; set; }
    }
}
