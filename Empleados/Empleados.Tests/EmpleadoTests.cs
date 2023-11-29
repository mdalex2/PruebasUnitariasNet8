using Empleados.API.Controllers;
using Empleados.Core.Modelos;
using Empleados.Infraestructura.Data;
using Empleados.Infraestructura.Repositorio;
using Empleados.Infraestructura.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Tests
{
    [TestFixture]
    public class EmpleadoTests
    {
        private Empleado empleadoTest1 { get; set; }
        private Empleado empleadoTest2 { get; set; }
        private Empleado empleadoFail { get; set; }
        private DbContextOptions<ApplicationDbContext> options;

        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: "emp_empleadoDB").Options;

            empleadoTest1 = new Empleado()
            {
                Id = 1,
                Apellidos = "Apellido 1",
                Nombres = "Nombres 1",
                Cargo = "Cargo 1",
                CompaniaId = 1
            };
            empleadoTest2 = new Empleado()
            {
                Id = 2,
                Apellidos = "Apellido 2",
                Nombres = "Nombres 2",
                Cargo = "Cargo 2",
                CompaniaId = 2
            };
            empleadoFail = new Empleado()
            {
                Id = 2,
                Apellidos = "Apellido 2",
                Nombres = "Nombres 2",
                Cargo = "Cargo 2"
                //no se le pasa compañía test error
            };
        }


        [Test]
        [Order(1)] //para indicarle el orden
        public async Task EmpleadoRepositorio_AgregarEmpleado_GrabadoExitoso()
        {
            //Arrange
            var context = new ApplicationDbContext(options);
            var empleadoRepositorio = new EmpleadoRepositorio(context);

            //Act
            await empleadoRepositorio.Agregar(empleadoTest1);
            await empleadoRepositorio.Guardar();
            var empleadoDb = await empleadoRepositorio.ObtenerPrimero();

            //tests
            ClassicAssert.AreEqual(empleadoTest1.Id, empleadoDb.Id);
            ClassicAssert.AreEqual(empleadoTest1.Apellidos, empleadoDb.Apellidos);

        }

        [Test]
        [Order(2)] //para indicarle el orden de ejecución
        public async Task EmpleadoRespositorio_ObtenerTodos_ObtenerListaEmpleados()
        {
            //arrange
            var expectedResult = new List<Empleado> { empleadoTest1, empleadoTest2 };
            var context = new ApplicationDbContext(options);
            var empleadoRepositorio = new EmpleadoRepositorio(context);
            await context.Database.EnsureDeletedAsync(); //elimino todos los datos que se registraron en las pruebas anteriores para evitar error de id duplicado

            //Act
            await empleadoRepositorio.Agregar(empleadoTest1);
            await empleadoRepositorio.Agregar(empleadoTest2);
            await empleadoRepositorio.Guardar();
            var listaEmpleados = await empleadoRepositorio.ObtenerTodos();

            //tests
            CollectionAssert.AreEqual(expectedResult, listaEmpleados);
        }

        [Test]
        [Order(3)]
        public async Task EmpleadoController_GetEmpleados_ObtenerListaEmpleados()
        {
            //arrange
            var empleados = new List<Empleado> 
            {  
                new Empleado {Id = 1 , Apellidos = "Apellidos 1", Nombres = "Nombres 1", Cargo = "Cargo 1", CompaniaId = 1},
                new Empleado {Id = 2 , Apellidos = "Apellidos 2", Nombres = "Nombres 2", Cargo = "Cargo 2", CompaniaId = 2}
            };
            
            var mockEmpleadoRepositorio = new Mock<IEmpleadoRepositorio>(); //simular un repositorio
            mockEmpleadoRepositorio.Setup(x => x.ObtenerTodos(null,null,"Compania")).ReturnsAsync(empleados); //se le pasan los tres parámetros que espera el repo generico así no se usen en el controller por eso se pasan null los dos primeros
                                                                                                              // con el returns async se le pasa la lista de empleados para falsear que se devolverá esa lista de empleados creada anteriormente en linea 92
            var mockLogger = new Mock<ILogger<EmpleadoController>>();
            var empleadoController = new EmpleadoController(mockEmpleadoRepositorio.Object, mockLogger.Object); //se le pasan los dos parametros esperados en el controller

            var actionResult = await empleadoController.GetEmpleados();
            var resultado = actionResult.Result as OkObjectResult;
            var empleadosDb = resultado.Value as IEnumerable<Empleado>;

            CollectionAssert.AreEqual(empleados,empleadosDb);
            ClassicAssert.AreEqual(empleados.Count(),empleadosDb.Count());
        }

        [Test]
        [Order(4)]
        public async Task EmpleadoController_GetEmpleado_ObtenerEmpleado()
        {
            //arrange
            
            var mockEmpleadoRepositorio = new Mock<IEmpleadoRepositorio>(); //simular un repositorio
            mockEmpleadoRepositorio.Setup(x => x.ObtenerPrimero(e => e.Id == 1, "Compania")).ReturnsAsync(empleadoTest1); //se le pasan los dos parámetros que espera el repo generico así no se usen en el controller por eso se pasan null el primer parametro
                                                                                                                // con el returns async se le pasa el empleado para falsear que se devolverá objeto empleado creado en el setup
            var mockLogger = new Mock<ILogger<EmpleadoController>>();
            var empleadoController = new EmpleadoController(mockEmpleadoRepositorio.Object, mockLogger.Object); //se le pasan los dos parametros esperados en el controller

            var actionResult = await empleadoController.GetEmpleado(1);
            var resultado = actionResult.Result as OkObjectResult;
            var empleadoDb = resultado.Value as Empleado;

            ClassicAssert.AreEqual(empleadoTest1, empleadoDb);
        }
        
        
        [Test]
        [Order(4)]
        public async Task EmpleadoController_GetEmpleado_ObtenerNotFound()
        {
            //arrange
            
            var mockEmpleadoRepositorio = new Mock<IEmpleadoRepositorio>(); //simular un repositorio
            mockEmpleadoRepositorio.Setup(x => x.ObtenerPrimero(e => e.Id == 1, "Compania")).ReturnsAsync(empleadoTest1); //se le pasan los dos parámetros que espera el repo generico así no se usen en el controller por eso se pasan null el primer parametro
                                                                                                                // con el returns async se le pasa el empleado para falsear que se devolverá objeto empleado creado en el setup
            var mockLogger = new Mock<ILogger<EmpleadoController>>();
            var empleadoController = new EmpleadoController(mockEmpleadoRepositorio.Object, mockLogger.Object); //se le pasan los dos parametros esperados en el controller

            var actionResult = await empleadoController.GetEmpleado(-1);
            var resultado = actionResult.Result as OkObjectResult;

            ClassicAssert.IsNull(resultado);
        }


        [Test]
        [Order(4)]
        public async Task EmpleadoController_PostEmpleado_GrabadoExitoso()
        {
            //arrange

            var mockEmpleadoRepositorio = new Mock<IEmpleadoRepositorio>(); //simular un repositorio
            mockEmpleadoRepositorio.Setup(x => x.Agregar(empleadoTest1)); 
            
            var mockLogger = new Mock<ILogger<EmpleadoController>>();
            var empleadoController = new EmpleadoController(mockEmpleadoRepositorio.Object, mockLogger.Object); //se le pasan los dos parametros esperados en el controller

            var actionResult = await empleadoController.PostEmpleado(empleadoTest1);
            var resultado = actionResult.Result as CreatedAtRouteResult;
            var empleadoDb = resultado.Value as Empleado;

            ClassicAssert.AreEqual(empleadoTest1,empleadoDb);
        }
        
        
        [Test]
        [Order(4)]
        public async Task EmpleadoController_PostEmpleado_ErrorGrabar()
        {
            //arrange

            var mockEmpleadoRepositorio = new Mock<IEmpleadoRepositorio>(); //simular un repositorio
            mockEmpleadoRepositorio.Setup(x => x.Agregar(empleadoFail)); 
            
            var mockLogger = new Mock<ILogger<EmpleadoController>>();
            var empleadoController = new EmpleadoController(mockEmpleadoRepositorio.Object, mockLogger.Object); //se le pasan los dos parametros esperados en el controller

            var actionResult = await empleadoController.PostEmpleado(empleadoFail);
            var resultado = actionResult.Result as CreatedAtRouteResult;

            //assert
            ClassicAssert.IsNull(resultado);
        }
    }
}
