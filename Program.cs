using GerenciaTransito;
/*
var gerenciador = new GerenciadorDados();
var listaDeVeiculos = gerenciador.CarregarVeiculos("veiculos_cadastrados.txt");

listaDeVeiculos[0].MudarStatus(StatusVeiculo.EmMovimento);
listaDeVeiculos[1].MudarStatus(StatusVeiculo.EmMovimento);
listaDeVeiculos[2].MudarStatus(StatusVeiculo.EmMovimento);

var veiculosEmMovimento = listaDeVeiculos.Where(o => o.Status == StatusVeiculo.EmMovimento).ToList();

Relatorio relatorio = new Relatorio();

var metrosExistente = listaDeVeiculos.Count(o => o.GetType().Name == "Metro");
Console.WriteLine($"Numero de Metros existentes: {metrosExistente}");

int capacidadeTotalDeOnibus = listaDeVeiculos.Where( o => o.GetType().Name == "Onibus").Sum(c => c.Capacidade);
Console.WriteLine($"Capacidade de passageiros, somadas de todos os Onibus: {capacidadeTotalDeOnibus}");

var transportesQueMaisCarrega = listaDeVeiculos.OrderByDescending(t => t.Capacidade).ToList();

foreach(var t in transportesQueMaisCarrega)
{
    Console.WriteLine($"Veiculo: {t.NumeroDaLinha} - Capicidade: {t.Capacidade}");
}

try
{
    relatorio.gerarRelatorioVeiculosDisponivel(veiculosEmMovimento);
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"Diretório não encontrado: {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Sem permissão para gravar o arquivo: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Erro de disco ou arquivo bloqueado: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
}
finally
{
    Console.WriteLine("Processo encerrado.");
}
*/

Console.WriteLine("=== URBISTRANSIT - SISTEMA DE BANCO DE DADOS ===");

// 1. Vamos abrir nossa mesa de controle (Contexto) usando using
// O using vai servir para abrirmos e fecharmos o arquivo de forma segura, e correta
using(var contexto = new TransitoContext())
{
    Console.WriteLine("\n[1] Criando novos veículos na memória...");
    // Criando alguns veículos na memória (ainda não estão no banco)
    var onibus = new Onibus("Linha 102 - Central", 45);
    var metro = new Metro("Linha Azul - Estação Sul", 250);

    Console.WriteLine("[2] Adicionando os veículos na mesa de controle...");
    // Vamos adicionar esses veiculos na nossa mesa de controle
    // Avisamos ao Entity Framework que queremos salvar esses objetos nas tabelas correspondentes
    contexto.Onibus.Add(onibus); // aqui tenho que apontar para a tabela de Onibus, onde irei setar os dados do onibus criado
    contexto.Metros.Add(metro);// aqui tenho que apontar para a tabela de Onibus, onde irei setar os dados do onibus criado

    Console.WriteLine("[3] Gravando fisicamente no banco de dados (SQL)...");
    // Pegamos agora tudo que foi apenas adionado na mesa de controle e mandamos de fato para o banco de dados
    contexto.SaveChanges();   // aqui é onde o Entity Framework vai pegar os dados que estão na mesa de controle e criar as linhas correspondentes no banco de dados

    Console.WriteLine("Veiculos salvos com sucesso!");
}

// 2. Agora vamos abrir o banco de dados e ler os dados que acabamos de salvar
using (var contextoLeitura = new TransitoContext())
{
    Console.WriteLine("\n[4] Buscando dados diretamente do arquivo do Banco de Dados:");
    // Aqui vamos usar o Entity Framework para ler os dados do banco de dados e mostrar na tela
    var listaDeOnibus = contextoLeitura.Onibus.ToList(); // aqui o Entity Framework vai ler a tabela de Onibus e criar uma lista de objetos Onibus na memória
    var listaDeMetros = contextoLeitura.Metros.ToList(); // aqui o Entity Framework vai ler a tabela de Metro e criar uma lista de objetos Metro na memória
    Console.WriteLine($"\n--- Ônibus Cadastrados ({listaDeOnibus.Count}) ---");
    foreach (var onibus in listaDeOnibus)
    {
        // Repare que o 'Id' agora será gerado automaticamente pelo banco (1, 2, 3...)
        Console.WriteLine($"ID:{onibus.id} | linha: {onibus.NumeroDaLinha} | Capacidade: {onibus.Capacidade}");
    }
    Console.WriteLine($"\n--- Metros Cadastrados ({listaDeMetros.Count}) ---");
    foreach (var metro in listaDeMetros)
    {
        Console.WriteLine($"ID:{metro.id} | linha: {metro.NumeroDaLinha} | Capacidade: {metro.Capacidade}");
    }

}

