﻿using MathExpert;
using NUnit.Framework;
using NUnit.Framework.Legacy;
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

        #region TestStrings
        [Test]
        public void SaludoCliente_IngresarNombreApellido_ObtenerSaludoNombreCompleto()
        {
            string saludo = cliente.SaludoCliente("Alexi", "Mendoza");

            ClassicAssert.AreEqual(saludo,"Hola, Alexi Mendoza");
            Assert.That(saludo, Is.EqualTo("Hola, Alexi Mendoza"));
            Assert.That(saludo, Does.Contain(","));
            Assert.That(saludo, Does.StartWith("Hola,"));
            Assert.That(saludo, Does.EndWith("Mendoza"));

            //tambien se pueden usar expresiones regulares
            Assert.That(saludo, Does.Match("Hola, [A-Z]{1}[a-z]+ [A-z]{1}[a-z]+"));

        }

        #endregion TestStrings

        #region PruebasUnitariaExcepciones
        [Test]
        public void SaludoCliente_NoPasarNombre_LanzarExcepcion()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.SaludoCliente("", "Piedra"));
            ClassicAssert.AreEqual("Parametro nombre requerido", exceptionDetalle.Message);

            //esta linea es equivalente a las dos anteriores
            Assert.That(() => cliente.SaludoCliente("", "Piedra"),
                                Throws.ArgumentException.With.Message.EqualTo("Parametro nombre requerido"));
        }
        #endregion PruebasUnitariaExcepciones

        #region TestConHerencia

        [Test]
        public void DetalleCliente_TotalCompra_MenorQue100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 10;
            var resultado = cliente.DetalleCliente();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());


        }
        
        [Test]
        public void DetalleCliente_TotalCompra_MayorQue100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 110;
            var resultado = cliente.DetalleCliente();
            Assert.That(resultado, Is.TypeOf<ClientePlatino>());


        }


        #endregion TesConHerencia
    }
}
