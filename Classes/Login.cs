using System;
using Projetos_Produtos.Interfaces;

namespace Projetos_Produtos.Classes
{
    public class Login : ILogin
    {
        Usuario NovoUsuario = new Usuario();
        private bool Logado;
        private bool Sair;
        private string Nome;
        private string Email;
        private string Senha;
        public string Deslogar()
        {
            Logado = false;
            return "Deslogado do sistema";
        }

        public string Logar()
        {
            Logado = true;
            return "Logado no sistema";
        }

        public Login()
        {
            Sair = false;
            do
            {
                Console.WriteLine(@"
______________________________________
|| Bem vindo a vendinha do seu José ||
||¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨||
||    0 - Sair                      ||
||    1 - Cadastrar-se              ||
||    2 - Logar                     ||
||    3 - Deslogar                  ||
||__________________________________||");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        Sair = true;
                        Console.WriteLine("Obrigado por utilizar o sistema da Vendinha do seu José");
                        break;
                    case "1":
                        int c = 1;

                        Console.Write("\nDigite seu nome de usuário: ");
                        Nome = Console.ReadLine();

                        Console.Write("Digite seu E-mail: ");
                        Email = Console.ReadLine();

                        Console.Write("Digite sua senha: ");
                        Senha = Console.ReadLine();

                        NovoUsuario.NovoUsuario(c, Nome, Email, Senha);
                        Console.WriteLine("Usuário cadastrado com sucesso!");
                        Console.WriteLine($"\nSeu horário de cadastro foi {DateTime.Now}");
                        c++;
                        break;
                    case "2":
                        bool VerificarLogin = false;
                        if (Nome != null)
                        {
                            do
                            {
                                Console.Write("Digite seu Nome de Usuario ou E-mail: ");
                                string Login = Console.ReadLine();
                                Console.Write("Digite sua senha: ");
                                string SenhaLogin = Console.ReadLine();

                                if (Nome == Login || Email == Login && SenhaLogin == Senha)
                                {
                                    Console.WriteLine(Logar());
                                    VerificarLogin = true;
                                    Logado = true;

                                    bool Logado2 = true;
                                    do
                                    {
                                        Console.WriteLine($@"
______________________________________
|| Bem vindo a vendinha do seu José ||
||¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨||
||    0 - Sair                      ||
||    1 - Cadastrar Um produto      ||
||    2 - Deletar um produto        ||
||    3 - Cadastrar uma marca       ||
||    4 - Deletar uma marca         ||
||    5 - Deslogar                  ||
||    6 - Deletar usuario           ||
||    7 - Listar Marcas             ||
||    8 - Listar Produtos           ||
||__________________________________||
                                    
                                    ");
                                        string opcao2 = Console.ReadLine();

                                        switch (opcao2)
                                        {
                                            case "0":
                                                Sair = true;
                                                Console.WriteLine("Obrigado por utilizar o sistema da Vendinha do seu José");
                                                Logado = false;
                                                break;
                                            case "1":
                                                break;
                                            case "2":
                                                break;
                                            case "3":
                                                break;
                                            case "4":
                                                break;
                                            case "5":
                                                break;
                                            case "6":
                                                break;
                                            case "7":    
                                                break;
                                            case "8":
                                                break;
                                            default:
                                                break;
                                        }
                                    } while (Logado == true);
                                }
                                else
                                {
                                    Console.WriteLine("Credênciais incorretas, Tente Novamente!");
                                }
                            } while (VerificarLogin == false);
                        }
                        else
                        {
                            Console.WriteLine("Você tem que ter um cadastro antes de tentar logar!");
                        }

                        break;
                    case "3":
                        Console.WriteLine(Deslogar());
                        break;
                    default:
                        break;
                }
            } while (Sair == false);
        }
    }
}