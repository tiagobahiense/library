using Library.src.Service;
using Library.src.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Library.UI;
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

            var menu = serviceProvider.GetService<Menu>();
            menu.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseMySql("Server=mysql_oracle;Database=Livraria;User=root;Password=Nicknick@1;",
                    new MySqlServerVersion(new Version(8, 0, 21))));
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<IInventarioService, InventarioService>();
            services.AddTransient<IEmprestimoService, EmprestimoService>();
            services.AddTransient<Menu>();
        }
    }
}

