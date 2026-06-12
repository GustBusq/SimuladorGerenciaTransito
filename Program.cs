using GerenciaTransito;

Console.WriteLine("=== URBISTRANSIT - SISTEMA DE BANCO DE DADOS ===");


// ==========================================
// DESAFIO 1: O FILTRO (Buscar um dado específico com LINQ)
// ==========================================

using(var contexto = new TransitoContext())
{
    Console.WriteLine("\n[1] DESAFIO: Filtrando dados com LINQ...");

    // .FistOrDefault() vai busca o primeiro item do registro ou um valor null caso não tenha
    // O 'o => o.Id == 1' significa: "Me traga o Ônibus onde o Id seja igual a 1"
    var onibusEspecifico = contexto.Onibus.FirstOrDefault(o => o.id == 1);

    if (onibusEspecifico != null)
        Console.WriteLine("$\"✓ Ônibus encontrado! Linha: {onibusEspecifico.NumeroDaLinha} | Status Atual: {onibusEspecifico.Status}\"");
    else
        Console.WriteLine("X Nenhum ônibus com ID 1 foi encontrado no banco.");
}

// ==========================================
// DESAFIO 2: A ATUALIZAÇÃO (Update)
// ==========================================

using(var contextoUpdate = new TransitoContext())
{
    Console.WriteLine("\n[2] DESAFIO: Atualizando dados no banco...");

    // 1º Passo: Buscar o(s) dado(s) que queremos alterar
    var onibusParaAlterar = contextoUpdate.Onibus.FirstOrDefault(o => o.id == 1);

    if(onibusParaAlterar is not null)
    {
        // 2º Passo: Mudamos a propriedade dele usando o método criado dentro da propria claase
        onibusParaAlterar.MudarStatus(StatusVeiculo.EmMovimento);

        // 3º Passo: Avisamos o banco para salvar as alterações
        contextoUpdate.SaveChanges();
        Console.WriteLine("✓ Status do ônibus atualizado para 'EmMovimento' com sucesso no banco!");
    }
}
// ==========================================
// DESAFIO 3: A EXCLUSÃO (Delete)
// ==========================================
using(var contexto = new TransitoContext())
{
    Console.WriteLine("\n[3] DESAFIO: Excluindo dados do banco...");

    // Apenas para teste vamos criar um onibus temporario para excluir ele em seguida
    var onibusTemporario = new Onibus("Linha 999 - Sucata", 10);
    contexto.Onibus.Add(onibusTemporario); // Para salvar em memoria primeiro colocamos o banco, a tabela e em seguida o objeto
    contexto.SaveChanges(); // E depois salvamos as alterações no banco

    Console.WriteLine($"-> Criamos o ônibus '{onibusTemporario.NumeroDaLinha}' (ID: {onibusTemporario.id}) para o teste de exclusão.");

    // 1º Passo: Buscar o dado que queremos excluir
    var onibusParaExcluir = contexto.Onibus.FirstOrDefault(o => o.id == onibusTemporario.id);

    if (onibusParaExcluir is not null)
    {
        // 2º Passo: Remover ele do banco
        contexto.Onibus.Remove(onibusParaExcluir);
        //2º Passo: Gravamos a exclusão no arquivo fisico
        contexto.SaveChanges(); // E depois salvamos as alterações no banco
        Console.WriteLine($"✓ Ônibus '{onibusParaExcluir.NumeroDaLinha}' (ID: {onibusParaExcluir.id}) excluído com sucesso.");
    }
}
// ==========================================
// VALIDAÇÃO FINAL: VENDO OS RESULTADOS
// ==========================================
using(var contextoLeitura = new TransitoContext())
{
    Console.WriteLine("\n[3] VALIDAÇÃO: Listando todos os ônibus para verificar as alterações...");
    var listaDeOnibus = contextoLeitura.Onibus.ToList();
    if (listaDeOnibus.Count > 0)
    {
        foreach (var onibus in listaDeOnibus)
        {
            Console.WriteLine($"ID: {onibus.id} | Linha: {onibus.NumeroDaLinha} | Capacidade: {onibus.Capacidade} | Status: {onibus.Status}");
        }
    }
    else
    {
        Console.WriteLine("Nenhum ônibus encontrado no banco.");
    }
}