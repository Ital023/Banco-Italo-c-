using PrimeiroProjeto.Modelos;
internal class Program
{
    private static void Main(string[] args)
    {

        Banco bancoItalo = new Banco("Banco do Italo");

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
            int menuTemp = 0;

            while (menuTemp != -1)
            {
                limparConsole();
                exibirHeader();

                Console.WriteLine("\nDigite 1 para cadastrar usuario");
                Console.WriteLine("Digite 2 para remover usuario");
                Console.WriteLine("Digite 3 para alterar usuario");
                Console.WriteLine("Digite 4 para exibir usuarios");
                Console.WriteLine("Digite -1 para sair");
                Console.Write("\nInsira o numero: ");
                string opcao = Console.ReadLine();
                int opcaoNumerica = int.Parse(opcao);

                switch (opcaoNumerica)
                {
                    case 1:
                        Cliente cliente = bancoItalo.gerarCliente(bancoItalo);
                        bancoItalo.adicionarCliente(cliente);
                        tempoEspera();
                        break;
                    case 2:
                        string nome2 = capturarNome();
                        Cliente cliente2 = bancoItalo.procurarCliente(nome2);
                        bancoItalo.removerCliente(cliente2);
                        tempoEspera();
                        break;
                    case 3:
                        string nome3 = capturarNome();
                        Console.WriteLine("Insira o nome novo: ");
                        string nomeNovo = Console.ReadLine()!;
                        bancoItalo.alterarCliente(nome3,nomeNovo);
                        tempoEspera();
                        break;
                    case 4:
                        bancoItalo.visualizarClientes();
                        tempoEspera();
                        break;
                    case -1:
                        Environment.Exit(0);
                        break;

                }
            }

        }

        

        string capturarNome()
        {
            Console.Write("Insira o nome: ");
            string nome = Console.ReadLine()!;

            return nome;
        }

        void limparConsole()
        {
            Console.Clear();
        }

        void tempoEspera()
        {
            Thread.Sleep(3000);
        }
    }
}