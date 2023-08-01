List<string> usuarios = new List<string>();

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
        Console.WriteLine("Digite 3 para alterar usuario");
        Console.WriteLine("Digite 4 para exibir usuarios");
        Console.WriteLine("Digite 5 para limpar console");
        Console.WriteLine("Digite -1 para sair");
        Console.Write("\nInsira o numero: ");
        string opcao = Console.ReadLine();
        int opcaoNumerica = int.Parse(opcao);

        switch (opcaoNumerica)
        {
            case 1:
                limparConsole();
                astec();
                Console.WriteLine("REGISTRO USUARIO");
                astec();
                string nome = inputUser();
                registrarUsuario(nome);
                break;

            case 2:
                string nomeR = inputUser();
                RemoverUsuario(nomeR);
                break;
            case 4:
                limparConsole();
                astec();
                Console.WriteLine("Registro usuario");
                astec();
                exibirUsuarios();
                break;
            case 5:
                limparConsole();
                break;

            case -1:
                Environment.Exit(0);
                break;
        }
    }


}

string inputUser()
{
    Console.Write("Insira o usuario: ");
    string nomeRemover = Console.ReadLine();
    
    return nomeRemover;
} 


void registrarUsuario(string usuario)
{
    limparConsole();
    usuarios.Add(usuario);
}

void RemoverUsuario(string nomeRemover)
{
    limparConsole();
    foreach (string usuario in usuarios)
    {
        if (usuario.Equals(nomeRemover))
        {
            usuarios.Remove(usuario);
        }
    }
}

void alterarUsuario(string usuario)
{
    limparConsole();
    string novoUser = inputUser();
    int i = 0;

    foreach(string user in usuarios)
    {
        if (usuarios.Equals(usuario))
        {
            usuarios[i] = novoUser;
        }
    }
    i++;
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
        foreach (string usuario in usuarios)
        {
            Console.WriteLine("\nID: " + i + " Nome: " + usuario);
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