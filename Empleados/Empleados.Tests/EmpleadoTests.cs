using Empleados.Core.Modelos;
using Empleados.Infraestructura.Data;
using Empleados.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
        }


        [Test]
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
            Assert.AreEqual(empleadoTest1.Id, empleadoDb.Id);
            Assert.AreEqual(empleadoTest1.Apellidos, empleadoDb.Apellidos);

        }
    }
}
