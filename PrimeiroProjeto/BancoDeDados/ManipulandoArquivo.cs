using PrimeiroProjeto.Modelos;

namespace PrimeiroProjeto.BancoDeDados;
internal class ManipulandoArquivo
{
    public static void salvandoArquivo(Arquivo arquivo,Banco banco)
    {
        using(var fluxoArquivo = new FileStream(arquivo.getLocalArquivo(), FileMode.Create))
        {
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                foreach(var cliente in banco.clientes)
                {
                    escritor.WriteLine($"{cliente.getCpf()},{cliente.getSenha()},{cliente.getSaldo()},{cliente.getNome()}");
                }
            }

        }
        Console.WriteLine("Salvo feito!");
    }

}
