namespace PrimeiroProjeto.Funcoes;

internal class FuncoesMain
{
    public FuncoesMain()
    {
    }

    public static int capturarCpf()
    {
        Console.Write("Insira o cpf: ");
        return int.Parse(Console.ReadLine());
    }

    public static string capturarNome()
    {
        Console.Write("Insira o nome: ");
        string nome = Console.ReadLine()!;

        return nome;
    }

    public static void limparConsole()
    {
        Console.Clear();
    }

    public static void tempoEspera()
    {
        Thread.Sleep(3000);
    }
}
