using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindU.Infra.Data.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaConhecimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrientacaoPolitica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrientacaoPolitica", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UnidadeUniversitaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false),
                    AreaConhecimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeUniversitaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeUniversitaria_AreaConhecimento_AreaConhecimentoId",
                        column: x => x.AreaConhecimentoId,
                        principalTable: "AreaConhecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false),
                    CodigoSupac = table.Column<int>(nullable: false),
                    UnidadeUniversitariaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_UnidadeUniversitaria_UnidadeUniversitariaId",
                        column: x => x.UnidadeUniversitariaId,
                        principalTable: "UnidadeUniversitaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    AnoIngresso = table.Column<int>(nullable: false),
                    Formado = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CaminhoFoto = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sobre = table.Column<string>(nullable: false),
                    OrientacaoSexualId = table.Column<int>(nullable: false),
                    ReligiaoId = table.Column<int>(nullable: false),
                    OrientacaoPoliticaId = table.Column<int>(nullable: false),
                    Localizacao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudante_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudante_OrientacaoPolitica_OrientacaoPoliticaId",
                        column: x => x.OrientacaoPoliticaId,
                        principalTable: "OrientacaoPolitica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudante_OrientacaoSexual_OrientacaoSexualId",
                        column: x => x.OrientacaoSexualId,
                        principalTable: "OrientacaoSexual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudante_Religiao_ReligiaoId",
                        column: x => x.ReligiaoId,
                        principalTable: "Religiao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudante_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AreaConhecimento",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "ÁREA I - Ciências Físicas, Matemática e Tecnologia" },
                    { 2, "ÁREA II - Ciências Biológicas e Profissões da Saúde" },
                    { 3, "ÁREA III - Filosofia e Ciências Humanas" },
                    { 4, "ÁREA IV - Letras" },
                    { 5, "ÁREA V - Artes" },
                    { 6, "Bacharelados Interdisciplinares" }
                });

            migrationBuilder.InsertData(
                table: "UnidadeUniversitaria",
                columns: new[] { "Id", "AreaConhecimentoId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "ARQUITETURA" },
                    { 28, 5, "MÚSICA" },
                    { 27, 5, "DANÇA" },
                    { 26, 5, "BELAS ARTES" },
                    { 25, 4, "LETRAS" },
                    { 24, 3, "CIÊNCIAS DA INFORMAÇÃO" },
                    { 23, 3, "PSICOLOGIA" },
                    { 22, 3, "FILOSOFIA E CIÊNCIAS HUMANAS" },
                    { 21, 3, "EDUCAÇÃO" },
                    { 20, 3, "DIREITO" },
                    { 19, 3, "COMUNICAÇÃO" },
                    { 18, 3, "CIÊNCIAS ECONÔMICAS" },
                    { 17, 3, "CIÊNCIAS CONTÁBEIS" },
                    { 16, 3, "ADMINISTRAÇÃO" },
                    { 15, 2, "SAÚDE COLETIVA" },
                    { 14, 2, "ODONTOLOGIA" },
                    { 13, 2, "NUTRIÇÃO" },
                    { 12, 2, "MEDICINA VETERINÁRIA" },
                    { 11, 2, "MEDICINA" },
                    { 10, 2, "CIÊNCIAS DA SAÚDE" },
                    { 9, 2, "FARMÁCIA" },
                    { 8, 2, "ENFERMAGEM" },
                    { 7, 2, "BIOLOGIA" },
                    { 6, 1, "QUIMICA" },
                    { 5, 1, "MATEMÁTICA" },
                    { 4, 1, "GEOCIÊNCIAS" },
                    { 3, 1, "FÍSICA" },
                    { 2, 1, "POLITÉCNICA" },
                    { 29, 5, "TEATRO" },
                    { 30, 6, "HUMANIDADES, ARTES E CIÊNCIAS" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CodigoSupac", "Nome", "UnidadeUniversitariaId" },
                values: new object[,]
                {
                    { 1, 101, "Arquitetura e Urbanismo", 1 },
                    { 67, 381, "Arquivologia (noturno)", 24 },
                    { 66, 317, "Arquivologia", 24 },
                    { 65, 303, "Biblioteconomia e Documentação", 24 },
                    { 64, 325, "Serviço Social", 23 },
                    { 63, 313, "Psicologia", 23 },
                    { 62, 383, "Gênero e Diversidade (noturno)", 22 },
                    { 61, 311, "Museologia", 22 },
                    { 60, 386, "História (noturno)", 22 },
                    { 59, 310, "História", 22 },
                    { 58, 309, "Filosofia", 22 },
                    { 57, 306, "Ciências Sociais", 22 },
                    { 56, 315, "Educação Física", 21 },
                    { 55, 385, "Pedagogia (noturno)", 21 },
                    { 54, 312, "Pedagogia", 21 },
                    { 53, 209, "Ciências Naturais", 21 },
                    { 52, 382, "Direito (noturno)", 20 },
                    { 51, 308, "Direito", 20 },
                    { 50, 307, "Comunicação", 19 },
                    { 49, 305, "Ciências Econômicas", 18 },
                    { 68, 401, "Letras Vernáculas", 25 },
                    { 48, 380, "Ciências Contábeis (noturno)", 17 },
                    { 69, 480, "Letras Vernáculas (noturno)", 25 },
                    { 71, 403, "Língua Estrangeira", 25 },
                    { 90, 387, "Humanidades (noturno)", 30 },
                    { 89, 327, "Humanidades", 30 },
                    { 88, 286, "Saúde (noturno)", 30 },
                    { 87, 226, "Saúde", 30 },
                    { 86, 190, "Ciência e Tecnologia", 30 },
                    { 85, 189, "Ciência e Tecnologia (noturno)", 30 },
                    { 84, 506, "Artes Cênicas - Direção Teatral", 29 },
                    { 83, 514, "Música Popular", 28 },
                    { 82, 509, "Instrumento", 28 },
                    { 81, 508, "Canto", 28 },
                    { 80, 507, "Licenciatura em Música", 28 },
                    { 79, 502, "Composição e Regência", 28 },
                    { 78, 581, "Dança (noturno)", 27 },
                    { 77, 503, "Licenciatura em Dança", 27 },
                    { 76, 513, "Decoração", 26 },
                    { 75, 512, "Desenho Industrial", 26 },
                    { 74, 505, "Licenciatura em Desenho e Plástica", 26 },
                    { 73, 501, "Artes Plásticas", 26 },
                    { 72, 481, "Língua Estrangeira (noturno)", 25 },
                    { 70, 402, "Letras Vernáculas com Língua Estrangeira", 25 },
                    { 47, 304, "Ciências Contábeis", 17 },
                    { 46, 384, "Gestão Pública e Gestão Social", 16 },
                    { 45, 316, "Administração", 16 },
                    { 20, 119, "Oceanografia", 4 },
                    { 19, 118, "Geofísica", 4 },
                    { 18, 110, "Geologia", 4 },
                    { 17, 182, "Geografia (noturno)", 4 },
                    { 16, 109, "Geografia", 4 },
                    { 15, 181, "Física (noturno)", 3 },
                    { 14, 108, "Física", 3 },
                    { 13, 197, "Transporte Terrestre: Gestão do Transporte e Trânsito", 2 },
                    { 12, 194, "Engenharia de Agrimensura e Cartográfica", 2 },
                    { 11, 188, "Engenharia de Controle e Automação de Processo (noturno)", 2 },
                    { 10, 186, "Engenharia da Computação (noturno)", 2 },
                    { 9, 185, "Engenharia de Produção (noturno)", 2 },
                    { 8, 107, "Engenharia Sanitária e Ambiental", 2 },
                    { 7, 106, "Engenharia Química", 2 },
                    { 6, 105, "Engenharia Mecânica", 2 },
                    { 5, 104, "Engenharia Elétrica", 2 },
                    { 4, 103, "Engenharia de Minas", 2 },
                    { 3, 102, "Engenharia Civil", 2 },
                    { 2, 187, "Arquitetura e Urbanismo (noturno)", 1 },
                    { 21, 111, "Matemática", 5 },
                    { 22, 183, "Matemática (noturno)", 5 },
                    { 23, 112, "Ciência da Computação", 5 },
                    { 24, 195, "Sistemas de Informação", 5 },
                    { 44, 314, "Secretariado", 16 },
                    { 43, 283, "Saúde Coletiva (noturno)", 15 },
                    { 42, 208, "Odontologia", 14 },
                    { 41, 282, "Gastronomia (noturno)", 13 },
                    { 40, 207, "Nutrição", 13 },
                    { 39, 219, "Zootecnia", 12 },
                    { 38, 206, "Medicina Veterinária", 12 },
                    { 37, 205, "Medicina", 11 },
                    { 36, 284, "Biotecnologia (noturno)", 10 },
                    { 91, 515, "Artes", 30 },
                    { 35, 222, "Fisioterapia", 10 },
                    { 33, 281, "Farmácia (noturno)", 9 },
                    { 32, 204, "Farmácia", 9 },
                    { 31, 203, "Enfermagem", 8 },
                    { 30, 280, "Ciências Biológicas (noturno)", 7 },
                    { 29, 202, "Ciências Biológicas", 7 },
                    { 28, 184, "Química (noturno)", 6 },
                    { 27, 113, "Química", 6 },
                    { 26, 196, "Computação", 5 },
                    { 25, 116, "Estatística", 5 },
                    { 34, 210, "Fonoaudiologia", 10 },
                    { 92, 580, "Artes (noturno)", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_CodigoSupac",
                table: "Curso",
                column: "CodigoSupac",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_UnidadeUniversitariaId",
                table: "Curso",
                column: "UnidadeUniversitariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_CursoId",
                table: "Estudante",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_OrientacaoPoliticaId",
                table: "Estudante",
                column: "OrientacaoPoliticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_OrientacaoSexualId",
                table: "Estudante",
                column: "OrientacaoSexualId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_ReligiaoId",
                table: "Estudante",
                column: "ReligiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_UsuarioId",
                table: "Estudante",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeUniversitaria_AreaConhecimentoId",
                table: "UnidadeUniversitaria",
                column: "AreaConhecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "OrientacaoPolitica");

            migrationBuilder.DropTable(
                name: "OrientacaoSexual");

            migrationBuilder.DropTable(
                name: "Religiao");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UnidadeUniversitaria");

            migrationBuilder.DropTable(
                name: "AreaConhecimento");
        }
    }
}
