using VeiculosApp.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeiculosApp.Controllers;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ConsoleSimpleDb;Trusted_Connection=True;";

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddTransient<UsuariosController>();
    })
    .Build();

var usuariosController = host.Services.GetRequiredService<UsuariosController>();


MenuPrincipal();

void MenuPrincipal()
{
    bool sair = false;
    while (!sair)
    {
        Console.Clear();
        Console.WriteLine("=== Menu Principal ===");
        Console.WriteLine("1. Adicionar Veículo");
        Console.WriteLine("2. Listar Veículos");
        Console.WriteLine("3. Sair");
        Console.Write("Escolha uma opção: ");

        string opcao = Console.ReadLine() ?? "";
        if (opcao == "1")
        {
            MenuUsuarios();
        }
        else if (opcao == "2")
        {
            usuariosController.ListarVeiculos();
        }
        else if (opcao == "3")
        {
            sair = true;
        }
        else
        {
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
        }
    }
}


void MenuUsuarios()
{
    bool voltar = false;
    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("=== Menu de Veículos ===");
        Console.WriteLine("1. Adicionar Veículo");
        Console.WriteLine("2. Listar Veículos");
        Console.WriteLine("3. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
        string opcaoUsuarios = Console.ReadLine() ?? "";

        switch (opcaoUsuarios)
        {
            case "1":
                usuariosController.AdicionarVeiculo();
                break;
            case "2":
                usuariosController.ListarVeiculos();
                break;
            case "3":
                voltar = true;
                break;

        }
    }
}


