using api_gamezone.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_gamezone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Cada DbSet<T> se convierte en una tabla
        public DbSet<Juego> Juegos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales de las tablas
            modelBuilder.Entity<Juego>(entity =>
            {
                entity.Property(j => j.Titulo)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(j => j.Genero)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(j => j.Precio)
                      .HasColumnType("decimal(10,2)");
            });
        }
    }
}
