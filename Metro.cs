using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaTransito;

internal class Metro: IVeiculo
{
    public string NumeroDaLinha { get; private set; }
    public StatusVeiculo Status { get; private set; }
    public int VelocidadeAtual { get; private set; }
    public int Capacidade { get; private set; }

    public Metro(string numeroDaLinha, int capacidade)
    {
        NumeroDaLinha = numeroDaLinha;
        Status = StatusVeiculo.Parado;
        Capacidade = capacidade;
    }

    public void MudarStatus(StatusVeiculo novoStatus)
    {
        Status = novoStatus;
        Console.WriteLine($"Novo status do Metro: {Status}");
    }
}
