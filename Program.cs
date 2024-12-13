using Microsoft.EntityFrameworkCore;
using Livraria.Infra.Data;  // Aqui você coloca o seu namespace correto
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<LivrariaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
                     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Outros serviços como repositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();

var app = builder.Build();

// Configurar o pipeline de requisição (exemplo para um API)
app.MapGet("/", () => "Hello World!");

app.Run();
