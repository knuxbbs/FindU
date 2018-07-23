using FindU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class CursoMap : IEntityTypeConfiguration<Curso>
	{
		public void Configure(EntityTypeBuilder<Curso> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.HasMaxLength(100)
				.IsRequired();

			builder.HasIndex(c => c.CodigoSupac).IsUnique();

			builder.Property(c => c.UnidadeUniversitariaId)
				.IsRequired();

			var i = 1;

			builder.HasData(
				//1 - ARQUITETURA
				new Curso { Id = i++, Nome = "Arquitetura e Urbanismo",
					CodigoSupac = 101, UnidadeUniversitariaId = 1 },
				new Curso { Id = i++, Nome = "Arquitetura e Urbanismo (noturno)",
					CodigoSupac = 187, UnidadeUniversitariaId = 1 },

				//2 - POLITÉCNICA
				new Curso { Id = i++, Nome = "Engenharia Civil",
					CodigoSupac = 102, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia de Minas",
					CodigoSupac = 103, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia Elétrica",
					CodigoSupac = 104, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia Mecânica",
					CodigoSupac = 105, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia Química",
					CodigoSupac = 106, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia Sanitária e Ambiental",
					CodigoSupac = 107, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia de Produção (noturno)",
					CodigoSupac = 185, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia da Computação (noturno)",
					CodigoSupac = 186, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia de Controle e Automação de Processo (noturno)",
					CodigoSupac = 188, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Engenharia de Agrimensura e Cartográfica",
					CodigoSupac = 194, UnidadeUniversitariaId = 2 },
				new Curso { Id = i++, Nome = "Transporte Terrestre: Gestão do Transporte e Trânsito",
					CodigoSupac = 197, UnidadeUniversitariaId = 2 },

				//3 - FÍSICA
				new Curso { Id = i++, Nome = "Física",
					CodigoSupac = 108, UnidadeUniversitariaId = 3 },
				new Curso { Id = i++, Nome = "Física (noturno)",
					CodigoSupac = 181, UnidadeUniversitariaId = 3 },

				//4 - GEOCIÊNCIAS
				new Curso { Id = i++, Nome = "Geografia",
					CodigoSupac = 109, UnidadeUniversitariaId = 4 },
				new Curso { Id = i++, Nome = "Geografia (noturno)",
					CodigoSupac = 182, UnidadeUniversitariaId = 4 },
				new Curso { Id = i++, Nome = "Geologia",
					CodigoSupac = 110, UnidadeUniversitariaId = 4 },
				new Curso { Id = i++, Nome = "Geofísica",
					CodigoSupac = 118, UnidadeUniversitariaId = 4 },
				new Curso { Id = i++, Nome = "Oceanografia",
					CodigoSupac = 119, UnidadeUniversitariaId = 4 },

				//5 - MATEMÁTICA
				new Curso { Id = i++, Nome = "Matemática",
					CodigoSupac = 111, UnidadeUniversitariaId = 5 },
				new Curso { Id = i++, Nome = "Matemática (noturno)",
					CodigoSupac = 183, UnidadeUniversitariaId = 5 },
				new Curso { Id = i++, Nome = "Ciência da Computação",
					CodigoSupac = 112, UnidadeUniversitariaId = 5 },
				new Curso { Id = i++, Nome = "Sistemas de Informação",
					CodigoSupac = 195, UnidadeUniversitariaId = 5 },
				new Curso { Id = i++, Nome = "Estatística",
					CodigoSupac = 116, UnidadeUniversitariaId = 5 },
				new Curso { Id = i++, Nome = "Computação",
					CodigoSupac = 196, UnidadeUniversitariaId = 5 },

				//6 - QUÍMICA
				new Curso { Id = i++, Nome = "Química",
					CodigoSupac = 113, UnidadeUniversitariaId = 6 },
				new Curso { Id = i++, Nome = "Química (noturno)",
					CodigoSupac = 184, UnidadeUniversitariaId = 6 },

				//7 - BIOLOGIA
				new Curso { Id = i++, Nome = "Ciências Biológicas",
					CodigoSupac = 202, UnidadeUniversitariaId = 7 },
				new Curso { Id = i++, Nome = "Ciências Biológicas (noturno)",
					CodigoSupac = 280, UnidadeUniversitariaId = 7 },

				//8 - ENFERMAGEM
				new Curso { Id = i++, Nome = "Enfermagem",
					CodigoSupac = 203, UnidadeUniversitariaId = 8 },

				//9 - FARMÁCIA
				new Curso { Id = i++, Nome = "Farmácia",
					CodigoSupac = 204, UnidadeUniversitariaId = 9 },
				new Curso { Id = i++, Nome = "Farmácia (noturno)",
					CodigoSupac = 281, UnidadeUniversitariaId = 9 },

				//10 - CIÊNCIAS DA SAÚDE
				new Curso { Id = i++, Nome = "Fonoaudiologia",
					CodigoSupac = 210, UnidadeUniversitariaId = 10 },
				new Curso { Id = i++, Nome = "Fisioterapia",
					CodigoSupac = 222, UnidadeUniversitariaId = 10 },
				new Curso { Id = i++, Nome = "Biotecnologia (noturno)",
					CodigoSupac = 284, UnidadeUniversitariaId = 10 },

				//11 - MEDICINA
				new Curso { Id = i++, Nome = "Medicina",
					CodigoSupac = 205, UnidadeUniversitariaId = 11 },

				//12 - MEDICINA VETERINÁRIA
				new Curso { Id = i++, Nome = "Medicina Veterinária",
					CodigoSupac = 206, UnidadeUniversitariaId = 12 },
				new Curso { Id = i++, Nome = "Zootecnia",
					CodigoSupac = 219, UnidadeUniversitariaId = 12 },

				//13 - NUTRIÇÃO
				new Curso { Id = i++, Nome = "Nutrição",
					CodigoSupac = 207, UnidadeUniversitariaId = 13 },
				new Curso { Id = i++, Nome = "Gastronomia (noturno)",
					CodigoSupac = 282, UnidadeUniversitariaId = 13 },

				//14 - ODONTOLOGIA
				new Curso { Id = i++, Nome = "Odontologia",
					CodigoSupac = 208, UnidadeUniversitariaId = 14 },

				//15 - SAÚDE COLETIVA
				new Curso { Id = i++, Nome = "Saúde Coletiva (noturno)",
					CodigoSupac = 283, UnidadeUniversitariaId = 15 },

				//16 - ADMINISTRAÇÃO
				new Curso { Id = i++, Nome = "Secretariado",
					CodigoSupac = 314, UnidadeUniversitariaId = 16 },
				new Curso { Id = i++, Nome = "Administração",
					CodigoSupac = 316, UnidadeUniversitariaId = 16 },
				new Curso { Id = i++, Nome = "Gestão Pública e Gestão Social",
					CodigoSupac = 384, UnidadeUniversitariaId = 16 },

				//17 - CIÊNCIAS CONTÁBEIS
				new Curso { Id = i++, Nome = "Ciências Contábeis",
					CodigoSupac = 304, UnidadeUniversitariaId = 17 },
				new Curso { Id = i++, Nome = "Ciências Contábeis (noturno)",
					CodigoSupac = 380, UnidadeUniversitariaId = 17 },

				//18 - CIÊNCIAS ECONÔMICAS
				new Curso { Id = i++, Nome = "Ciências Econômicas",
					CodigoSupac = 305, UnidadeUniversitariaId = 18 },

				//19 - COMUNICAÇÃO
				new Curso { Id = i++, Nome = "Comunicação",
					CodigoSupac = 307, UnidadeUniversitariaId = 19 },

				//20 - DIREITO
				new Curso { Id = i++, Nome = "Direito",
					CodigoSupac = 308, UnidadeUniversitariaId = 20 },
				new Curso { Id = i++, Nome = "Direito (noturno)",
					CodigoSupac = 382, UnidadeUniversitariaId = 20 },

				//21 - EDUCAÇÃO
				new Curso { Id = i++, Nome = "Ciências Naturais",
					CodigoSupac = 209, UnidadeUniversitariaId = 21 },
				new Curso { Id = i++, Nome = "Pedagogia",
					CodigoSupac = 312, UnidadeUniversitariaId = 21 },
				new Curso { Id = i++, Nome = "Pedagogia (noturno)",
					CodigoSupac = 385, UnidadeUniversitariaId = 21 },
				new Curso { Id = i++, Nome = "Educação Física",
					CodigoSupac = 315, UnidadeUniversitariaId = 21 },

				//22 - FILOSOFIA E CIÊNCIAS HUMANAS
				new Curso { Id = i++, Nome = "Ciências Sociais",
					CodigoSupac = 306, UnidadeUniversitariaId = 22 },
				new Curso { Id = i++, Nome = "Filosofia",
					CodigoSupac = 309, UnidadeUniversitariaId = 22 },
				new Curso { Id = i++, Nome = "História",
					CodigoSupac = 310, UnidadeUniversitariaId = 22 },
				new Curso { Id = i++, Nome = "História (noturno)",
					CodigoSupac = 386, UnidadeUniversitariaId = 22 },
				new Curso { Id = i++, Nome = "Museologia",
					CodigoSupac = 311, UnidadeUniversitariaId = 22 },
				new Curso { Id = i++, Nome = "Gênero e Diversidade (noturno)",
					CodigoSupac = 383, UnidadeUniversitariaId = 22 },

				//23 - PSICOLOGIA
				new Curso { Id = i++, Nome = "Psicologia",
					CodigoSupac = 313, UnidadeUniversitariaId = 23 },
				new Curso { Id = i++, Nome = "Serviço Social",
					CodigoSupac = 325, UnidadeUniversitariaId = 23 },

				//24 - CIÊNCIAS DA INFORMAÇÃO
				new Curso { Id = i++, Nome = "Biblioteconomia e Documentação",
					CodigoSupac = 303, UnidadeUniversitariaId = 24 },
				new Curso { Id = i++, Nome = "Arquivologia",
					CodigoSupac = 317, UnidadeUniversitariaId = 24 },
				new Curso { Id = i++, Nome = "Arquivologia (noturno)",
					CodigoSupac = 381, UnidadeUniversitariaId = 24 },

				//25 - LETRAS
				new Curso { Id = i++, Nome = "Letras Vernáculas",
					CodigoSupac = 401, UnidadeUniversitariaId = 25 },
				new Curso { Id = i++, Nome = "Letras Vernáculas (noturno)",
					CodigoSupac = 480, UnidadeUniversitariaId = 25 },
				new Curso { Id = i++, Nome = "Letras Vernáculas com Língua Estrangeira",
					CodigoSupac = 402, UnidadeUniversitariaId = 25 },
				new Curso { Id = i++, Nome = "Língua Estrangeira",
					CodigoSupac = 403, UnidadeUniversitariaId = 25 },
				new Curso { Id = i++, Nome = "Língua Estrangeira (noturno)",
					CodigoSupac = 481, UnidadeUniversitariaId = 25 },

				//26 - BELAS ARTES
				new Curso { Id = i++, Nome = "Artes Plásticas",
					CodigoSupac = 501, UnidadeUniversitariaId = 26 },
				new Curso { Id = i++, Nome = "Licenciatura em Desenho e Plástica",
					CodigoSupac = 505, UnidadeUniversitariaId = 26 },
				new Curso { Id = i++, Nome = "Desenho Industrial",
					CodigoSupac = 512, UnidadeUniversitariaId = 26 },
				new Curso { Id = i++, Nome = "Decoração",
					CodigoSupac = 513, UnidadeUniversitariaId = 26 },

				//27 - DANÇA
				new Curso { Id = i++, Nome = "Licenciatura em Dança",
					CodigoSupac = 503, UnidadeUniversitariaId = 27 },
				new Curso { Id = i++, Nome = "Dança (noturno)",
					CodigoSupac = 581, UnidadeUniversitariaId = 27 },

				//28 - MÚSICA
				new Curso { Id = i++, Nome = "Composição e Regência",
					CodigoSupac = 502, UnidadeUniversitariaId = 28 },
				new Curso { Id = i++, Nome = "Licenciatura em Música",
					CodigoSupac = 507, UnidadeUniversitariaId = 28 },
				new Curso { Id = i++, Nome = "Canto",
					CodigoSupac = 508, UnidadeUniversitariaId = 28 },
				new Curso { Id = i++, Nome = "Instrumento",
					CodigoSupac = 509, UnidadeUniversitariaId = 28 },
				new Curso { Id = i++, Nome = "Música Popular",
					CodigoSupac = 514, UnidadeUniversitariaId = 28 },

				//29 - TEATRO
				new Curso { Id = i++, Nome = "Artes Cênicas - Direção Teatral",
					CodigoSupac = 506, UnidadeUniversitariaId = 29 },
				
				//30 - HUMANIDADES, ARTES E CIÊNCIAS
				new Curso { Id = i++, Nome = "Ciência e Tecnologia (noturno)",
					CodigoSupac = 189, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Ciência e Tecnologia",
					CodigoSupac = 190, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Saúde",
					CodigoSupac = 226, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Saúde (noturno)",
					CodigoSupac = 286, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Humanidades",
					CodigoSupac = 327, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Humanidades (noturno)",
					CodigoSupac = 387, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Artes",
					CodigoSupac = 515, UnidadeUniversitariaId = 30 },
				new Curso { Id = i++, Nome = "Artes (noturno)",
					CodigoSupac = 580, UnidadeUniversitariaId = 30 }
			);
		}
	}
}
