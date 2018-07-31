﻿// <auto-generated />
using System;
using FindU.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindU.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180731132146_TornaUsuarioIdUnico")]
    partial class TornaUsuarioIdUnico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FindU.Models.AreaConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("AreaConhecimento");

                    b.HasData(
                        new { Id = 1, Nome = "ÁREA I - Ciências Físicas, Matemática e Tecnologia" },
                        new { Id = 2, Nome = "ÁREA II - Ciências Biológicas e Profissões da Saúde" },
                        new { Id = 3, Nome = "ÁREA III - Filosofia e Ciências Humanas" },
                        new { Id = 4, Nome = "ÁREA IV - Letras" },
                        new { Id = 5, Nome = "ÁREA V - Artes" },
                        new { Id = 6, Nome = "Bacharelados Interdisciplinares" }
                    );
                });

            modelBuilder.Entity("FindU.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoSupac");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.Property<int>("UnidadeUniversitariaId");

                    b.HasKey("Id");

                    b.HasIndex("CodigoSupac")
                        .IsUnique();

                    b.HasIndex("UnidadeUniversitariaId");

                    b.ToTable("Curso");

                    b.HasData(
                        new { Id = 1, CodigoSupac = 101, Nome = "Arquitetura e Urbanismo", UnidadeUniversitariaId = 1 },
                        new { Id = 2, CodigoSupac = 187, Nome = "Arquitetura e Urbanismo (noturno)", UnidadeUniversitariaId = 1 },
                        new { Id = 3, CodigoSupac = 102, Nome = "Engenharia Civil", UnidadeUniversitariaId = 2 },
                        new { Id = 4, CodigoSupac = 103, Nome = "Engenharia de Minas", UnidadeUniversitariaId = 2 },
                        new { Id = 5, CodigoSupac = 104, Nome = "Engenharia Elétrica", UnidadeUniversitariaId = 2 },
                        new { Id = 6, CodigoSupac = 105, Nome = "Engenharia Mecânica", UnidadeUniversitariaId = 2 },
                        new { Id = 7, CodigoSupac = 106, Nome = "Engenharia Química", UnidadeUniversitariaId = 2 },
                        new { Id = 8, CodigoSupac = 107, Nome = "Engenharia Sanitária e Ambiental", UnidadeUniversitariaId = 2 },
                        new { Id = 9, CodigoSupac = 185, Nome = "Engenharia de Produção (noturno)", UnidadeUniversitariaId = 2 },
                        new { Id = 10, CodigoSupac = 186, Nome = "Engenharia da Computação (noturno)", UnidadeUniversitariaId = 2 },
                        new { Id = 11, CodigoSupac = 188, Nome = "Engenharia de Controle e Automação de Processo (noturno)", UnidadeUniversitariaId = 2 },
                        new { Id = 12, CodigoSupac = 194, Nome = "Engenharia de Agrimensura e Cartográfica", UnidadeUniversitariaId = 2 },
                        new { Id = 13, CodigoSupac = 197, Nome = "Transporte Terrestre: Gestão do Transporte e Trânsito", UnidadeUniversitariaId = 2 },
                        new { Id = 14, CodigoSupac = 108, Nome = "Física", UnidadeUniversitariaId = 3 },
                        new { Id = 15, CodigoSupac = 181, Nome = "Física (noturno)", UnidadeUniversitariaId = 3 },
                        new { Id = 16, CodigoSupac = 109, Nome = "Geografia", UnidadeUniversitariaId = 4 },
                        new { Id = 17, CodigoSupac = 182, Nome = "Geografia (noturno)", UnidadeUniversitariaId = 4 },
                        new { Id = 18, CodigoSupac = 110, Nome = "Geologia", UnidadeUniversitariaId = 4 },
                        new { Id = 19, CodigoSupac = 118, Nome = "Geofísica", UnidadeUniversitariaId = 4 },
                        new { Id = 20, CodigoSupac = 119, Nome = "Oceanografia", UnidadeUniversitariaId = 4 },
                        new { Id = 21, CodigoSupac = 111, Nome = "Matemática", UnidadeUniversitariaId = 5 },
                        new { Id = 22, CodigoSupac = 183, Nome = "Matemática (noturno)", UnidadeUniversitariaId = 5 },
                        new { Id = 23, CodigoSupac = 112, Nome = "Ciência da Computação", UnidadeUniversitariaId = 5 },
                        new { Id = 24, CodigoSupac = 195, Nome = "Sistemas de Informação", UnidadeUniversitariaId = 5 },
                        new { Id = 25, CodigoSupac = 116, Nome = "Estatística", UnidadeUniversitariaId = 5 },
                        new { Id = 26, CodigoSupac = 196, Nome = "Computação", UnidadeUniversitariaId = 5 },
                        new { Id = 27, CodigoSupac = 113, Nome = "Química", UnidadeUniversitariaId = 6 },
                        new { Id = 28, CodigoSupac = 184, Nome = "Química (noturno)", UnidadeUniversitariaId = 6 },
                        new { Id = 29, CodigoSupac = 202, Nome = "Ciências Biológicas", UnidadeUniversitariaId = 7 },
                        new { Id = 30, CodigoSupac = 280, Nome = "Ciências Biológicas (noturno)", UnidadeUniversitariaId = 7 },
                        new { Id = 31, CodigoSupac = 203, Nome = "Enfermagem", UnidadeUniversitariaId = 8 },
                        new { Id = 32, CodigoSupac = 204, Nome = "Farmácia", UnidadeUniversitariaId = 9 },
                        new { Id = 33, CodigoSupac = 281, Nome = "Farmácia (noturno)", UnidadeUniversitariaId = 9 },
                        new { Id = 34, CodigoSupac = 210, Nome = "Fonoaudiologia", UnidadeUniversitariaId = 10 },
                        new { Id = 35, CodigoSupac = 222, Nome = "Fisioterapia", UnidadeUniversitariaId = 10 },
                        new { Id = 36, CodigoSupac = 284, Nome = "Biotecnologia (noturno)", UnidadeUniversitariaId = 10 },
                        new { Id = 37, CodigoSupac = 205, Nome = "Medicina", UnidadeUniversitariaId = 11 },
                        new { Id = 38, CodigoSupac = 206, Nome = "Medicina Veterinária", UnidadeUniversitariaId = 12 },
                        new { Id = 39, CodigoSupac = 219, Nome = "Zootecnia", UnidadeUniversitariaId = 12 },
                        new { Id = 40, CodigoSupac = 207, Nome = "Nutrição", UnidadeUniversitariaId = 13 },
                        new { Id = 41, CodigoSupac = 282, Nome = "Gastronomia (noturno)", UnidadeUniversitariaId = 13 },
                        new { Id = 42, CodigoSupac = 208, Nome = "Odontologia", UnidadeUniversitariaId = 14 },
                        new { Id = 43, CodigoSupac = 283, Nome = "Saúde Coletiva (noturno)", UnidadeUniversitariaId = 15 },
                        new { Id = 44, CodigoSupac = 314, Nome = "Secretariado", UnidadeUniversitariaId = 16 },
                        new { Id = 45, CodigoSupac = 316, Nome = "Administração", UnidadeUniversitariaId = 16 },
                        new { Id = 46, CodigoSupac = 384, Nome = "Gestão Pública e Gestão Social", UnidadeUniversitariaId = 16 },
                        new { Id = 47, CodigoSupac = 304, Nome = "Ciências Contábeis", UnidadeUniversitariaId = 17 },
                        new { Id = 48, CodigoSupac = 380, Nome = "Ciências Contábeis (noturno)", UnidadeUniversitariaId = 17 },
                        new { Id = 49, CodigoSupac = 305, Nome = "Ciências Econômicas", UnidadeUniversitariaId = 18 },
                        new { Id = 50, CodigoSupac = 307, Nome = "Comunicação", UnidadeUniversitariaId = 19 },
                        new { Id = 51, CodigoSupac = 308, Nome = "Direito", UnidadeUniversitariaId = 20 },
                        new { Id = 52, CodigoSupac = 382, Nome = "Direito (noturno)", UnidadeUniversitariaId = 20 },
                        new { Id = 53, CodigoSupac = 209, Nome = "Ciências Naturais", UnidadeUniversitariaId = 21 },
                        new { Id = 54, CodigoSupac = 312, Nome = "Pedagogia", UnidadeUniversitariaId = 21 },
                        new { Id = 55, CodigoSupac = 385, Nome = "Pedagogia (noturno)", UnidadeUniversitariaId = 21 },
                        new { Id = 56, CodigoSupac = 315, Nome = "Educação Física", UnidadeUniversitariaId = 21 },
                        new { Id = 57, CodigoSupac = 306, Nome = "Ciências Sociais", UnidadeUniversitariaId = 22 },
                        new { Id = 58, CodigoSupac = 309, Nome = "Filosofia", UnidadeUniversitariaId = 22 },
                        new { Id = 59, CodigoSupac = 310, Nome = "História", UnidadeUniversitariaId = 22 },
                        new { Id = 60, CodigoSupac = 386, Nome = "História (noturno)", UnidadeUniversitariaId = 22 },
                        new { Id = 61, CodigoSupac = 311, Nome = "Museologia", UnidadeUniversitariaId = 22 },
                        new { Id = 62, CodigoSupac = 383, Nome = "Gênero e Diversidade (noturno)", UnidadeUniversitariaId = 22 },
                        new { Id = 63, CodigoSupac = 313, Nome = "Psicologia", UnidadeUniversitariaId = 23 },
                        new { Id = 64, CodigoSupac = 325, Nome = "Serviço Social", UnidadeUniversitariaId = 23 },
                        new { Id = 65, CodigoSupac = 303, Nome = "Biblioteconomia e Documentação", UnidadeUniversitariaId = 24 },
                        new { Id = 66, CodigoSupac = 317, Nome = "Arquivologia", UnidadeUniversitariaId = 24 },
                        new { Id = 67, CodigoSupac = 381, Nome = "Arquivologia (noturno)", UnidadeUniversitariaId = 24 },
                        new { Id = 68, CodigoSupac = 401, Nome = "Letras Vernáculas", UnidadeUniversitariaId = 25 },
                        new { Id = 69, CodigoSupac = 480, Nome = "Letras Vernáculas (noturno)", UnidadeUniversitariaId = 25 },
                        new { Id = 70, CodigoSupac = 402, Nome = "Letras Vernáculas com Língua Estrangeira", UnidadeUniversitariaId = 25 },
                        new { Id = 71, CodigoSupac = 403, Nome = "Língua Estrangeira", UnidadeUniversitariaId = 25 },
                        new { Id = 72, CodigoSupac = 481, Nome = "Língua Estrangeira (noturno)", UnidadeUniversitariaId = 25 },
                        new { Id = 73, CodigoSupac = 501, Nome = "Artes Plásticas", UnidadeUniversitariaId = 26 },
                        new { Id = 74, CodigoSupac = 505, Nome = "Licenciatura em Desenho e Plástica", UnidadeUniversitariaId = 26 },
                        new { Id = 75, CodigoSupac = 512, Nome = "Desenho Industrial", UnidadeUniversitariaId = 26 },
                        new { Id = 76, CodigoSupac = 513, Nome = "Decoração", UnidadeUniversitariaId = 26 },
                        new { Id = 77, CodigoSupac = 503, Nome = "Licenciatura em Dança", UnidadeUniversitariaId = 27 },
                        new { Id = 78, CodigoSupac = 581, Nome = "Dança (noturno)", UnidadeUniversitariaId = 27 },
                        new { Id = 79, CodigoSupac = 502, Nome = "Composição e Regência", UnidadeUniversitariaId = 28 },
                        new { Id = 80, CodigoSupac = 507, Nome = "Licenciatura em Música", UnidadeUniversitariaId = 28 },
                        new { Id = 81, CodigoSupac = 508, Nome = "Canto", UnidadeUniversitariaId = 28 },
                        new { Id = 82, CodigoSupac = 509, Nome = "Instrumento", UnidadeUniversitariaId = 28 },
                        new { Id = 83, CodigoSupac = 514, Nome = "Música Popular", UnidadeUniversitariaId = 28 },
                        new { Id = 84, CodigoSupac = 506, Nome = "Artes Cênicas - Direção Teatral", UnidadeUniversitariaId = 29 },
                        new { Id = 85, CodigoSupac = 189, Nome = "Ciência e Tecnologia (noturno)", UnidadeUniversitariaId = 30 },
                        new { Id = 86, CodigoSupac = 190, Nome = "Ciência e Tecnologia", UnidadeUniversitariaId = 30 },
                        new { Id = 87, CodigoSupac = 226, Nome = "Saúde", UnidadeUniversitariaId = 30 },
                        new { Id = 88, CodigoSupac = 286, Nome = "Saúde (noturno)", UnidadeUniversitariaId = 30 },
                        new { Id = 89, CodigoSupac = 327, Nome = "Humanidades", UnidadeUniversitariaId = 30 },
                        new { Id = 90, CodigoSupac = 387, Nome = "Humanidades (noturno)", UnidadeUniversitariaId = 30 },
                        new { Id = 91, CodigoSupac = 515, Nome = "Artes", UnidadeUniversitariaId = 30 },
                        new { Id = 92, CodigoSupac = 580, Nome = "Artes (noturno)", UnidadeUniversitariaId = 30 }
                    );
                });

            modelBuilder.Entity("FindU.Models.Curtida", b =>
                {
                    b.Property<string>("UsuarioId");

                    b.Property<string>("UsuarioCurtidoId");

                    b.Property<DateTime>("Data");

                    b.HasKey("UsuarioId", "UsuarioCurtidoId");

                    b.HasIndex("UsuarioCurtidoId");

                    b.ToTable("Curtida");
                });

            modelBuilder.Entity("FindU.Models.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoIngresso");

                    b.Property<string>("CaminhoFoto")
                        .IsRequired();

                    b.Property<int>("CursoId");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<bool>("Formado");

                    b.Property<int>("Genero");

                    b.Property<string>("Localizacao")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("OrientacaoPoliticaId");

                    b.Property<int>("OrientacaoSexual");

                    b.Property<string>("Sobrenome");

                    b.Property<int?>("TipoDeConsumoBebidaId");

                    b.Property<string>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("OrientacaoPoliticaId");

                    b.HasIndex("TipoDeConsumoBebidaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("FindU.Models.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("FindU.Models.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("FindU.Models.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FindU.Models.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("FindU.Models.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("FindU.Models.Identity.UserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("FindU.Models.Identity.UserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FindU.Models.Joins.EstudanteHasTipoDeAtracao", b =>
                {
                    b.Property<int>("EstudanteId");

                    b.Property<int>("TipoDeAtracaoId");

                    b.HasKey("EstudanteId", "TipoDeAtracaoId");

                    b.HasIndex("TipoDeAtracaoId");

                    b.ToTable("EstudanteHasTipoDeAtracao");
                });

            modelBuilder.Entity("FindU.Models.OrientacaoPolitica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("OrientacaoPolitica");

                    b.HasData(
                        new { Id = 1, Nome = "Conservador de direita" },
                        new { Id = 2, Nome = "Muito conservador, de direita" },
                        new { Id = 3, Nome = "Centrista" },
                        new { Id = 4, Nome = "Esquerda-liberal" },
                        new { Id = 5, Nome = "Muito liberal, de esquerda" },
                        new { Id = 6, Nome = "Libertário" },
                        new { Id = 7, Nome = "Libertário ao extremo" },
                        new { Id = 8, Nome = "Autoritário" },
                        new { Id = 9, Nome = "Autoritário ao extremo" },
                        new { Id = 10, Nome = "Depende" }
                    );
                });

            modelBuilder.Entity("FindU.Models.TipoDeAtracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TipoDeAtracao");

                    b.HasData(
                        new { Id = 1, Nome = "Convicção" },
                        new { Id = 2, Nome = "Luz de velas" },
                        new { Id = 3, Nome = "Material erótico" },
                        new { Id = 4, Nome = "Inteligência" },
                        new { Id = 5, Nome = "Demonstrações públicas de afeto" },
                        new { Id = 6, Nome = "Sarcasmo" },
                        new { Id = 7, Nome = "Tatuagens" },
                        new { Id = 8, Nome = "Tempestades" },
                        new { Id = 9, Nome = "Piercing(s)" },
                        new { Id = 10, Nome = "Dançar" },
                        new { Id = 11, Nome = "Flertar" },
                        new { Id = 12, Nome = "Cabelos compridos" },
                        new { Id = 13, Nome = "Poder" },
                        new { Id = 14, Nome = "Nadar nu" },
                        new { Id = 15, Nome = "Aventura" },
                        new { Id = 16, Nome = "Riqueza material" }
                    );
                });

            modelBuilder.Entity("FindU.Models.TipoDeConsumoBebida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TipoDeConsumoBebida");

                    b.HasData(
                        new { Id = 1, Nome = "Socialmente" },
                        new { Id = 2, Nome = "De vez em quando" },
                        new { Id = 3, Nome = "Regularmente" },
                        new { Id = 4, Nome = "Excessivamente" }
                    );
                });

            modelBuilder.Entity("FindU.Models.UnidadeUniversitaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaConhecimentoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AreaConhecimentoId");

                    b.ToTable("UnidadeUniversitaria");

                    b.HasData(
                        new { Id = 1, AreaConhecimentoId = 1, Nome = "ARQUITETURA" },
                        new { Id = 2, AreaConhecimentoId = 1, Nome = "POLITÉCNICA" },
                        new { Id = 3, AreaConhecimentoId = 1, Nome = "FÍSICA" },
                        new { Id = 4, AreaConhecimentoId = 1, Nome = "GEOCIÊNCIAS" },
                        new { Id = 5, AreaConhecimentoId = 1, Nome = "MATEMÁTICA" },
                        new { Id = 6, AreaConhecimentoId = 1, Nome = "QUIMICA" },
                        new { Id = 7, AreaConhecimentoId = 2, Nome = "BIOLOGIA" },
                        new { Id = 8, AreaConhecimentoId = 2, Nome = "ENFERMAGEM" },
                        new { Id = 9, AreaConhecimentoId = 2, Nome = "FARMÁCIA" },
                        new { Id = 10, AreaConhecimentoId = 2, Nome = "CIÊNCIAS DA SAÚDE" },
                        new { Id = 11, AreaConhecimentoId = 2, Nome = "MEDICINA" },
                        new { Id = 12, AreaConhecimentoId = 2, Nome = "MEDICINA VETERINÁRIA" },
                        new { Id = 13, AreaConhecimentoId = 2, Nome = "NUTRIÇÃO" },
                        new { Id = 14, AreaConhecimentoId = 2, Nome = "ODONTOLOGIA" },
                        new { Id = 15, AreaConhecimentoId = 2, Nome = "SAÚDE COLETIVA" },
                        new { Id = 16, AreaConhecimentoId = 3, Nome = "ADMINISTRAÇÃO" },
                        new { Id = 17, AreaConhecimentoId = 3, Nome = "CIÊNCIAS CONTÁBEIS" },
                        new { Id = 18, AreaConhecimentoId = 3, Nome = "CIÊNCIAS ECONÔMICAS" },
                        new { Id = 19, AreaConhecimentoId = 3, Nome = "COMUNICAÇÃO" },
                        new { Id = 20, AreaConhecimentoId = 3, Nome = "DIREITO" },
                        new { Id = 21, AreaConhecimentoId = 3, Nome = "EDUCAÇÃO" },
                        new { Id = 22, AreaConhecimentoId = 3, Nome = "FILOSOFIA E CIÊNCIAS HUMANAS" },
                        new { Id = 23, AreaConhecimentoId = 3, Nome = "PSICOLOGIA" },
                        new { Id = 24, AreaConhecimentoId = 3, Nome = "CIÊNCIAS DA INFORMAÇÃO" },
                        new { Id = 25, AreaConhecimentoId = 4, Nome = "LETRAS" },
                        new { Id = 26, AreaConhecimentoId = 5, Nome = "BELAS ARTES" },
                        new { Id = 27, AreaConhecimentoId = 5, Nome = "DANÇA" },
                        new { Id = 28, AreaConhecimentoId = 5, Nome = "MÚSICA" },
                        new { Id = 29, AreaConhecimentoId = 5, Nome = "TEATRO" },
                        new { Id = 30, AreaConhecimentoId = 6, Nome = "HUMANIDADES, ARTES E CIÊNCIAS" }
                    );
                });

            modelBuilder.Entity("FindU.Models.Curso", b =>
                {
                    b.HasOne("FindU.Models.UnidadeUniversitaria", "UnidadeUniversitaria")
                        .WithMany()
                        .HasForeignKey("UnidadeUniversitariaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Curtida", b =>
                {
                    b.HasOne("FindU.Models.Identity.User", "UsuarioCurtido")
                        .WithMany()
                        .HasForeignKey("UsuarioCurtidoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FindU.Models.Identity.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FindU.Models.Estudante", b =>
                {
                    b.HasOne("FindU.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindU.Models.OrientacaoPolitica", "OrientacaoPolitica")
                        .WithMany()
                        .HasForeignKey("OrientacaoPoliticaId");

                    b.HasOne("FindU.Models.TipoDeConsumoBebida", "TipoDeConsumoBebida")
                        .WithMany()
                        .HasForeignKey("TipoDeConsumoBebidaId");

                    b.HasOne("FindU.Models.Identity.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("FindU.Models.Identity.RoleClaim", b =>
                {
                    b.HasOne("FindU.Models.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Identity.UserClaim", b =>
                {
                    b.HasOne("FindU.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Identity.UserLogin", b =>
                {
                    b.HasOne("FindU.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Identity.UserRole", b =>
                {
                    b.HasOne("FindU.Models.Identity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindU.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Identity.UserToken", b =>
                {
                    b.HasOne("FindU.Models.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.Joins.EstudanteHasTipoDeAtracao", b =>
                {
                    b.HasOne("FindU.Models.Estudante", "Estudante")
                        .WithMany("TiposDeAtracao")
                        .HasForeignKey("EstudanteId")
                        .HasConstraintName("FK_EstudanteHasTipoDeAtracao_EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindU.Models.TipoDeAtracao", "TipoDeAtracao")
                        .WithMany("Estudantes")
                        .HasForeignKey("TipoDeAtracaoId")
                        .HasConstraintName("FK_EstudanteHasTipoDeAtracao_TipoDeAtracaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindU.Models.UnidadeUniversitaria", b =>
                {
                    b.HasOne("FindU.Models.AreaConhecimento", "AreaConhecimento")
                        .WithMany()
                        .HasForeignKey("AreaConhecimentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
