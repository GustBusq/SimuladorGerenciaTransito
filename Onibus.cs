using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaTransito;

enum StatusOnibus
{
    EmMovimento,
    Parado,
    Manutencao
}

internal class Onibus
{
    public string NumeroDaLinha { get; private set; }
    public StatusOnibus Status { get; private set; }
    public int VelocidadeAtual { get; private set; }
    public int Capacidade { get; private set; }

    public Onibus(string numeroDaLinha,int capacidade )
    {
        NumeroDaLinha = numeroDaLinha;
        Status = StatusOnibus.Parado;
        Capacidade = capacidade;
    }

    public void MudarStatus(StatusOnibus novoStatus)
    {
        Status = novoStatus;
        Console.WriteLine($"Novo status do Onibus: {Status}");
    }
}
