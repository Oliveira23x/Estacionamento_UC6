using VeiculosApp.Models;


namespace VeiculosApp.Controllers
{
    public class UsuariosController
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        // Métodos para gerenciar usuários podem ser adicionados aqui

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("--- Adicionar Novo Veicúlo ---");

            Console.Write("Digite a Marca do veiculo: ");
            string Marca = Console.ReadLine() ?? "";

            Console.Write("Digite o Modelo do Veicúlo: ");
            string Modelo = Console.ReadLine() ?? "";

            var newVeiculo = new Veiculos
            {
                Marca = Marca,
                Modelo = Modelo
                
            };

            _context.Veiculo.Add(newVeiculo);
            _context.SaveChanges();

            Console.WriteLine("\nVeicúlo adicionado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("--- Lista de Veiculos ---");

            var veiculos = _context.Veiculo.ToList();

            if (!veiculos.Any())
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
            else
            {
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"ID: {veiculo.Id} | Marca: {veiculo.Marca} | Modelo {veiculo.Modelo}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void DetalhesVeiculos()
        {
            Console.Clear();
            Console.WriteLine("--- Detalhes do Veiculos ---");
            Console.Write("Digite o ID do Veiculo que deseja ver os detalhes: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido!");
            }
            else
            {
                var veiculo = _context.Veiculo.FirstOrDefault(u => u.Id == id);
                if (veiculo == null)
                {
                    Console.WriteLine("\nUsuário não encontrado!");
                }
                else
                {
                    Console.WriteLine("\n--- Dados do Veiculo ---");
                    Console.WriteLine($"ID: {veiculo.Id}");
                    Console.WriteLine($"Marca : {veiculo.Marca}");
                    Console.WriteLine($"Modelo: {veiculo.Modelo}");
                    
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void AtualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("--- Atualizar Veiculos ---");
            Console.Write("Digite o ID do veiculo que deseja atualizar: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var VeiculoToUpdate = _context.Veiculo.FirstOrDefault(u => u.Id == id);
                if (VeiculoToUpdate != null)
                {
                    Console.WriteLine($"\nEditando Veiculo: {VeiculoToUpdate.Marca}. Deixe em branco para não alterar.");

                    Console.Write($"Novo Primeiro Nome ({VeiculoToUpdate.Marca}): ");
                    string newVeiculos = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(newVeiculos))
                    {
                        VeiculoToUpdate.Marca = newVeiculos;
                    }

                    // Lógica similar para outros campos...
                    _context.SaveChanges();
                    Console.WriteLine("\nVeiculos atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nVeiculos não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void RemoverUsuario()
        {
            Console.Clear();
            Console.WriteLine("--- Remover Veiculo ---");
            Console.Write("Digite o ID do Veiculo que deseja remover: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var VeiculoToRemove = _context.Veiculo.FirstOrDefault(u => u.Id == id);
                if (VeiculoToRemove != null)
                {
                    Console.WriteLine($"\nEncontrado: ID: {VeiculoToRemove.Id} | Marca: {VeiculoToRemove.Marca} {VeiculoToRemove.Modelo}");
                    Console.Write("Tem certeza que deseja remover este usuário? (S/N): ");
                    string confirmacao = Console.ReadLine() ?? "";

                    if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        _context.Veiculo.Remove(VeiculoToRemove);
                        _context.SaveChanges();
                        Console.WriteLine("\nVeiculo removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nVeiculo não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}

    





        