using PrimeiroProjeto.Modelos;
Banco bancoItalo = new Banco("Italo");
Cliente cliente1 = new Cliente(1,"Italo",1500);
Cliente cliente2 = new Cliente(2, "Guigui", 12500);
bancoItalo.adicionarCliente(cliente1);
bancoItalo.adicionarCliente(cliente2);



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
            case 3:
                bancoItalo.visualizarClientes(); 
                break;

        }
    }

}
