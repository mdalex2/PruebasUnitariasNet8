using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class ClienteXUnitTests
    {
        //inicializar la clase a usar de manera globlal
        //para usarla en todas las pruebas
        private Cliente cliente;

        public ClienteXUnitTests()
        {
            cliente = new Cliente();
        }

        #region TestStrings
        [Fact]
        public void SaludoCliente_IngresarNombreApellido_ObtenerSaludoNombreCompleto()
        {
            string saludo = cliente.SaludoCliente("Alexi", "Mendoza");

            Assert.Equal("Hola, Alexi Mendoza", saludo);
            Assert.Contains(",",saludo);
            Assert.StartsWith("Hola,", saludo);
            Assert.EndsWith("Mendoza", saludo);

            //tambien se pueden usar expresiones regulares
            Assert.Matches("Hola, [A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", saludo);

        }

        #endregion TestStrings

        #region PruebasUnitariaExcepciones
        [Fact]
        public void SaludoCliente_NoPasarNombre_LanzarExcepcion()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.SaludoCliente("", "Piedra"));
            Assert.Equal("Parametro nombre requerido", exceptionDetalle.Message);
        }
        #endregion PruebasUnitariaExcepciones

        #region TestConHerencia

        [Fact]
        public void DetalleCliente_TotalCompra_MenorQue100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 10;
            var resultado = cliente.DetalleCliente();
            Assert.IsType<ClienteBasico>(resultado);


        }

        [Fact]
        public void DetalleCliente_TotalCompra_MayorQue100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 110;
            var resultado = cliente.DetalleCliente();
            Assert.IsType<ClientePlatino>(resultado);
        }


        #endregion TesConHerencia
    }
}
