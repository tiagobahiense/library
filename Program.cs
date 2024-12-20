using Microsoft.EntityFrameworkCore;
using Library.src.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LivrariaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
                     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
