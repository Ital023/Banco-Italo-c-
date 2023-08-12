using PrimeiroProjeto.Modelos;
using PrimeiroProjeto.Funcoes;
internal class Program
{
    private static void Main(string[] args)
    {

        Banco bancoItalo = new Banco("Banco do Italo");
        FuncoesMain funcoes = new FuncoesMain();
        Cliente cliente1 = new Cliente("Italo", 20, 0, "1111");
        Cliente cliente2 = new Cliente("Cadu", 24, 1, "2424");
        Cliente cliente3 = new Cliente("Cuberto", 999, 2, "mesmo");
        bancoItalo.adicionarCliente(cliente1);
        bancoItalo.adicionarCliente(cliente2);
        bancoItalo.adicionarCliente(cliente3);


        exibirMenu();


        void exibirHeader()
        {
            Console.WriteLine(@"
██████╗░░█████╗░███╗░░██╗░█████╗░░█████╗░  ██╗████████╗░█████╗░██╗░░░░░░█████╗░
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗  ██║╚══██╔══╝██╔══██╗██║░░░░░██╔══██╗
██████╦╝███████║██╔██╗██║██║░░╚═╝██║░░██║  ██║░░░██║░░░███████║██║░░░░░██║░░██║
██╔══██╗██╔══██║██║╚████║██║░░██╗██║░░██║  ██║░░░██║░░░██╔══██║██║░░░░░██║░░██║
██████╦╝██║░░██║██║░╚███║╚█████╔╝╚█████╔╝  ██║░░░██║░░░██║░░██║███████╗╚█████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░░╚════╝░  ╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝░╚════╝░"
        );
            msgBoasVindas();
        }

        void msgBoasVindas()
        {
            Console.WriteLine("Boas vindas ao banco Italo");
        }

        void exibirMenu()
        {
            int menuTempMenu = 0;

            while (menuTempMenu != -1)
            {

                funcoes.limparConsole();
                exibirHeader();

                Console.WriteLine("\nDigite 1 para ir a area do cliente");
                Console.WriteLine("Digite 2 para ir a area do adm");
                Console.WriteLine("Digite -1 para sair");
                Console.Write("\nInsira o numero: ");
                string opcao = Console.ReadLine();
                int opcaoNumerica = int.Parse(opcao);

                switch (opcaoNumerica)
                {
                    case 1:
                        exibirMenuCliente();
                        break;
                    case 2:
                        exibirMenuAdm();
                        break;
                    case -1:
                        Environment.Exit(0);
                        break;
                }

            }
        }

        void exibirMenuAdm()
        {
            Console.WriteLine("Insira a senha do adm: ");
            string senha = Console.ReadLine()!;

            if (bancoItalo.varAdm(senha))
            {
                int menuTemp = 0;

                while (menuTemp != -1)
                {
                    funcoes.limparConsole();
                    exibirHeader();

                    Console.WriteLine("\nDigite 1 para cadastrar usuario");
                    Console.WriteLine("Digite 2 para remover usuario");
                    Console.WriteLine("Digite 3 para alterar usuario");
                    Console.WriteLine("Digite 4 para exibir usuarios");
                    Console.WriteLine("Digite -1 para voltar");
                    Console.Write("\nInsira o numero: ");
                    string opcao = Console.ReadLine();
                    int opcaoNumerica = int.Parse(opcao);

                    switch (opcaoNumerica)
                    {
                        case 1:
                            Cliente cliente = bancoItalo.gerarCliente(bancoItalo);
                            bancoItalo.adicionarCliente(cliente);
                            funcoes.tempoEspera();
                            break;
                        case 2:
                            string nome2 = funcoes.capturarNome();
                            Cliente cliente2 = bancoItalo.procurarCliente(nome2);
                            bancoItalo.removerCliente(cliente2);
                            funcoes.tempoEspera();
                            break;
                        case 3:
                            string nome3 = funcoes.capturarNome();
                            Console.WriteLine("Insira o nome novo: ");
                            string nomeNovo = Console.ReadLine()!;
                            bancoItalo.alterarCliente(nome3, nomeNovo);
                            funcoes.tempoEspera();
                            break;
                        case 4:
                            bancoItalo.visualizarClientes();
                            funcoes.tempoEspera();
                            break;
                        case -1:
                            menuTemp = -1;
                            break;
                        default:
                            Console.WriteLine("Opcao invalida!");
                            break;

                    }

                }
            }
        }
        void exibirMenuCliente()
        {
            int menuTemp = 0;

            Console.WriteLine("Insira o cpf: ");
            string cpf = Console.ReadLine();
            int cpfNumerica = int.Parse(cpf);

            Console.WriteLine("Insira a senha: ");
            string senha = Console.ReadLine()!;

            if (bancoItalo.varCliente(cpfNumerica, senha))
            {
                while (menuTemp != -1)
                {
                    funcoes.limparConsole();
                    exibirHeader();

                    Console.WriteLine("\nBem vindo de volta ao banco cliente " + bancoItalo.getNomeByCpf(cpfNumerica));
                    Console.WriteLine();
                    Console.WriteLine("\nDigite 1 para depositar");
                    Console.WriteLine("Digite 2 para sacar");
                    Console.WriteLine("Digite -1 para voltar");
                    Console.Write("\nInsira o numero: ");
                    string opcao = Console.ReadLine();
                    int opcaoNumerica = int.Parse(opcao);

                    switch (opcaoNumerica)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            exibirMenuAdm();
                            break;
                        case -1:
                            Environment.Exit(0);
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Falha ao acessar o usuario");
            }

            
        }
    }
}

            
       
        
        
