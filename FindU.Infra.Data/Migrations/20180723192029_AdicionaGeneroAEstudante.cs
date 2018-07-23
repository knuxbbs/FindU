using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class AdicionaGeneroAEstudante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_OrientacaoSexual_OrientacaoSexualId",
                table: "Estudante");

            migrationBuilder.DropTable(
                name: "OrientacaoSexual");

            migrationBuilder.DropIndex(
                name: "IX_Estudante_OrientacaoSexualId",
                table: "Estudante");

            migrationBuilder.DropColumn(
                name: "OrientacaoSexualId",
                table: "Estudante");

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Estudante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrientacaoSexual",
                table: "Estudante",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Estudante");

            migrationBuilder.DropColumn(
                name: "OrientacaoSexual",
                table: "Estudante");

            migrationBuilder.AddColumn<int>(
                name: "OrientacaoSexualId",
                table: "Estudante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrientacaoSexual",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrientacaoSexual", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_OrientacaoSexualId",
                table: "Estudante",
                column: "OrientacaoSexualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_OrientacaoSexual_OrientacaoSexualId",
                table: "Estudante",
                column: "OrientacaoSexualId",
                principalTable: "OrientacaoSexual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
