using System;
using Projetos_Produtos.Interfaces;

namespace Projetos_Produtos.Classes
{
    public class Login : ILogin
    {
        Usuario NovoUsuario = new Usuario();
        private bool Logado = false;
        private bool Sair;
        private int ContMarca = 1;
        private int ContProduto = 1;
        private string Nome;
        private string Email;
        private string Senha;
        Produto ProdutoCadastro = new Produto();
        Marca MarcaCadastro = new Marca();
        Marca AntiErro = new Marca();
        private string MarcaAntiErro;

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
            AntiErro.Valores(0, "Sadia");
            MarcaCadastro.Cadastrar(AntiErro);
            do
            {
                Console.WriteLine(@"
______________________________________
|| Bem vindo a vendinha do seu José ||
||¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨||
||    0 - Sair                      ||
||    1 - Cadastrar-se              ||
||    2 - Logar                     ||
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

                                if ((Nome == Login || Email == Login) && SenhaLogin == Senha)
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
                                                Logado2 = false;
                                                break;
                                            case "1":
                                                Console.Write("Digite o nome do produto: ");
                                                string NomeProduto = Console.ReadLine();

                                                Console.Write("Digite o preço do produto: ");
                                                float PrecoProduto = float.Parse(Console.ReadLine());

                                                MarcaCadastro.Listar();
                                                Console.Write("Digite o código da marca do produto: ");
                                                int MarcaEscolhida = int.Parse(Console.ReadLine());
                                                MarcaAntiErro = MarcaCadastro.ListaMarcas.Find(x => x.CodigoMarca == MarcaEscolhida).NomeMarca;

                                                ProdutoCadastro.Valores(ContProduto, NomeProduto, PrecoProduto, MarcaAntiErro,Nome);
                                                Console.WriteLine(ProdutoCadastro.Cadastrar(ProdutoCadastro));
                                                ContProduto++;
                                                break;
                                            case "2":
                                                Console.Write($"Digite o código de qual produto deseja apagar: ");
                                                ProdutoCadastro.Listar();
                                                int CodigoProduto = int.Parse(Console.ReadLine());
                                                ProdutoCadastro.Deletar(ProdutoCadastro.ListaProdutos.Find(x => x.Codigo == CodigoProduto));
                                                break;
                                            case "3":
                                                Console.Write("Digite o nome da marca: ");
                                                string NomeMarca = Console.ReadLine();

                                                MarcaCadastro.Valores(ContMarca, NomeMarca);
                                                Console.WriteLine(MarcaCadastro.Cadastrar(MarcaCadastro));
                                                ContMarca++;
                                                break;
                                            case "4":
                                                Console.Write($"Digite o código de qual produto deseja apagar: ");
                                                MarcaCadastro.Listar();
                                                int CodigoMarca = int.Parse(Console.ReadLine());
                                                MarcaCadastro.Deletar(MarcaCadastro.ListaMarcas.Find(x => x.CodigoMarca == CodigoMarca));
                                                break;
                                            case "5":
                                                Console.WriteLine(Deslogar());
                                                Logado = false;
                                                Logado2 = false;
                                                break;
                                            case "6":
                                                Console.WriteLine(NovoUsuario.Deletar(NovoUsuario));
                                                break;
                                            case "7":
                                                MarcaCadastro.Listar();
                                                break;
                                            case "8":
                                                ProdutoCadastro.Listar();
                                                break;
                                            default:
                                                Console.WriteLine("Comando inválido");
                                                break;
                                        }
                                    } while (Logado2 == true);
                                }
                                else
                                {
                                    Console.WriteLine("\nCredênciais incorretas, Tente Novamente!\n");
                                }
                            } while (VerificarLogin == false);
                        }
                        else
                        {
                            Console.WriteLine("Você tem que ter um cadastro antes de tentar logar!");
                        }

                        break;
                    default:
                        break;
                }
            } while (Sair == false);
        }
    }
}