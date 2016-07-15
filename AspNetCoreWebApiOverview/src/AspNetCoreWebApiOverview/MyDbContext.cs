using AspNetCoreWebApiOverview.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiOverview
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
