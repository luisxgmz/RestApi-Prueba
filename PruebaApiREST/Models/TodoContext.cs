using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace PruebaApiREST.Models
{
    public class TodoContext : DbContext
    {
        private readonly DbContextOptions _options;
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        { _options = options; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}