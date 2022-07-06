using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BoosterDataContext>
    {
        public BoosterDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BoosterDataContext>();
            var connectionString = "Data Source=LT-0362;Initial Catalog=boosterdb;Integrated Security=True";
            builder.UseSqlServer(connectionString);
            return new BoosterDataContext(builder.Options);
        }
    }
}
