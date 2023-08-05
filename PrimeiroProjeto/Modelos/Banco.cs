namespace PrimeiroProjeto.Modelos;

class Banco
{
    private string nome { get; set; }

    public List<Cliente> clientes = new List<Cliente>();

    public Banco(string nome)
    {
        this.nome = nome;
    }

    public void visualizarClientes()
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Id: {cliente.getId()}| Nome: {cliente.getNome()}| Saldo: {cliente.getSaldo()}");
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
}