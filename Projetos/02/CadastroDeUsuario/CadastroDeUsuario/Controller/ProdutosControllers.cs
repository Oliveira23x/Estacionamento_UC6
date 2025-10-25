using CadastroDeUsuario.Models;
using CadastroDeUsuario.Data;
using Microsoft.Identity.Client;


namespace CadastroDeUsuario.Controller
{
    internal class ProdutosControllers
    {
        private AppDbContext _context;


        public ProdutosControllers(AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarPT()
        {
            Console.Clear();
            Console.WriteLine("Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do Produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Data de Vencimento: ");
            DateOnly vencimento = DateOnly.Parse(Console.ReadLine());
            var novoProduto = new Produtos()
            {
                Nome = nome,
                Preco = preco,
                Vencimento = vencimento
            };
            _context.Produtos.Add(novoProduto);
            _context.SaveChanges();
            Console.WriteLine("Produto Cadastrado com Sucesso!");
            Console.WriteLine("Pressine qualquer tecla pra sair.");
            Console.ReadKey();
        }
        public void ListarPT()
        {
            var produtos = _context.Produtos.ToList();

            if (!produtos.Any())
            {
                Console.WriteLine("Nenhum Produto cadrastado");
            }
            else
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id}| Nome: {produto.Nome} {produto.Preco} | Data de Nascimento: {produto.Vencimento}");
                }

            }
            Console.WriteLine("\n Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }

        public void DetalhesPT()
        {
            //Dizer onde eu estou
            Console.Clear();
            Console.WriteLine("==== Detalhes do Produto ====");

            // Pedir ID do Usuário
            Console.WriteLine("Digite o ID do Produtos:");
            var IdProdutos = int.Parse(Console.ReadLine());

            // Buscar o usuário no banco de dados 
            var produtos = _context.Produtos.FirstOrDefault(user => user.Id == IdProdutos);

            // Se não encontar, avisar o usuário
            if (produtos == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
            }
            else // Se encontar, mostar os detalhes do usuário
            {
                Console.WriteLine("--- Dados do Usuário ---");
                Console.WriteLine($"ID:{produtos.Id}");
                Console.WriteLine($"Nome:{produtos.Nome}");
                Console.WriteLine($"Preço:{produtos.Preco}");
                Console.WriteLine($"Data de Vencimento:{produtos.Vencimento}");

            }


            Console.WriteLine("\n Pressione qualquer tecla pra sair!");




        }

        public void DeletarPT()
        {
            Console.Clear();
            Console.WriteLine("==== Deletar um Produtos ====");
            Console.WriteLine("Digite o ID do produtos que deseja deletar:");
            int IdProdutos = int.Parse(Console.ReadLine());
            var produtos = _context.Usuario.FirstOrDefault(user => user.Id == IdProdutos);
            if (produtos == null)
            {

                Console.WriteLine("\nProdutos não encontrado!");
                Console.WriteLine("Pressione qualquer tecla pra voltar.");
                Console.ReadKey();
                return;
            }
            else
            {
                _context.Usuario.Remove(produtos);
                _context.SaveChanges();



            }
            Console.WriteLine("Produtos deletado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla pra voltar.");
            Console.ReadKey();
        }




        }
    }

     
    