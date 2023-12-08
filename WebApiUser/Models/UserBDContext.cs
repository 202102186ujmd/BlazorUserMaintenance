using Microsoft.EntityFrameworkCore;
using User.Shared;

namespace WebApiUser.Models
{
    public class UserBDContext : DbContext
    {
        public UserBDContext(DbContextOptions<UserBDContext> options) : base(options)
        {
        }

        //Representacion de las tablas en la base de datos

        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estado> Estado { get; set; }

        //Agregamos valores por defecto a las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Agregamos los datos iniciales a la tabla Estados
            modelBuilder.Entity<Estado>().HasData(
            new Estado { IdEstado = 1, Descripcion = "Recibida" },
            new Estado { IdEstado = 2, Descripcion = "En Progreso" },
            new Estado { IdEstado = 3, Descripcion = "Rechazado" },
            new Estado { IdEstado = 4, Descripcion = "Aprobado" },
            new Estado { IdEstado = 5, Descripcion = "Finalizado" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
