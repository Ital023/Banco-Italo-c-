using PrimeiroProjeto.Modelos;
using PrimeiroProjeto.Funcoes;
using PrimeiroProjeto.BancoDeDados;

internal class Program
{
    private static void Main(string[] args)
    {
        Arquivo arquivo = new Arquivo("contas.txt");
        Arquivo transferArq = new Arquivo("transferenciasContas.txt");
        Banco bancoItalo = new Banco("Banco do Italo");
        Pix pix = new Pix();
        FluxoDeArquivo fluxoDeArquivo = new FluxoDeArquivo();
        fluxoDeArquivo.abrirArquivoEmostrarArquivos(bancoItalo,arquivo);
        FluxoTransferencias fluxoTransferencias = new FluxoTransferencias();
        fluxoTransferencias.abrirArquivoEmostrarTransferencias(bancoItalo, transferArq);
        FluxoTransferencias fluxotestetrans = new FluxoTransferencias();
        Arquivo arquivoTeste = new Arquivo("transteste.txt");
        


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

                FuncoesMain.limparConsole();
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
            Console.Write("Insira a senha do adm: ");
            string senha = Console.ReadLine()!;

            if (bancoItalo.varAdm(senha))
            {
                int menuTemp = 0;

                while (menuTemp != -1)
                {
                    FuncoesMain.limparConsole();
                    exibirHeader();

                    Console.WriteLine("\nDigite 1 para cadastrar usuario");
                    Console.WriteLine("Digite 2 para remover usuario");
                    //Console.WriteLine("Digite 3 para alterar usuario");
                    Console.WriteLine("Digite 3 para exibir usuarios");
                    Console.WriteLine("Digite 4 para salvar arquivo");
                    Console.WriteLine("Digite 5 para salvar transacoes");
                    Console.WriteLine("Digite -1 para voltar");
                    Console.Write("\nInsira o numero: ");
                    string opcao = Console.ReadLine();
                    int opcaoNumerica = int.Parse(opcao);

                    switch (opcaoNumerica)
                    {
                        case 1:
                            Cliente cliente = bancoItalo.gerarCliente(bancoItalo);
                            bancoItalo.adicionarCliente(cliente);
                            FuncoesMain.tempoEspera();
                            break;
                        case 2:
                            int cpf2 = FuncoesMain.capturarCpf();
                            Cliente cliente2 = bancoItalo.procurarClienteCpf(cpf2);
                            bancoItalo.removerCliente(cliente2);
                            Console.WriteLine("\nCliente removido!");
                            FuncoesMain.tempoEspera();
                            break;
                        //case 3:
                        //    string nome3 = FuncoesMain.capturarNome();
                        //    Console.Write("Insira o nome novo: ");
                        //    string nomeNovo = Console.ReadLine()!;
                        //    bancoItalo.alterarCliente(nome3, nomeNovo);
                        //    FuncoesMain.tempoEspera();
                        //    break;
                        case 3:
                            FuncoesMain.limparConsole();
                            exibirHeader();
                            bancoItalo.visualizarClientes();
                            break;
                        case 4:
                            ManipulandoArquivo.salvandoArquivo(arquivo, bancoItalo);
                            break;
                        case 5:
                            FluxoTransferencias.salvandoTransferencias(arquivoTeste, bancoItalo);
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

            Console.Write("Insira o cpf: ");
            string cpf = Console.ReadLine();
            int cpfNumerica = int.Parse(cpf);

            if (!bancoItalo.varCPF(cpfNumerica))
            {
                Console.WriteLine("Cpf não encontrado!");
            }
            else
            {
                Console.Write("Insira a senha: ");
                string senha = Console.ReadLine();
                int senhaNumerica = int.Parse(senha);

                if (bancoItalo.varCliente(cpfNumerica, senhaNumerica))
                {
                    while (menuTemp != -1)
                    {
                        FuncoesMain.limparConsole();
                        exibirHeader();

                        Console.WriteLine("\nBem vindo de volta ao banco cliente " + bancoItalo.getNomeByCpf(cpfNumerica));
                        Console.WriteLine("Seu saldo atual: R$" + bancoItalo.getSaldoByCpf(cpfNumerica));
                        Console.WriteLine();
                        Cliente clienteTransacao = bancoItalo.getCliente(cpfNumerica);
                        Console.WriteLine("Historico de transacoes: ");
                        clienteTransacao.visualizarTransacoes();
                        Console.WriteLine();
                        Console.WriteLine("\nDigite 1 para depositar");
                        Console.WriteLine("Digite 2 para sacar");
                        Console.WriteLine("Digite 3 para ir a area PIX");
                        Console.WriteLine("Digite -1 para voltar");
                        Console.Write("\nInsira o numero: ");
                        string opcao = Console.ReadLine();
                        int opcaoNumerica = int.Parse(opcao);

                        

                        switch (opcaoNumerica)
                        {
                            case 1:
                                Console.Write("Quanto deseja depositar: ");
                                double valorDepositar = double.Parse(Console.ReadLine());
                                bancoItalo.setSaldoByCpf(cpfNumerica, valorDepositar, 1);
                                break;
                            case 2:
                                Console.Write("Quanto deseja sacar: ");
                                double valorSacar = double.Parse(Console.ReadLine());
                                bancoItalo.setSaldoByCpf(cpfNumerica, valorSacar, 2);
                                break;
                            case 3:
                                Console.Write("Insira o valor do Pix: ");
                                double valorPix = double.Parse(Console.ReadLine());

                                Console.Write("Insira o cpf do destinatario: ");
                                int cpfDest = int.Parse(Console.ReadLine());

                                Cliente clienteRemet = bancoItalo.getCliente(cpfNumerica);
                                Cliente clienteDest = bancoItalo.getCliente(cpfDest);

                                pix.realizarPix(bancoItalo, clienteRemet, clienteDest, valorPix);

                                FuncoesMain.tempoEspera();
                                break;
                            case -1:
                                menuTemp = -1;
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
}

            
       
        
        
