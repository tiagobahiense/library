using Library.src.Service;
using Library.src.Service.Interfaces;
using Library.src.Repositories;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Library.src.UI;
using Library.src.Data;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            
            TestDatabaseConnection(serviceProvider);

            var menu = serviceProvider.GetService<Menu>();
            menu?.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseMySql("Server=localhost;Port=3306;Database=mysql_library;User=root;Password=root;",
                    new MySqlServerVersion(new Version(8, 0, 21))));
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<IInventarioService, InventarioService>();
            services.AddTransient<IEmprestimoService, EmprestimoService>();
            services.AddTransient<Menu>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<IInventarioRepository, InventarioRepository>();
            services.AddTransient<IEmprestimoRepository, EmprestimoRepository>();
        }

        private static void TestDatabaseConnection(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
                try
                {
                    context.Database.OpenConnection();
                    Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Falha ao conectar com o banco de dados: {ex.Message}");
                }
            }
        }
    }
}
