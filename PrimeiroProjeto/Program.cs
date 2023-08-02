//List<string> usuarios = new List<string>();
int i = 0;
Dictionary<string,int> clientes = new Dictionary<string,int>();
clientes.Add("Italo", 1000);
clientes.Add("Caio", 4500);
clientes.Add("Guilherme", 6200);

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
            case 1:registrarUsuario();
                limparConsole();
                break;
            case 2:RemoverUsuario();
                break;
            case 3:
                limparConsole();
                exibirUsuarios();
                break;
            case -1:
                Environment.Exit(0);
                break;
        }
    }


}

void registrarUsuario()
{
    limparConsole();
    astec();
    Console.WriteLine("REGISTRO USUARIO");
    astec();

    Console.Write("Insira o nome do usuario: ");
    string nome = Console.ReadLine();

    clientes.Add(nome, i);
    i++;
}

void RemoverUsuario()
{
    limparConsole();
    astec();
    Console.WriteLine("REMOVER USUARIO");
    astec();

    Console.Write("Insira o nome do usuario: ");
    string nome = Console.ReadLine()!;

    if (!clientes.ContainsKey(nome))
    {
        Console.WriteLine($"\nO cliente {nome} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        exibirMenu();
    }
    else
    {
        Console.WriteLine($"\nO cliente {nome} está sendo deletado!");
        Thread.Sleep(4000);
        clientes.Remove(nome);
        Console.WriteLine($"O cliente {nome} foi deletado!");
        Thread.Sleep(4000);
        limparConsole();
        exibirMenu();
    }
}
void exibirUsuarios()
{
        string frase = "Exibindo todas os usuarios registrados";
        string fraseUP = frase.ToUpper();

        limparConsole();
        astec();
        Console.WriteLine(fraseUP);
        astec();


    int i = 0;
        foreach (var usuario in clientes)
        {
            Console.WriteLine($"ID: {i} | Nome: {usuario.Key} | Valor: {usuario.Value}");
            i++;
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        limparConsole();
        exibirMenu();
    
}


void limparConsole()
{
    Console.Clear();
}

void astec()
{
    Console.WriteLine("************************************");
}