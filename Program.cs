using GerenciaTransito;

var listaDeOnibus = new List<Onibus>()
{
    new Onibus("001", 25),
    new Onibus("002", 26),
    new Onibus("003", 28),
    new Onibus("004", 22)
};

var onibus1 = listaDeOnibus[0];
var onibus2 = listaDeOnibus[1];
var onibus3 = listaDeOnibus[2];
var onibus4 = listaDeOnibus[3];

onibus1.MudarStatus(StatusOnibus.EmMovimento);
onibus2.MudarStatus(StatusOnibus.Manutencao);
onibus3.MudarStatus(StatusOnibus.EmMovimento);
onibus4.MudarStatus(StatusOnibus.EmMovimento);

var onibusEmMovimento = listaDeOnibus.Where(o => o.Status == StatusOnibus.EmMovimento).ToList();

Relatorio relatorio = new Relatorio();

relatorio.gerarRelatorioVeiculosDisponivel(onibusEmMovimento);