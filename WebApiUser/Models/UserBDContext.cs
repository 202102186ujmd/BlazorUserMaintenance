using Microsoft.EntityFrameworkCore;

namespace WebApiUser.Models
{
    public class UserBDContext : DbContext
    {
        public UserBDContext(DbContextOptions<UserBDContext> options) : base(options)
        {
        }

        public DbSet<User.Shared.User> Users { get; set; }
    }
}
