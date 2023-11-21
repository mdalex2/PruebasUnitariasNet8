using MathExpert;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class CuentaBancoNUnitTest
    {
        private CuentaBanco cuentaBanco;


        [SetUp]
        public void Setup()
        {
            //cuentaBanco = new CuentaBanco(new LogRegistro()); //sin libreria moq
        }


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
        [Test]
        public void Deposito_UsandoMoq_Agregar100_ObtenerTrue()  //con moq
        {
            var logMok = new Mock<ILogRegistro>(); //para falsear instancias (sirve para evitar que se registren por ejemplo datos)
            logMok.Setup(s => s.Mensaje("Inicia el proceso"));

            CuentaBanco cuentaBancoMock = new CuentaBanco(logMok.Object); //se le pasa un objeto simulando el logger
            var resultado = cuentaBancoMock.Deposito(100);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancoMock.ObtenerBalance, Is.EqualTo(100));
        }


        #endregion MoqFramework
    }
}
