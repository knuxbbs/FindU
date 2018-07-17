using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindU.Application.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var class1 = new Class1();
			var curso = new Curso { CodigoSupac = 387 };
			//var curso = new Curso { CodigoSupac = 196 };

			class1.VerificarMatricula("215215179", curso);
		}
	}
}
