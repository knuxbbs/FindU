using FindU.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindU.Application.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var class1 = new SupacDataImporter();
			var curso = new Curso { CodigoSupac = 387 };
			//var curso = new Curso { CodigoSupac = 196 };

			class1.ValidarMatricula("215215179", curso);
		}
	}
}
