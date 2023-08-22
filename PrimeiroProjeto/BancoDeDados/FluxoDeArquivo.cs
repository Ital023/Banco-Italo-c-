using PrimeiroProjeto.Modelos;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrimeiroProjeto.BancoDeDados;

internal class FluxoDeArquivo
{
    Arquivo arquivo = new Arquivo("contas.txt");

    public void abrirArquivoEmostrarArquivos(Banco banco)
    {
        using (var FluxosDeArquivo = new FileStream(arquivo.getLocalArquivo(), FileMode.Open))
        {
            var leitor = new StreamReader(FluxosDeArquivo);

            while(!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();  


                var cliente = ConverterStringParaConta(linha);


                banco.adicionarCliente(cliente);
            }
        }
    }

    public Cliente ConverterStringParaConta(string linha)
    {
        var campos = linha.Split(",");

        var cpf = campos[0];
        var senha = campos[1];
        var saldo = campos[2].Replace(".",",");
        var nome = campos[3];

        int cpfComInt = int.Parse(cpf);
        int senhaComInt = int.Parse(senha);
        double saldoComDouble = double.Parse(saldo);

        Cliente cliente = new Cliente(nome,cpfComInt,senhaComInt);
        cliente.depositar(saldoComDouble);

        return cliente;
    }
}
