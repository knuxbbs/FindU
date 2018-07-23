using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class AdicionaTipoDeAtracaoEConsumoBebida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_OrientacaoPolitica_OrientacaoPoliticaId",
                table: "Estudante");

            migrationBuilder.AlterColumn<int>(
                name: "OrientacaoPoliticaId",
                table: "Estudante",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoDeConsumoBebidaId",
                table: "Estudante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoDeAtracao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeAtracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeConsumoBebida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeConsumoBebida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudanteHasTipoDeAtracao",
                columns: table => new
                {
                    EstudanteId = table.Column<int>(nullable: false),
                    TipoDeAtracaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteHasTipoDeAtracao", x => new { x.EstudanteId, x.TipoDeAtracaoId });
                    table.ForeignKey(
                        name: "FK_EstudanteHasTipoDeAtracao_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudanteHasTipoDeAtracao_TipoDeAtracaoId",
                        column: x => x.TipoDeAtracaoId,
                        principalTable: "TipoDeAtracao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoDeAtracao",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Convicção" },
                    { 16, "Riqueza material" },
                    { 15, "Aventura" },
                    { 14, "Nadar nu" },
                    { 13, "Poder" },
                    { 12, "Cabelos compridos" },
                    { 11, "Flertar" },
                    { 9, "Piercing(s)" },
                    { 10, "Dançar" },
                    { 7, "Tatuagens" },
                    { 6, "Sarcasmo" },
                    { 5, "Demonstrações públicas de afeto" },
                    { 4, "Inteligência" },
                    { 3, "Material erótico" },
                    { 2, "Luz de velas" },
                    { 8, "Tempestades" }
                });

            migrationBuilder.InsertData(
                table: "TipoDeConsumoBebida",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 3, "Regularmente" },
                    { 1, "Socialmente" },
                    { 2, "De vez em quando" },
                    { 4, "Excessivamente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_TipoDeConsumoBebidaId",
                table: "Estudante",
                column: "TipoDeConsumoBebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteHasTipoDeAtracao_TipoDeAtracaoId",
                table: "EstudanteHasTipoDeAtracao",
                column: "TipoDeAtracaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_OrientacaoPolitica_OrientacaoPoliticaId",
                table: "Estudante",
                column: "OrientacaoPoliticaId",
                principalTable: "OrientacaoPolitica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_TipoDeConsumoBebida_TipoDeConsumoBebidaId",
                table: "Estudante",
                column: "TipoDeConsumoBebidaId",
                principalTable: "TipoDeConsumoBebida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_OrientacaoPolitica_OrientacaoPoliticaId",
                table: "Estudante");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_TipoDeConsumoBebida_TipoDeConsumoBebidaId",
                table: "Estudante");

            migrationBuilder.DropTable(
                name: "EstudanteHasTipoDeAtracao");

            migrationBuilder.DropTable(
                name: "TipoDeConsumoBebida");

            migrationBuilder.DropTable(
                name: "TipoDeAtracao");

            migrationBuilder.DropIndex(
                name: "IX_Estudante_TipoDeConsumoBebidaId",
                table: "Estudante");

            migrationBuilder.DropColumn(
                name: "TipoDeConsumoBebidaId",
                table: "Estudante");

            migrationBuilder.AlterColumn<int>(
                name: "OrientacaoPoliticaId",
                table: "Estudante",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_OrientacaoPolitica_OrientacaoPoliticaId",
                table: "Estudante",
                column: "OrientacaoPoliticaId",
                principalTable: "OrientacaoPolitica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
