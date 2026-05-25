using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings;
namespace GerenciaTransito;

internal class Relatorio
{
    
    public void gerarRelatorioVeiculosDisponivel(List<IVeiculo> listaDeOnibus)
    {
        var ecoding = Encoding.UTF8;
        var relatorio = "frotas_ativas.txt";
        using (var fluxoDeArquivo = new FileStream(relatorio, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoDeArquivo, ecoding))
        
            foreach (var v in listaDeOnibus)
            {
                // o GetType().Name é utilizado para obter o nome da classe do objeto, permitindo que o relatório seja mais informativo e fácil de entender, especialmente quando há diferentes tipos de veículos na lista.
                escritor.WriteLine($"{v.GetType().Name}: {v.NumeroDaLinha}, Capacidade: {v.Capacidade}, Status: {v.Status}");
            }
            Console.WriteLine("Operação finalizada e arquivo gravado com sucesso!");
        
    }
}
