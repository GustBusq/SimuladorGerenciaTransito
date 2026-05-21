using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings;
namespace GerenciaTransito;

internal class Relatorio
{
    
    public void gerarRelatorioVeiculosDisponivel(List<Onibus> listaDeOnibus)
    {
        var ecoding = Encoding.UTF8;
        var relatorio = "frotas_ativas.txt";
        using (var fluxoDeArquivo = new FileStream(relatorio, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoDeArquivo, ecoding))
        
            foreach (var o in listaDeOnibus)
            { 
                escritor.WriteLine($"Onibus: {o.NumeroDaLinha}, Capacidade: {o.Capacidade}, Status: {o.Status}");
            }
            Console.WriteLine("Operação finalizada e arquivo gravado com sucesso!");
        
    }
}
