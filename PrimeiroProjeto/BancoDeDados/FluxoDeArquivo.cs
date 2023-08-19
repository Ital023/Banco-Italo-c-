using System.Text;

namespace PrimeiroProjeto.BancoDeDados;

internal class FluxoDeArquivo
{
    Arquivo arquivo = new Arquivo("contas.txt");

    public void abrirArquivoEmostrarArquivos()
    {
        using(var FluxosDeArquivo = new FileStream(arquivo.getLocalArquivo(), FileMode.Open))
        {
            var numeroDeBytesLidos = -1;

            var buffer = new byte[1024]; //1kb


            //Fluxo de dados
            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = FluxosDeArquivo.Read(buffer, 0, 1024);
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            FluxosDeArquivo.Close();
        }
    }

    public static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        //traduzindo para codigo byte em txt normal
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);
    }

    public void exibirArquivo()
    {
        Console.WriteLine("Local do arquivo -> " + arquivo.getLocalArquivo());

    }

}
