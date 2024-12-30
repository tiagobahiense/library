using Microsoft.EntityFrameworkCore;
using Library.src.Models;

namespace Library.src.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public DbSet<Catalogo> Catalogos { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Inventario> Inventarios { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Catalogo)
                .WithMany()
                .HasForeignKey(e => e.IdCatalogo);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Inventario)
                .WithMany()
                .HasForeignKey(e => e.IdInventario);

            modelBuilder.Entity<Inventario>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Catalogo>()
                .HasKey(c => c.Id)
                .HasName("idCatalogo");
        }
    }
}
