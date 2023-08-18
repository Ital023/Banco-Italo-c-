namespace PrimeiroProjeto.Modelos;
internal class Pessoa
{
    private string Nome { get; set; }

    private int Cpf { get; set; }

    public string getNome()
    {
        return Nome;
    }

    public int getCpf()
    {
        return Cpf;
    }

    public string setNome(string nomeNovo)
    {
        return Nome = nomeNovo;
    }

    public int setCpf(int cpf)
    {
        return Cpf = cpf;
    }
}
