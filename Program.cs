using GerenciaTransito;

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