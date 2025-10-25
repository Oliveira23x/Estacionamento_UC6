using CadastroDeUsuario.Controller;
using CadastroDeUsuario.Data;
using CadastroDeUsuario.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;"));

        services.AddTransient<UsuarioController>();

        services.AddTransient<ConsoleUI>();
    }).Build();

var consoleUI = host.Services.GetRequiredService<ConsoleUI>();
consoleUI.MenuPrincipal();