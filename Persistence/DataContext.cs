using Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {

        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ActivityModel> Activities { get; set; }

    }
}
