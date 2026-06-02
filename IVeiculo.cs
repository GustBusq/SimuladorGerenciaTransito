using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaTransito;

internal interface IVeiculo
{
    public int id { get; } // o banco usará isso como chave primaria
    public string NumeroDaLinha { get;}
    public int Capacidade { get;}
    public StatusVeiculo Status { get;}
    public void MudarStatus(StatusVeiculo novoStatus);
}
