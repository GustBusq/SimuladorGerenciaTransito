using Microsoft.EntityFrameworkCore;
namespace GerenciaTransito;

// O ": DbContext" avisa ao C# que esta classe controla um banco de dados real
internal class TransitoContext : DbContext
{
    // O DbSet diz: "Eu quero uma tabela no banco chamada 'Onibus' baseada na minha classe Onibus"
    public DbSet<Onibus> Onibus { get; set; }

    // E outra tabela chamada 'Metros' baseada na classe Metro
    public DbSet<Metro> Metros { get; set; }

    // Este método serve para configurar ONDE e COMO o banco vai funcionar
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Estamos dizendo: "Use o SQLite e salve tudo em um arquivo chamado transito.db"
        optionsBuilder.UseSqlite("Data Source=transito.db");
    }
}