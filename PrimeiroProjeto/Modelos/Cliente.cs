namespace PrimeiroProjeto.Modelos;
class Cliente : Pessoa
{
    public Cliente(string nome, int cpf,int senha)
    {
        setNome(nome);
        setCpf(cpf);
        this.senha = senha;
    }
    private double saldo { get; set; }
    private int senha { get; set; }


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
    public double getSaldo()
    {
        return saldo;
    }

    public int getSenha()
    {
        return senha;
    }




}