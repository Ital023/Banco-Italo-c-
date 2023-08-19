namespace PrimeiroProjeto.BancoDeDados;

internal class Arquivo
{
    public string localArquivo { get; set; }

    public Arquivo(string localArquivo)
    {
        this.localArquivo = localArquivo;
    }

    public string getLocalArquivo()
    {
        return localArquivo;
    }

    public void setLocalArquivo(string novoLocal)
    {
         localArquivo = novoLocal;
    }

}
