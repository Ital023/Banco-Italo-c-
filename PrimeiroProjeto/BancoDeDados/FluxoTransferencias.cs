using PrimeiroProjeto.Modelos;
namespace PrimeiroProjeto.BancoDeDados;

internal class FluxoTransferencias
{
    public  void abrirArquivoEmostrarTransferencias(Banco banco, Arquivo arquivo)
    {
        using (var FluxosDeArquivo = new FileStream(arquivo.getLocalArquivo(), FileMode.Open))
        {
            var leitor = new StreamReader(FluxosDeArquivo);

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();

                ConverterTransferencias(linha,banco);

            }
        }
    }

    private void ConverterTransferencias(string linha,Banco banco)
    {
        var campos = linha.Split(",");
        int cont = campos.Length;

        string cpf = campos[0];
        int cpfNumerico = int.Parse(cpf);
        //Console.WriteLine(cpfNumerico);
        //Thread.Sleep(1000);
        int i = 1;

        foreach (var cliente in banco.clientes)
        {
            if(cpfNumerico == cliente.getCpf())
            {
                while (i != cont)
                {
                    string valor = campos[i];
                    //Console.WriteLine(valor);
                    //Thread.Sleep(5000);

                    char sinal = valor[0];
                    Console.WriteLine(sinal);
                    Thread.Sleep(2000);

                    string valorSemSinal = valor.Substring(1);
                    //Console.WriteLine(valorSemSinal);
                    //Thread.Sleep(5000);

                    if (sinal == '+')
                    {
                        Console.WriteLine("passei aq +");
                        Thread.Sleep(2000);

                        DateTime horaAtual = DateTime.Now;
                        cliente.transacoes.Add($"Depositado o valor: R${valorSemSinal} as {horaAtual.ToLocalTime()}");
                    }
                    else if (sinal == '-')
                    {
                        Console.WriteLine("passei aq -");
                        Thread.Sleep(2000);

                        DateTime horaAtual = DateTime.Now;
                        cliente.transacoes.Add($"Sacado o valor: R${valorSemSinal} as {horaAtual.ToLocalTime()}");
                    }
                    i++;
                }
                break;
            }
        }
        

        
    }
}
