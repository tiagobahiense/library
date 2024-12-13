using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Defina as chaves primárias ou qualquer outra configuração necessária
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);  // Exemplo de configuração
        }
    }
}
