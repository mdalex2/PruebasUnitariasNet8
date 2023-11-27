using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CalculadorGradoXUnitTests
    {
        private CalculadorGrado calculadorGrado;




        #region MultiplesEscenarios de prueba

        public CalculadorGradoXUnitTests()
        {
            calculadorGrado = new CalculadorGrado();
        }

        [Fact]
        public void CalculadorGrado_IngresarPuntaje95Asistencia90_ObtenerGradoA()
        {
            calculadorGrado.Puntaje = 95;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("A",resultado);
        }

        [Fact]
        public void CalculadorGrado_IngresarPuntaje85Asistencia90_ObtenerGradoB()
        {
            calculadorGrado.Puntaje = 85;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("B",resultado);
        }

        [Fact]
        public void CalculadorGrado_IngresarPuntaje65Asistencia90_ObtenerGradoC()
        {
            calculadorGrado.Puntaje = 65;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("C", resultado);
        }

        [Fact]
        public void CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGradoF()
        {
            calculadorGrado.Puntaje = 55;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("F", resultado);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGradoFCase(int puntaje, int porcentajeAsistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = porcentajeAsistencia;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("F", resultado);
        }

        [Theory]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 90, "A")]
        [InlineData(50, 90, "F")]
        public void CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGrado(int puntaje, int porcentajeAsistencia,string expectedResult)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = porcentajeAsistencia;
            string resultado = calculadorGrado.ObtenerGrado();
            Assert.Equal(expectedResult, resultado);
        }


        #endregion MultiplesEscenarios de prueba
    }
}
