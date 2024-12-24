using Microsoft.EntityFrameworkCore;
using Library.src.Models;

namespace Library.src.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprestimo>().HasKey(e => e.Id);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Catalogo>().HasKey(c => c.IdCatalogo);
            modelBuilder.Entity<Inventario>().HasKey(i => i.Id);

        }
    }
}
