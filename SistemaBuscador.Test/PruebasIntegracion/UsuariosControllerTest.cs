using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasIntegracion
{
    [TestClass]
    public class UsuariosControllerTest : TestBase
    {
        [TestMethod]

        public async Task NuevoUsuario()

        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);            
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();            
            var usuarioService = new UsuarioRepository(context, serviceSeguridad.Object, serviceRol.Object);
            var model = new UsuarioCreacionModel(){NombreUsuario = "Usuario Test", Nombres = "Nombre test",
                                                   Apellidos = "Apellido Test", Password = " Hola123 ",
                                                   RePassword = " Hola123", RolId = 1};
            var controller = new UsuariosController(usuarioService);

            //ejecucion
            await controller.NuevoUsuario(model);
            var context2 = BuildContext(nombreBd);
            var lista = await context2.Usuarios.ToListAsync();
            var resultado = lista.Count;

            //validacion
            Assert.AreEqual(1, resultado);



        }

        [TestMethod]

        public async Task ActualizarUsuario()

        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var usuarioService = new UsuarioRepository(context, serviceSeguridad.Object, serviceRol.Object);           
            var usuario = new Usuario() {NombreUsuario = "Usuario Test", Nombres = "Nombre test",
                                         Apellidos = "Apellido Test",Password = " Hola123 ",RolId = 1};
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            var model = new UsuarioEdicionModel() { Nombres = "Usuario Test Modificado", 
                                                    NombreUsuario="Nombre Usuario Modificado", 
                                                    Apellidos="Apellido Modificado", Id=1, RolId=1 };
            var controller = new UsuariosController(usuarioService);

            //ejecucion
            await controller.ActualizarUsuario(model);
            var context2 = BuildContext(nombreBd);
            var usuarioDb = await context2.Usuarios.FirstOrDefaultAsync(x => x.Id == 1);
            var resultado = usuarioDb.Nombres;

            //validacion
            Assert.AreEqual("Usuario Test Modificado", resultado);
        }
    }
}