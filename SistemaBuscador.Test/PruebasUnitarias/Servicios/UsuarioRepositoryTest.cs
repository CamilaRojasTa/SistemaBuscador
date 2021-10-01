using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class UsuarioRepositoryTest : TestBase
    {
        [TestMethod]
        public async Task InsertarUsuario()
        {
            //preparacion
            //revisar seguridad en contexto
            //var nombreBd = Guid.NewGuid().ToString();           
            //var context = BuildContext(nombreBd);
            // var repo = new UsuarioRepository(context );
            // var modelo = new UsuarioCreacionModel() { Nombres = "Usuario Test" };

            //ejecucion
            //await repo.InsertarUsuario(modelo);
            // var context2 = BuildContext(nombreBd);
            //var list = await context2.Usuarios.ToListAsync();
            // var resultado = list.Count();

            //Verificacion
            // Assert.AreEqual(1, resultado);

        }

        [TestMethod]
        public async Task ObtenerUsuarioPorId()
        {
            //preparacion
            //revisar context seguridad
            // var nombreBd = Guid.NewGuid().ToString();
            // var context = BuildContext(nombreBd);
            //var usuario = new Usuario() { Nombres = "Rol 1" };
            //context.Usuarios.Add(usuario);
            // await context.SaveChangesAsync();
            //var context2 = BuildContext(nombreBd);
            //var repo = new UsuarioRepository(context2);

            //ejecucion
            //var rolDeLaBd = await repo.ObtenerUsuarioPorId(1);

            //verificacion
            //Assert.IsNotNull(rolDeLaBd);
        }

        [TestMethod]
        public async Task ActualizarUsuario()
        {
            //preparacion
            //revisar que viene de from riute no de un model
            //var nombreBd = Guid.NewGuid().ToString();
            // var context = BuildContext(nombreBd);
            //var usuario = new Usuario() { Nombres = "Nombre 1" };
            //context.Usuarios.Add(usuario);
            //await context.SaveChangesAsync();

            //var context2 = BuildContext(nombreBd);
            //var repo = new UsuarioRepository(context2);
            //var model = new RolEdicionModel() { Id = 1, Nombre = "Rol 1 Modificado" };
            //ejecucion
            // await repo.ActualizarRol(model);
            //var context3 = BuildContext(nombreBd);
            //var rolModificada = await context3.Roles.FirstOrDefaultAsync(x => x.Id == 1);
            //var resultado = rolModificada.Nombre;

            //verificacion
            //Assert.AreEqual("Rol 1 Modificado", resultado);
        }

        [TestMethod]
        public async Task ActualizarPassword()
        {
        }

        [TestMethod]
        public async Task EliminarUsuario()
        {
            //preparacion
            //var nombreBd = Guid.NewGuid().ToString();
            // var context = BuildContext(nombreBd);
            //var rol = new Rol() { Nombre = "Rol 1" };
            //context.Roles.Add(rol);
            //await context.SaveChangesAsync();

            //var context2 = BuildContext(nombreBd);
            // var repo = new RolRepositorio(context2);

            //ejecucion
            //await repo.EliminarRol(1);
            // var context3 = BuildContext(nombreBd);
            //var listaRoles = await context3.Roles.ToListAsync();
            //var resultado = listaRoles.Count;

            //verificacion
            // Assert.AreEqual(0, resultado);
        }
    }
}