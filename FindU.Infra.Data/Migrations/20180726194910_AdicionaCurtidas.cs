using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class AdicionaCurtidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curtida",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    UsuarioCurtidoId = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtida", x => new { x.UsuarioId, x.UsuarioCurtidoId });
                    table.ForeignKey(
                        name: "FK_Curtida_AspNetUsers_UsuarioCurtidoId",
                        column: x => x.UsuarioCurtidoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtida_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curtida_UsuarioCurtidoId",
                table: "Curtida",
                column: "UsuarioCurtidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtida");
        }
    }
}
