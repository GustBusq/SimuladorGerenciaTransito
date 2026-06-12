using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciaTransito.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelaMetro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Metro",
                table: "Metro");

            migrationBuilder.RenameTable(
                name: "Metro",
                newName: "Metros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metros",
                table: "Metros",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Metros",
                table: "Metros");

            migrationBuilder.RenameTable(
                name: "Metros",
                newName: "Metro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metro",
                table: "Metro",
                column: "id");
        }
    }
}
