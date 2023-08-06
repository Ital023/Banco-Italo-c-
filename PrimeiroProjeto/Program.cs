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
                Console.WriteLine("Digite 3 para exibir usuarios");
                Console.WriteLine("Digite -1 para sair");
                Console.Write("\nInsira o numero: ");
                string opcao = Console.ReadLine();
                int opcaoNumerica = int.Parse(opcao);

                switch (opcaoNumerica)
                {
                    case 1:
                        Cliente cliente = gerarCliente();
                        bancoItalo.adicionarCliente(cliente);
                        tempoEspera();
                        break;
                    case 2:
                        string nome = capturarNome();
                        Cliente cliente2 = bancoItalo.procurarCliente(nome);
                        bancoItalo.removerCliente(cliente2);
                        tempoEspera();
                        break;
                    case 3:
                        bancoItalo.visualizarClientes();
                        tempoEspera();
                        break;
                    case -1:
                        Environment.Exit(0);
                        break;

                }
            }

        }

        int varID(Banco banco)
        {
            int i = 0;
            foreach (var cliente in banco.clientes)
            {
                i++;
            }
            return i;
        }

        string capturarNome()
        {
            Console.Write("Insira o nome: ");
            string nome = Console.ReadLine()!;

            return nome;
        }

        Cliente gerarCliente()
        {
            Console.Write("Insira o nome: ");
            string nome = Console.ReadLine()!;

            Cliente cliente = new Cliente(varID(bancoItalo), nome, 0);

            return cliente;
        }

        void limparConsole()
        {
            Console.Clear();
        }

        void tempoEspera()
        {
            Thread.Sleep(5000);
        }
    }
}