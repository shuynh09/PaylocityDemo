using Microsoft.EntityFrameworkCore;
using PaylocityDemo.Data.Entities;

namespace PaylocityDemo.Data
{
    public class PaylocityDemoContext : DbContext
    {
        public PaylocityDemoContext(DbContextOptions<PaylocityDemoContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}
