using Microsoft.EntityFrameworkCore;

namespace WebApiUser.Models
{
    public class UserBDContext : DbContext
    {
        public UserBDContext(DbContextOptions<UserBDContext> options) : base(options)
        {
        }

        //Representacion de las tablas en la base de datos
        public DbSet<User.Shared.User> Users { get; set; }
        public DbSet<User.Shared.Login> Login { get; set; }
    }
}
