using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class AdicionaSobrenomeDeEstudante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobre",
                table: "Estudante",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Estudante",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Estudante");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Estudante",
                newName: "Sobre");
        }
    }
}
