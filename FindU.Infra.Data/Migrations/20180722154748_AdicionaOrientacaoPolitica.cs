using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class AdicionaOrientacaoPolitica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "OrientacaoPolitica",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "OrientacaoPolitica",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Conservador de direita" },
                    { 2, "Muito conservador, de direita" },
                    { 3, "Centrista" },
                    { 4, "Esquerda-liberal" },
                    { 5, "Muito liberal, de esquerda" },
                    { 6, "Libertário" },
                    { 7, "Libertário ao extremo" },
                    { 8, "Autoritário" },
                    { 9, "Autoritário ao extremo" },
                    { 10, "Depende" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrientacaoPolitica",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "OrientacaoPolitica",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }
    }
}
