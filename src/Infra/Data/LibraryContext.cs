using Microsoft.EntityFrameworkCore;
using Library.src.Models;

namespace Library.src.Infra.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Catalogo>().HasKey(c => c.IdCatalogo);
            modelBuilder.Entity<Emprestimo>().HasKey(e => e.Id);
            modelBuilder.Entity<Inventario>().HasKey(i => i.Id);

            modelBuilder.Entity<Cliente>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Catalogo>().Property(c => c.IdCatalogo).ValueGeneratedOnAdd();
            modelBuilder.Entity<Emprestimo>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventario>().Property(i => i.Id).ValueGeneratedOnAdd();
        }
    }
}



