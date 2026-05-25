using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaTransito;

internal interface IVeiculo
{
    public string NumeroDaLinha { get;}
    public int Capacidade { get;}
    public StatusVeiculo Status { get;}
    public void MudarStatus(StatusVeiculo novoStatus);
}
