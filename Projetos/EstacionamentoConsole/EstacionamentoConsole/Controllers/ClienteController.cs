using EstacionamentoConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace EstacionamentoConsole.Controllers
{
    internal class ClienteController
    {
        EstacionamentoDbContext _context;

        public ClienteController(EstacionamentoDbContext context)
        {
            _context = context;
        }

        public void ListarClientes()
        {
            Console.Clear();
            var clientes = _context.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}");
            }

            Console.WriteLine("\nPressione qualquer tecla para retornar...");
            Console.ReadKey();
        }


        public void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("===== Adicionar Novo CLiente =====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Telefone (Opcional): ");
            string telefone = Console.ReadLine();




            Cliente c1 = new Cliente(nome, cpf, telefone);
            _context.Clientes.Add(c1);
            _context.SaveChanges();
            Console.WriteLine("Cliente adicionado com sucesso ! Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
        public void VerDetatlhesCliente()
        {
            Console.Clear();
            Console.WriteLine("===== Detalhes do Cliente =====");
            Console.Write("Digite o ID do cliente: ");
            var clienteId = int.Parse(Console.ReadLine());

            // BUscar o cliente no banco de dados
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == clienteId);

            if (cliente == null)
                Console.WriteLine("Cliente não encontrado.");
            
            else
            { 
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.Cpf}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");
            }
            Console.WriteLine("\n Pressione qualquer tecla para retornar.");
            Console.ReadKey();
        }
    }
}
