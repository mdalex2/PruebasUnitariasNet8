using MathExpert;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CuentaBancoXUnitsTests
    {
        private CuentaBanco cuentaBanco;
        
        //[Test] 
        //public void Deposito_Agregar100_ObtenerTrue()  //sin moq
        //{
        //    var resultado = cuentaBanco.Deposito(100);
        //    Assert.IsTrue(resultado);
        //    Assert.That(cuentaBanco.ObtenerBalance, Is.EqualTo(100));
        //}


        #region MoqFramework
        // MOQ se usa para simular implementaciones
        //ejm patron de repositorios, loggers entre otros
        //se usa la libreria en nugget
        [Fact]
        public void Deposito_UsandoMoq_Agregar100_ObtenerTrue()  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            logMok.Setup(s => s.Mensaje("Inicia el proceso"));

            CuentaBanco cuentaBancoMock = new CuentaBanco(logMok.Object); //se le pasa un objeto simulando el logger
            var resultado = cuentaBancoMock.Deposito(100);
            Assert.True(resultado);
            Assert.Equal(100,cuentaBancoMock.ObtenerBalance());
        }

        [Fact]
        public void Retiro_RetiroConBalance200_ObtenerTrue()  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            logMok.Setup(s => s.LogBaseDatos(It.IsAny<string>())).Returns(true); //acepte strings
            logMok.Setup(s => s.LogBalanceDespuesRetiro(It.Is<double>(n => n > 0))).Returns(true); //acepte nro double > 0


            CuentaBanco cuentaBancoMock = new CuentaBanco(logMok.Object); //se le pasa un objeto simulando el logger
            cuentaBancoMock.Deposito(200);
            var resultado = cuentaBancoMock.Retiro(100);
            Assert.True(resultado);
            Assert.Equal(100,cuentaBancoMock.ObtenerBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void RetiroTestCase_RetiroConBalance200_ObtenerTrue(double balance, double retiro)  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            logMok.Setup(s => s.LogBaseDatos(It.IsAny<string>())).Returns(true); //acepte strings
            logMok.Setup(s => s.LogBalanceDespuesRetiro(It.Is<double>(n => n > 0))).Returns(true); //acepte nro double > 0


            CuentaBanco cuentaBancoMock = new CuentaBanco(logMok.Object); //se le pasa un objeto simulando el logger
            cuentaBancoMock.Deposito(balance);
            var resultado = cuentaBancoMock.Retiro(retiro);
            Assert.True(resultado);
        }


        [Theory]
        [InlineData(200, 300)] //para provocar el false
        public void RetiroTestCase_RetiroConBalance200_ObtenerFalse(double balance, double retiro)  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            logMok.Setup(s => s.LogBaseDatos(It.IsAny<string>())).Returns(true); //acepte strings
            logMok.Setup(s => s.LogBalanceDespuesRetiro(It.Is<double>(n => n > 0))).Returns(true);
            logMok.Setup(s => s.LogBalanceDespuesRetiro(It.Is<double>(n => n < 0))).Returns(false);


            CuentaBanco cuentaBancoMock = new CuentaBanco(logMok.Object); //se le pasa un objeto simulando el logger
            cuentaBancoMock.Deposito(balance);
            var resultado = cuentaBancoMock.Retiro(retiro);
            Assert.False(resultado);
        }


        [Fact]
        public void PruebaLockMockString_ReturnTrue()  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            string mensajeSalida = "hola";
            logMok.Setup(s => s.MensajeRetornaString(It.IsAny<string>())).Returns((string str) => str.ToLower()); //acepte strings

            Assert.Equal(mensajeSalida, logMok.Object.MensajeRetornaString("Hola")); //se le pasa un objeto simulando el logger

        }

        #endregion MoqFramework
    }
}
