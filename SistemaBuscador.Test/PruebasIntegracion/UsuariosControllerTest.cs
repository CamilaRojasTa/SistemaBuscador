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
            var seguridad = new Seguridad();
            var rolService = new RolRepositorio(context);
            var usuarioSevice = new UsuarioRepository(context, seguridad, rolService);
            var model = new UsuarioCreacionModel()
            {
                NombreUsuario = "Usuario Test",
                Nombres = "Nombre test",
                Apellidos = "Apellido Test",
                Password = " Hola123 ",
                RePassword = " Hola123",
                RolId = 1
            };
            var controller = new UsuariosController(usuarioSevice);

            //ejecucion
            await controller.NuevoUsuario(model);
            var context2 = BuildContext(nombreBd);
            var lista = await context2.Usuarios.ToListAsync();
            var resultado = lista.Count;

            //validacion
            Assert.AreEqual(1, resultado);


        }

       
    }
}