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
        public void IsImpar_IngresarNumeroImpar_ObtenerFalse(int numero)
        {
            //Arrange (Definicion)
            Calculador calculador = new Calculador();


            //Act (actuar - proceso)
            bool resultado = calculador.IsImpar(numero);


            //assert (verificación resultados)
            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.EqualTo(true)); 
        }
    }
}
