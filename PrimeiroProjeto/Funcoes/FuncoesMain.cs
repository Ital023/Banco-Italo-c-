namespace PrimeiroProjeto.Funcoes;

internal class FuncoesMain
{
    public FuncoesMain()
    {
    }

    public string capturarNome()
    {
        Console.Write("Insira o nome: ");
        string nome = Console.ReadLine()!;

        return nome;
    }

    public void limparConsole()
    {
        Console.Clear();
    }

    public void tempoEspera()
    {
        Thread.Sleep(3000);
    }
}
