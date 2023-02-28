using DataAccess;
using DataAccess.Repositories;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTest
{
    [TestClass]
    public class ClienteTest
    {
        private  readonly Database  dbInMemory;
        
        public ClienteTest() 
        {
            dbInMemory = new Database();
        }
        [TestMethod]
        public void getClientes()
        {
            using (var context = dbInMemory.GetDbContext())
            {
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 15,
                    personaId = 1154323,
                    nombre = "juan",
                    genero = "masculino",
                    edad = 24,
                    direccion = "cra24",
                    telefono = 12345,
                    contrasena = "12345",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 16,
                    personaId = 67012640,
                    nombre = "Alexandra",
                    genero = "Femenino",
                    edad = 25,
                    direccion = "cra25",
                    telefono = 123456,
                    contrasena = "12346",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 17,
                    personaId = 1144231234,
                    nombre = "Oscar",
                    genero = "masculino",
                    edad = 24,
                    direccion = "Av10",
                    telefono = 123450,
                    contrasena = "123455",
                    estado = true
                });
                context.SaveChanges();
            }
            using (var context = dbInMemory.GetDbContext())
            {
                var repository = new ClienteRepository(context);
                var service = new ClienteService(repository);
                var result = service.listAsync();

                Assert.AreEqual(3, result.Result.Count());
            }
        }
        [TestMethod]
        public void getClienteById()
        {
            using (var context = dbInMemory.GetDbContext())
            {
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 15,
                    personaId = 1154323,
                    nombre = "juan",
                    genero = "masculino",
                    edad = 24,
                    direccion = "cra24",
                    telefono = 12345,
                    contrasena = "12345",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 16,
                    personaId = 67012640,
                    nombre = "Alexandra",
                    genero = "Femenino",
                    edad = 25,
                    direccion = "cra25",
                    telefono = 123456,
                    contrasena = "12346",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 17,
                    personaId = 1144231234,
                    nombre = "Oscar",
                    genero = "masculino",
                    edad = 24,
                    direccion = "Av10",
                    telefono = 123450,
                    contrasena = "123455",
                    estado = true
                });
                context.SaveChanges();
            }
            using (var context = dbInMemory.GetDbContext())
            {
                var repository = new ClienteRepository(context);
                var service = new ClienteService(repository);
                var clienteId = 15;
                var result = service.getById(clienteId);

                Assert.AreEqual(clienteId, result.Result.clienteId);
            }
        }
        [TestMethod]
        public void delete()
        {
            using (var context = dbInMemory.GetDbContext())
            {
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 15,
                    personaId = 1154323,
                    nombre = "juan",
                    genero = "masculino",
                    edad = 24,
                    direccion = "cra24",
                    telefono = 12345,
                    contrasena = "12345",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 16,
                    personaId = 67012640,
                    nombre = "Alexandra",
                    genero = "Femenino",
                    edad = 25,
                    direccion = "cra25",
                    telefono = 123456,
                    contrasena = "12346",
                    estado = true
                });
                context.Cliente.Add(new Cliente()
                {
                    clienteId = 17,
                    personaId = 1144231234,
                    nombre = "Oscar",
                    genero = "masculino",
                    edad = 24,
                    direccion = "Av10",
                    telefono = 123450,
                    contrasena = "123455",
                    estado = true
                });
                context.SaveChanges();
            }
            using (var context = dbInMemory.GetDbContext())
            {
                var repository = new ClienteRepository(context);
                var service = new ClienteService(repository);
                var clienteId = 15;
                var result = service.delete(clienteId);

                Assert.AreEqual(2, service.listAsync().Result.Count());
            }
        }

    }
}
