using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class TornaUsuarioIdUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudante_UsuarioId",
                table: "Estudante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_UsuarioId",
                table: "Estudante",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudante_UsuarioId",
                table: "Estudante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_UsuarioId",
                table: "Estudante",
                column: "UsuarioId");
        }
    }
}
