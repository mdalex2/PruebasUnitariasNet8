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
    public class ClienteNUnitTest
    {
        //inicializar la clase a usar de manera globlal
        //para usarla en todas las pruebas
        private Cliente cliente;
        [SetUp] 
        public void SetUp() 
        { 
            cliente = new Cliente();
        }


        [Test]
        public void SaludoCliente_IngresarNombreApellido_ObtenerSaludoNombreCompleto()
        {
            string saludo = cliente.SaludoCliente("Alexi", "Mendoza");

            Assert.AreEqual(saludo,"Hola, Alexi Mendoza");
            Assert.That(saludo, Is.EqualTo("Hola, Alexi Mendoza"));
            Assert.That(saludo, Does.Contain(","));
            Assert.That(saludo, Does.StartWith("Hola,"));
            Assert.That(saludo, Does.EndWith("Mendoza"));

            //tambien se pueden usar expresiones regulares
            Assert.That(saludo, Does.Match("Hola, [A-Z]{1}[a-z]+ [A-z]{1}[a-z]+"));

        }
    }
}
