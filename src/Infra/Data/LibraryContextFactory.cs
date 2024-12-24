using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Library.src.Data
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=mysql_library;User=root;Password=root;", new MySqlServerVersion(new Version(8, 0, 21)));

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
