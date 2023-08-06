namespace PrimeiroProjeto.Modelos;
class Cliente
{
    private int id { get; set; }
    private string nome { get; set; }
    private double saldo { get; set; }
    public Cliente(int id, string nome, double saldo)
    {
        this.id = id;
        this.nome = nome;
        this.saldo = saldo;
    }

    public void depositar(double valor)
    {
        saldo -= valor;
    }
    
    public void sacar(double valor)
    {
        saldo += valor;
    }

    
    /*public void transferir(double valor,Cliente pessoa,Banco banco)
    {
        banco.clientes();
        foreach (var  in banco) { }
    }*/

    public string getNome()
    {
        return nome;
    }

    public int getId()
    {
        return id;
    }

    public double getSaldo()
    {
        return saldo;
    }

    public string setNome(string nomeNovo)
    {
        return nome = nomeNovo;
    }


}