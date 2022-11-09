using Microsoft.EntityFrameworkCore;

namespace UserData.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KELLGGNLPTP1463;Database=UserDb;Trusted_Connection=True");

        }

    }
}
