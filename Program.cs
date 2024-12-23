using Library.src.Service;
using Library.src.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Library.src.UI;
using Library.src.Data;

namespace Library
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
                options.UseMySql("Server=mysql_oracle;Database=Library;User=root;Password=@@",
                    new MySqlServerVersion(new Version(8, 0, 21))));
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<IInventarioService, InventarioService>();
            services.AddTransient<IEmprestimoService, EmprestimoService>();
            services.AddTransient<Menu>();
        }
    }
}

