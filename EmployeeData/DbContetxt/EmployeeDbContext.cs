using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.DbContetxt
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<EmployeeViewModel> Employees { get; set; }
        protected EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KELLGGNLPTP1463;Database=EmployeeDb;Trusted_Connection=True");

        }
    }
}
