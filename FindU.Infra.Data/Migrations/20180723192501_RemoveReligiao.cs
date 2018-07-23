using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class RemoveReligiao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudante_Religiao_ReligiaoId",
                table: "Estudante");

            migrationBuilder.DropTable(
                name: "Religiao");

            migrationBuilder.DropIndex(
                name: "IX_Estudante_ReligiaoId",
                table: "Estudante");

            migrationBuilder.DropColumn(
                name: "ReligiaoId",
                table: "Estudante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReligiaoId",
                table: "Estudante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Religiao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religiao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_ReligiaoId",
                table: "Estudante",
                column: "ReligiaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudante_Religiao_ReligiaoId",
                table: "Estudante",
                column: "ReligiaoId",
                principalTable: "Religiao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
