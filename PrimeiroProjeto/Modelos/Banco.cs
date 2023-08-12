namespace PrimeiroProjeto.Modelos;

class Banco
{
    private string nome { get; set; }

    public List<Cliente> clientes = new List<Cliente>();

    Adm admItalo = new Adm("Italo", "italo", "0000");


    public Banco(string nome)
    {
        this.nome = nome;
    }

    public void visualizarClientes()
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Id: {cliente.getId()}| Nome: {cliente.getNome()}| Saldo: {cliente.getSaldo()}| Cpf: {cliente.getCpf()}");
        }
    }

    public Cliente procurarCliente(string nome)
    {
        foreach (var cliente in clientes)
        {
            if (cliente.getNome().Equals(nome))
            {
                return cliente;
            }
        }
        return null;
    }

    public void adicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }
    public void removerCliente(Cliente cliente)
    {
        clientes.Remove(cliente);
    }
    public void alterarCliente(string nome,string nomeNovo)
    {
        foreach(var pessoa in clientes)
        {
            if (pessoa.getNome().Equals(nome))
            {
                pessoa.setNome(nomeNovo);
                Console.WriteLine("Nome alterado!");
            }
        } 
    }

    public int varID(Banco banco)
    {
        int i = 0;
        foreach (var cliente in banco.clientes)
        {
            i++;
        }
        return i;
    }

    public Cliente gerarCliente(Banco bancoItalo)
    {
        Console.Write("Insira o nome: ");
        string nome = Console.ReadLine()!;

        Console.WriteLine("Insira o cpf: ");
        string cpf = Console.ReadLine();
        int cpfNumerica = int.Parse(cpf);

        Console.Write("Insira sua senha: ");
        string senha = Console.ReadLine()!;

        Cliente cliente = new Cliente(nome,cpfNumerica,varID(bancoItalo), senha);

        return cliente;
    }

    public bool varCliente(int cpf, string senha)
    {
        foreach(var cliente in clientes)
        {
            if (cliente.getCpf() == cpf)
            {
                if (cliente.getSenha().Equals(senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        Console.WriteLine("Usuario não encontrado!");
        Thread.Sleep(3000);
        return false;
    }

    public bool varAdm(string senhaTry)
    {
        if (admItalo.getSenha().Equals(senhaTry))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string getNomeByCpf(int cpf)
    {
        foreach (var cliente in clientes)
        {
            if(cliente.getCpf() == cpf)
            {
                return cliente.getNome();
            }
        }
        return null;
    }

    public void setSaldoByCpf(int cpf,double saldo,string opcao)
    {
        foreach( var cliente in clientes)
        {
            if (cliente.getCpf() == cpf)
            {
                if (opcao.Equals("depositar"))
                {
                    cliente.depositar(saldo);
                }else if (opcao.Equals("saque"))
                {
                    cliente.sacar(saldo);
                }
            }
        }
    }

}