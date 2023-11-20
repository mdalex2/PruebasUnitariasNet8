using MathExpert;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class CalculadorNUnitTes
    {
        #region TestSumaInt
        [Test]
        public void SumarDosNumeros_ObtenerSuma()
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            int resultado = calculador.Sumar(5, 6);


            //assert (verificación resultados)
            Assert.AreEqual(11, resultado);
        }

        [Test]
        public void IsImpar_IngresarNumeroPar_ObtenerFalse()
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(2);


            //assert (verificación resultados)
            Assert.IsFalse(resultado);
            Assert.That(resultado, Is.EqualTo(false)); 
        }
        
        [Test]
        [TestCase(11)] //para evaluar varios numeros de una misma vez
        [TestCase(13)]
        public void IsImpar_IngresarNumeroImpar_ObtenerFalse(int numero) //multiples parametros
        {

            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(numero);


            //assert (verificación resultados)
            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.EqualTo(true)); 
        }
        

        [Test]
        [TestCase(11,ExpectedResult = true)] //para evaluar varios numeros de una misma vez
        [TestCase(13,ExpectedResult = true)] //e indicarle de una vez el valor esperado
        [TestCase(12,ExpectedResult = false)] 
        public bool IsImpar_IngresarNumero_ObtenerTrueOrFalse(int numero) //combinado de test en una sola
        { 
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(numero);


            //assert (verificación resultados)
            return resultado;
            
        }

        #endregion TestSumaInt

        //------------------------------------------------------------

        #region TestSumaDouble

        [Test]
        [TestCase(5.2,10.2)] //15.4
        [TestCase(5.1,10.4)]  //15.6
        [TestCase(5.6,10.1)] //15.7
        public void SumarDosNumerosDoubles_IngresarNumeros_ObtenerSuma(double nro1, double nro2)
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            double resultado = calculador.SumarNrosDoubles(nro1, nro2);


            //assert (verificación resultados)
            Assert.AreEqual(15.4,resultado,1); //el 1 es para tener un rango adicional de tolerancia de 1 pto de diferencia en la prueba basada en el resultadoSuma
        }
        
        
        [Test]
        [TestCase(5.2,10.2,15.4)] //15.4 valor esperado
        [TestCase(5.1,10.4,15.5)]  //15.5
        [TestCase(5.6,10.1,15.7)] //15.7
        public void SumarDosNumerosDoubles_IngresarNumerosCase_ObtenerSuma(double nro1, double nro2,double valorEsperado)
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            double resultadoSuma = calculador.SumarNrosDoubles(nro1, nro2);


            //assert (verificación resultados)
            Assert.AreEqual(valorEsperado,resultadoSuma,0.0001);
        }


        #endregion TestSumaDouble

        //-----------------------------------------------------------

        #region TestListaInt
        [Test]
        public void ObtenerRangoImpares_IngresarInicioFinal_ObtenerImpares()
        {
            Calculador calculador = new Calculador();
            List<int> listaEsperadaImpares = new() { 3,5,7}; //rango de 3 a 8
            List<int> listaResultado = calculador.ObtenerRangoImpares(3,8);
            Assert.That(listaResultado,Is.EquivalentTo(listaEsperadaImpares)); //si las dos listas son iguales
            Assert.AreEqual(listaEsperadaImpares, listaResultado); // si las dos listas son iguales
            Assert.Contains(7, listaResultado);
            Assert.That(listaResultado,Does.Contain(7)); //si contiene # 7
            Assert.That(listaResultado,Is.Not.Empty); //si no está vacía
            Assert.That(listaResultado.Count,Is.EqualTo(3));
            Assert.That(listaResultado,Has.No.Member(6)); //si no contiene el nro 6
            Assert.That(listaResultado,Is.Ordered);
            //Assert.That(listaResultado,Is.Ordered.Descending); //verfica si viene orden desc
            Assert.That(listaResultado,Is.Ordered);
            Assert.That(listaResultado,Is.Unique); //si todos los elementos son unicos (no se repiten)
            

        }
        #endregion TestListaInt
    }
}
