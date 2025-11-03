using Atb.Data.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Atb.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
        {

        }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
