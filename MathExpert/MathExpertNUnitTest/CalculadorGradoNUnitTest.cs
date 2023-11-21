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
    public class CalculadorGradoNUnitTest
    {
        private CalculadorGrado calculadorGrado;

        [SetUp]
        public void Setup()
        {
            calculadorGrado = new CalculadorGrado();
        }


        #region MultiplesEscenarios de prueba


        [Test]
        public void CalculadorGrado_IngresarPuntaje95Asistencia90_ObtenerGradoA()
        {
            calculadorGrado.Puntaje = 95;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("A"));
        }
        
        [Test]
        public void CalculadorGrado_IngresarPuntaje85Asistencia90_ObtenerGradoB()
        {
            calculadorGrado.Puntaje = 85;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("B"));
        }
        
        [Test]
        public void CalculadorGrado_IngresarPuntaje65Asistencia90_ObtenerGradoC()
        {
            calculadorGrado.Puntaje = 65;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("C"));
        }
        
        [Test]
        public void CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGradoF()
        {
            calculadorGrado.Puntaje = 55;
            calculadorGrado.PorcentajeAsistencia = 90;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("F"));
        }
        
        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGradoFCase(int puntaje, int porcentajeAsistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = porcentajeAsistencia;
            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("F"));
        }
        
        [Test]
        [TestCase(95,55,ExpectedResult = "F")]
        [TestCase(65,55,ExpectedResult = "F")]
        [TestCase(50,90,ExpectedResult = "F")]
        [TestCase(85,90,ExpectedResult = "B")]
        [TestCase(65,90,ExpectedResult = "C")]
        [TestCase(95,90,ExpectedResult = "A")]
        public string CalculadorGrado_IngresarPuntaje55Asistencia90_ObtenerGrado(int puntaje, int porcentajeAsistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = porcentajeAsistencia;
            string resultado = calculadorGrado.ObtenerGrado();
            return resultado;
        }


        #endregion MultiplesEscenarios de prueba
    }
}
