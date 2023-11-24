using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CalculadorXUnitTests
    {
        #region TestXUnitSumaInt
        [Fact]
        public void SumarDosNumeros_ObtenerSuma()
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            int resultado = calculador.Sumar(5, 6);


            //assert (verificación resultados)
            Assert.Equal(11, resultado);
        }

        [Fact]
        public void IsImpar_IngresarNumeroPar_ObtenerFalse()
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(2);


            //assert (verificación resultados)
            Assert.False(resultado);
        }

        [Theory]
        [InlineData(11)] //para evaluar varios numeros de una misma vez
        [InlineData(13)]
        public void IsImpar_IngresarNumeroImpar_ObtenerFalse(int numero) //multiples parametros
        {

            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(numero);


            //assert (verificación resultados)
            Assert.True(resultado);
        }


        [Theory]
        [InlineData(11,true)] //para evaluar varios numeros de una misma vez
        [InlineData(13,true)] //e indicarle de una vez el valor esperado
        [InlineData(12,false)]
        public void IsImpar_IngresarNumero_ObtenerTrueOrFalse(int numero, bool expectedResult) //combinado de test en una sola
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            var resultado = calculador.IsImpar(numero);


            //assert (verificación resultados)
            Assert.Equal(expectedResult, resultado);

        }

        #endregion TestXUnitSumaInt

        //------------------------------------------------------------

        #region TestXUnitSumaDouble

        [Theory]
        [InlineData(5.2, 10.6)] //15.8
        [InlineData(5.1, 10.4)]  //15.6
        [InlineData(5.6, 10.1)] //15.7
        public void SumarDosNumerosDoubles_IngresarNumeros_ObtenerSuma(double nro1, double nro2)
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            double resultado = calculador.SumarNrosDoubles(nro1, nro2);


            //assert (verificación resultados)
            Assert.Equal(15.8, resultado, 0); //el 0 es para que redondee a 16.0
        }


        [Theory]
        [InlineData(5.2, 10.2, 15.4)] //15.4 valor esperado
        [InlineData(5.1, 10.4, 15.5)]  //15.5
        [InlineData(5.6, 10.1, 15.7)] //15.7
        public void SumarDosNumerosDoubles_IngresarNumerosCase_ObtenerSuma(double nro1, double nro2, double valorEsperado)
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            double resultadoSuma = calculador.SumarNrosDoubles(nro1, nro2);


            //assert (verificación resultados)
            Assert.Equal(valorEsperado, resultadoSuma, 0.0001);
        }


        #endregion TestXUnitSumaDouble

        //-----------------------------------------------------------

        #region TestXUnitListaInt
        [Fact]
        public void ObtenerRangoImpares_IngresarInicioFinal_ObtenerImpares()
        {
            Calculador calculador = new Calculador();
            List<int> listaEsperadaImpares = new() { 3, 5, 7 }; //rango de 3 a 8
            List<int> listaResultado = calculador.ObtenerRangoImpares(3, 8);
            Assert.Multiple(() => //verificar todos los asserts de pruebas al mismo tiempo
            {
                Assert.Equal(listaEsperadaImpares, listaResultado); // si las dos listas son iguales
                Assert.Contains(7, listaResultado);
                
                Assert.NotEmpty(listaResultado); //si no está vacía
                Assert.Equal(3,listaResultado.Count);
                Assert.DoesNotContain(6,listaResultado); //si no contiene el nro 6
                Assert.Equal(listaResultado.OrderBy(o => 0), listaResultado); // si está ordenada asc
            });
        }
        #endregion TestXUnitListaInt
    }
}
