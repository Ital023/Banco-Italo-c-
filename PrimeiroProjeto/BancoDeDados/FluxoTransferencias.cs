using PrimeiroProjeto.Modelos;
using System.Drawing;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        int i = 1;



        foreach (var cliente in banco.clientes)
        {
            if(cpfNumerico == cliente.getCpf())
            {
                while (i != cont)
                {
                    string valor = campos[i];
                    

                    char sinal = valor[0];
                   

                    string valorSemSinal = valor.Substring(1);

                    string valorReal = valorSemSinal.Split(" ")[0];
                    string data = valorSemSinal.Split(" ")[1];
                    string hora = valorSemSinal.Split(" ")[2];
                   

                    if (sinal == '+')
                    {                     
                        cliente.transacoes.Add($"Depositado o valor: R${valorReal} as {data} {hora}");
                    }
                    else if (sinal == '-')
                    {
                        cliente.transacoes.Add($"Sacado o valor: R${valorReal} as {data} {hora}");
                    }
                    i++;
                }
                break;
            }
        }
    }

    public static void salvandoTransferencias(Arquivo arquivo, Banco banco)
    {
        using (var fluxoArquivo = new FileStream(arquivo.getLocalArquivo(), FileMode.Create))
        {
            using (var escritor = new StreamWriter(fluxoArquivo))
            {

                foreach (var cliente in banco.clientes)
                {
                    int i = 2;
                    if (cliente.transacoes.Count != 1)
                    {
                        escritor.Write($"{cliente.getCpf()},");
                        foreach (var transacao in cliente.transacoes)
                        {

                            MatchCollection matches = Regex.Matches(transacao, @"(Depositado|Sacado) o valor: R\$(\d+).*?(\d{2}/\d{2}/\d{4}) (\d{2}:\d{2}:\d{2})");

                            foreach (Match match in matches)
                            {
                                string tipoTransacao = match.Groups[1].Value;
                                string valor = match.Groups[2].Value;
                                string data = match.Groups[3].Value;
                                string hora = match.Groups[4].Value;

                                if (tipoTransacao.Equals("Depositado"))
                                {
                                    escritor.Write($"+{valor} {data} {hora},");
                                }
                                else if (tipoTransacao.Equals("Sacado"))
                                {
                                    escritor.Write($"-{valor} {data} {hora},");

                                }

                            }

                            i++;
                            if (i == cliente.transacoes.Count)
                            {
                                foreach (Match match in matches)
                                {
                                    string tipoTransacao = match.Groups[1].Value;
                                    string valor = match.Groups[2].Value;
                                    string data = match.Groups[3].Value;
                                    string hora = match.Groups[4].Value;

                                    if (tipoTransacao.Equals("Depositado"))
                                    {
                                        escritor.Write($"+{valor} {data} {hora}");
                                    }
                                    else if (tipoTransacao.Equals("Sacado"))
                                    {
                                        escritor.Write($"-{valor} {data} {hora}");

                                    }
                                }
                                i++;
                            }
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }
    }


}
