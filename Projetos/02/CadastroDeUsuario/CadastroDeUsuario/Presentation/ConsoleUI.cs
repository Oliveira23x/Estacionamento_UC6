using CadastroDeUsuario.Controller;

namespace CadastroDeUsuario.Presentation
{
    internal class ConsoleUI
    {
        private UsuarioController _usuarioController;

        public ConsoleUI(UsuarioController usuarioController)
        {
            _usuarioController = usuarioController;
        }

        public void MenuPrincipal()
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("==== Menu Principal ====");
                Console.WriteLine("1. Gerenciar Usuários");
                Console.WriteLine("2. Gerenciar Produtos");
                Console.WriteLine("0. Sair");

                string? opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    MenuUsuarios();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("Não implementado");
                    Console.ReadKey();
                }
                else if (opcao == "0")
                {
                    sair = true;
                }
            }
        }

        void MenuUsuarios()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("==== Gerenciar Usuários ====");
                Console.WriteLine("1. Listar usuários");
                Console.WriteLine("2. Detalhes de um usuário");
                Console.WriteLine("3. Cadastrar usuários");
                Console.WriteLine("5. Remover usuários");
                Console.WriteLine("0. Voltar");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _usuarioController.Listar();
                        break;
                    case "2":
                        _usuarioController.Detalhes();
                        break;
                    case "3":
                        _usuarioController.Adicionar();
                        break;
                    case "5":
                        _usuarioController.Deletar();
                        break;
                    case "0":
                        voltar = true;
                        break;
                }
            }
        }
    }
}