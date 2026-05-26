using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaTransito;

internal class GerenciadorDados
{
    // vamos ler a lista do tipo IVeiculo, para realizar o cadastro no sitema
    public List<IVeiculo> CarregarVeiculos(string caminhoArquivo)
    {
        List<IVeiculo> listaCriada = new List<IVeiculo>();
        // 1. Verificar antes de tudo se o arquivo existe
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return listaCriada; // Retorna uma lista vazia
        }

        // 2. Abrir o arquivo e ler linha a linha
        using(var leitor = new StreamReader(caminhoArquivo))
        {
            // aqui iremos ler linha a linha do nosso arquivo enquanto ele não for null
            string? linha;
            while ((linha = leitor.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;
                //Para blindar o teu leitor contra utilizadores que digitam espaços sem querer utilizei trim
                // Vamos agora separar os dados usando um delimitador
                var partes = linha.Split(',');

                var tipo = partes[0].Trim();
                var numero = partes[1].Trim();
                // aqui convertemos esse pedaço para inteiro.
                var capacidade = int.Parse(partes[2]);

                if (tipo == "Onibus")
                {
                    listaCriada.Add(new Onibus(numero, capacidade));
                }
                else if (tipo == "Metro")
                {
                    listaCriada.Add(new Metro(numero, capacidade));
                }
                else
                {
                    Console.WriteLine("Não identificado o tipo");
                }
            }
        }
        return listaCriada;
    }
}
