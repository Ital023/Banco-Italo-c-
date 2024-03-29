﻿namespace PrimeiroProjeto.Modelos;
class Cliente : Pessoa
{
    public Cliente(string nome, int cpf, int senha)
    {
        setNome(nome);
        setCpf(cpf);
        this.senha = senha;
    }
    public Cliente(string nome, int cpf,int senha,double valor)
    {
        setNome(nome);
        setCpf(cpf);
        this.senha = senha;
        depositar(valor);
    }

    private double saldo { get; set; }
    private int senha { get; set; }

    public List<string> transacoes = new List<string>();

    


    public void depositar(double valor)
    {
        if(transacoes.Count == 0)
        {
            saldo += valor;
            transacoes.Add("");

        }
        else
        {
            DateTime horaAtual = DateTime.Now;

            saldo += valor;
            transacoes.Add($"Depositado o valor: R${valor} as {horaAtual.ToLocalTime()}");
        }
        
    }

    public void sacar(double valor)
    {
        if (saldo < valor)
        {
            Console.WriteLine("saldo insuficiente");
            Thread.Sleep(3000);
        }
        else
        {
            DateTime horaAtual = DateTime.Now;
            saldo -= valor;
            transacoes.Add($"Sacado o valor: R${valor} as {horaAtual.ToLocalTime()}");
        }

    }

    public void depositarPix(double valor)
    {
        saldo += valor;
    }

    public void sacarPix(double valor)
    {
        if (saldo < valor)
        {
            Console.WriteLine("saldo insuficiente");
            Thread.Sleep(3000);
        }
        else
        {
            saldo -= valor;
        }

    }
    public double getSaldo()
    {
        return saldo;
    }

    public int getSenha()
    {
        return senha;
    }

    public void visualizarTransacoes()
    {
        foreach(string transacao in transacoes)
        {
            Console.WriteLine(transacao);
        }
    }

    public int getNumTransacoes()
    {
        int i = 0;

        while(i < transacoes.Count)
        {
            i++;
        }
        return i;
    }

}