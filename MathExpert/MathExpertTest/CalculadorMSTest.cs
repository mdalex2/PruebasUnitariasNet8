using MathExpert;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertMSTest
{
    [TestClass]
    public class CalculadorMSTest
    {
        [TestMethod]
        public void SumarNumeros_IngresarDosNumeros_ObtenerSuma()
        {
            //arrange (instancias)
            Calculador calculador = new Calculador();


            //Act (actuar)
            int resultado = calculador.Sumar(5, 6);

            //asert (Resultado como tal verificaciones)
            Assert.AreEqual(11, resultado);

        }
    }
}
