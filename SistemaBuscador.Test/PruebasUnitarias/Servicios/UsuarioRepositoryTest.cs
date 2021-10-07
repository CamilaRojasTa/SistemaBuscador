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
using System.Linq;
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
            var nombreBd = Guid.NewGuid().ToString();           
            var context = BuildContext(nombreBd);
                      
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context, serviceSeguridad.Object, serviceRol.Object);           
            var modelo = new UsuarioCreacionModel() { NombreUsuario = "Usuario Test",Nombres="Nombre test",
                                                      Apellidos= "Apellido Test", Password=" Hola123 ",
                                                      RePassword=" Hola123", RolId=1 };
           
            //ejecucion
            await repo.InsertarUsuario(modelo);
            var context2 = BuildContext(nombreBd);
            var list = await context2.Usuarios.ToListAsync();
            var resultado = list.Count();

            //Verificacion
            Assert.AreEqual(1, resultado);

        }


         [TestMethod]
        public async Task ObtenerUsuarioPorId()
         {
            //preparacion       
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var usuario = new Usuario(){NombreUsuario = "Usuario Test",Nombres = "Nombre test",
                                        Apellidos = "Apellido Test",Password = " Hola123 ",RolId = 1};
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);

            //ejecucion
            var usuarioDeLaBd = await repo.ObtenerUsuarioPorId(1);

            //verificacion
            Assert.IsNotNull(usuarioDeLaBd);
         }


         [TestMethod]
         public async Task ActualizarUsuario()
        {
        //preparacion
        
        var nombreBd = Guid.NewGuid().ToString();
        var context = BuildContext(nombreBd);
            var usuario = new Usuario() {NombreUsuario = "Usuario Test", Nombres = "Nombre test", Apellidos = "Apellido Test",
                                         Password = " Hola123 ",RolId = 1,Id = 1,};
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();

        var context2 = BuildContext(nombreBd);
        var serviceSeguridad = new Mock<ISeguridad>();
        var serviceRol = new Mock<IRolRepositorio>();
        var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);
            var model = new UsuarioEdicionModel() { Nombres = "Usuario Modificado", NombreUsuario = "Nombre Usuario Modificado",
                                                   Apellidos = "Apellido Modificado",Id = 1, RolId = 1};
        //ejecucion
        await repo.ActualizarUsuario(model);
        var context3 = BuildContext(nombreBd);
        var usuarioModificado = await context3.Usuarios.FirstOrDefaultAsync(x => x.Id == 1);
        var resultado = usuarioModificado.Nombres;

        //verificacion
        Assert.AreEqual("Usuario Modificado", resultado);
        }




         [TestMethod]
         public async Task ActualizarPassword()
        {
         var nombreBd = Guid.NewGuid().ToString();
         var context = BuildContext(nombreBd);
         var user = new Usuario(){NombreUsuario = "Usuario Test",Nombres = "Nombre test",Apellidos = "Apellido Test",
                                                  Password = "Hola123", RolId = 1,Id = 1,};
         context.Usuarios.Add(user);
         await context.SaveChangesAsync();

         var context2 = BuildContext(nombreBd);
         var serviceSeguridad = new Mock<ISeguridad>();
         var serviceRol = new Mock<IRolRepositorio>();
         var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);
         var model = new UsuarioCambioPasswordModel() { Id = 1, Password ="Nueva321",RePassword ="Nueva321"};
         serviceSeguridad.Setup(x => x.Encriptar(It.IsAny<string>())).Returns("Nueva321");

            //ejecucion
         await repo.ActualizarPassword(model);
         var context3 = BuildContext(nombreBd);
         var passwordModificado = await context3.Usuarios.FirstOrDefaultAsync(x => x.Id == 1);
         var resultado = passwordModificado.Password;

        //verificacion
        Assert.AreEqual("Nueva321", resultado);
        }





        [TestMethod]
        public async Task EliminarUsuario()
        {
           //preparacion
           var nombreBd = Guid.NewGuid().ToString();
           var context = BuildContext(nombreBd);
           var usuario = new Usuario() { NombreUsuario = "Usuario Test" };
           //, Nombres = "Nombre test", Apellidos = "Apellido Test",Password = " Hola123 ", RolId = 1};
           context.Usuarios.Add(usuario);
           await context.SaveChangesAsync();

           var context2 = BuildContext(nombreBd);
           var serviceSeguridad = new Mock<ISeguridad>();
           var serviceRol = new Mock<IRolRepositorio>();
           var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);

           //ejecucion
           await repo.EliminarUsuario(1);
           var context3 = BuildContext(nombreBd);
           var listaUsuarios = await context3.Usuarios.ToListAsync();
           var resultado = listaUsuarios.Count;

           //verificacion
            Assert.AreEqual(0, resultado);
        }
    }
}