namespace PrimeiroProjeto.Modelos;
internal class Pix
{
    public void realizarPix(Banco banco,int cpfRemetente,int cpfDestinatario,double valor)
    {
        foreach(var clienteRemetente in banco.clientes)
        {
            if(clienteRemetente.getCpf() == cpfRemetente)
            {
                foreach(var clienteDestinatario in banco.clientes)
                {
                    if(clienteDestinatario.getCpf() == cpfDestinatario)
                    {
                        clienteRemetente.sacar(valor);
                        clienteDestinatario.depositar(valor);
                    }
                    
                }

            }
        }
    }

}
