namespace PrimeiroProjeto.Modelos;
internal class Pix
{
    public void realizarPix(Banco banco,Cliente clienteRemetente,Cliente clienteDestinatario,double valor)
    {
        foreach(var Remetente in banco.clientes)
        {
            if(Remetente.getCpf() == clienteRemetente.getCpf())
            {
                foreach(var Destinatario in banco.clientes)
                {
                    if(Destinatario.getCpf() == clienteDestinatario.getCpf())
                    {
                        if(clienteRemetente.getSaldo() >= valor)
                        {
                            Remetente.sacarPix(valor);
                            Destinatario.depositarPix(valor);
                            clienteDestinatario.transacoes.Add($"Pix de R${valor} recebido da pessoa: {clienteRemetente.getNome()}");
                            clienteRemetente.transacoes.Add($"Pix de R${valor} depositado para a pessoa: {clienteDestinatario.getNome()}");
                            Console.WriteLine("Pix realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Valor indisponivel para transferencia PIX!");
                        }
                        
                    }
                    
                }

            }
        }
    }

}
