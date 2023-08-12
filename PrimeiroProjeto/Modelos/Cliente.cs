﻿namespace PrimeiroProjeto.Modelos;
class Cliente : Pessoa
{
    public Cliente(string nome,int cpf,int id,string senha)
    {
        this.id = id;
        setNome(nome);
        setCpf(cpf);
        this.senha = senha;

    }

    private int id { get; set; }
    private double saldo { get; set; }
    private string senha { get; set; }
    

    public void depositar(double valor)
    {
        saldo -= valor;
    }
    
    public void sacar(double valor)
    {
        saldo += valor;
    }

    


    /*public void transferir(double valor,Cliente pessoa,Banco banco)
    {
        banco.clientes();
        foreach (var  in banco) { }
    }*/



    public int getId()
    {
        return id;
    }

    public double getSaldo()
    {
        return saldo;
    }

    public string getSenha()
    {
        return senha;
    }

    


}