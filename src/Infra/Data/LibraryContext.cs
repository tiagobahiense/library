using Microsoft.EntityFrameworkCore;
using Library.src.Models;

namespace Library.src.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Emprestimo> Emprestimos { get; set; } = null!; // Inicializa com null!
        public DbSet<Catalogo> Catalogos { get; set; } = null!; // Inicializa com null!
        public DbSet<Cliente> Clientes { get; set; } = null!; // Inicializa com null!
        public DbSet<Inventario> Inventarios { get; set; } = null!; // Inicializa com null!

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

            // Configuração do Inventario
            modelBuilder.Entity<Inventario>()
                .HasKey(i => i.Id);

            // Configuração do Catalogo
            modelBuilder.Entity<Catalogo>()
                .HasKey(c => c.Id)
                .HasName("idCatalogo");
        }
    }
}
