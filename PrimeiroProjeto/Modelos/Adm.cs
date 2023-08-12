namespace PrimeiroProjeto.Modelos;

internal class Adm
{
    private string nome;
    private string user;
    private string senha;

    public Adm(string nome, string user, string senha)
    {
        this.nome = nome;
        this.user = user;
        this.senha = senha;
    }

    public string getSenha()
    {
        return senha;
    }

}
