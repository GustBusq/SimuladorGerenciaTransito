using GerenciaTransito;

var listaDeVeiculos = new List<IVeiculo>()
{
    new Onibus("001", 25),
    new Onibus("002", 26),
    new Onibus("003", 28),
    new Onibus("004", 22),
    new Metro("005", 320),
    new Metro("006", 320),
    new Metro("007", 320),
    new Metro("008", 320),
};

var onibus1 = listaDeVeiculos[0];
var onibus2 = listaDeVeiculos[1];
var onibus3 = listaDeVeiculos[2];
var onibus4 = listaDeVeiculos[3];
var metro1 = listaDeVeiculos[4];
var metro2 = listaDeVeiculos[5];
var metro3 = listaDeVeiculos[6];
var metro4 = listaDeVeiculos[7];

onibus1.MudarStatus(StatusVeiculo.EmMovimento);
onibus2.MudarStatus(StatusVeiculo.Manutencao);
onibus3.MudarStatus(StatusVeiculo.EmMovimento);
onibus4.MudarStatus(StatusVeiculo.EmMovimento);
metro1.MudarStatus(StatusVeiculo.Parado);
metro2.MudarStatus(StatusVeiculo.EmMovimento);
metro3.MudarStatus(StatusVeiculo.Parado);
metro4.MudarStatus(StatusVeiculo.EmMovimento);


var veiculosEmMovimento = listaDeVeiculos.Where(o => o.Status == StatusVeiculo.EmMovimento).ToList();

Relatorio relatorio = new Relatorio();

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