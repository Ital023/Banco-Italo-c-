namespace PrimeiroProjeto.Modelos;
class Cliente : Pessoa
{
    public Cliente(string nome, int cpf, int id, string senha)
    {
        this.id = id;
        setNome(nome);
        setCpf(cpf);
        this.senha = senha;

    }

    private int id { get; set; }
    private double saldo { get; set; }
    private string senha { get; set; }


    public void depositar(double valor)
    {
        saldo += valor;
    }

    public void sacar(double valor)
    {
        if (saldo < valor)
        {
            Console.WriteLine("saldo insuficiente");
            Thread.Sleep(3000);
        }
        else
        {
            saldo -= valor;

        }

    }
    public int getId()
    {
        return id;
    }

    public double getSaldo()
    {
        return saldo;
    }

    public string getSenha()
    {
        return senha;
    }




}