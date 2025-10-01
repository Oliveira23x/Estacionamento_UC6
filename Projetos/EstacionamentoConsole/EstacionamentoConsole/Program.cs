using EstacionamentoConsole.Controllers;
using EstacionamentoConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
         services.AddDbContext<EstacionamentoDbContext>(opt =>
          opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EstacionamentoDB;Trusted_Connection=True;TrustServerCertificate=True;"));


         services.AddTransient<ClienteController>();
     })
    .Build();


var clientesControllers = host.Services.GetRequiredService<ClienteController>();
bool sair = false;

while (!sair)
{
    Console.Clear();
    Console.WriteLine("===== Sistema de Estacionamento =====");
    Console.WriteLine("1. Listar Clientes");
    Console.WriteLine("2. Adicionar Cliente");
    Console.WriteLine("3. (A FAZER) Genrenciar Veículos");
    Console.WriteLine("4. (A FAZER) Genrenciar Vagas");
    Console.WriteLine("5. Ver detalhaes do Cliente.");
    Console.WriteLine("0. Sair");

    string? opcao = Console.ReadLine(); // Lê a opção do usuário
    
     switch (opcao)
     {  
        case "1":
            clientesControllers.ListarClientes();
            break;
        case "2":
            clientesControllers.AdicionarCliente();
            break;
        case "3":
            Console.WriteLine("Chamou o Gerenciar Veículos.");
            break;
        case "4":
            Console.WriteLine("Chamou o Gerenciar Vagas.");
            break;
            case "5":
            clientesControllers.VerDetatlhesCliente(); 
            break;  
        case "0":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("Encerrando o sistema. Até logo!");