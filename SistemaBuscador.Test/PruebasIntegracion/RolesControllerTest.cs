using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Controllers;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasIntegracion
{
    [TestClass]
    public class RolesControllerTest : TestBase
    {
        [TestMethod]

        public async Task NuevoRol()
            
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rolService = new RolRepositorio(context);
            var model = new RolCreacionModel() { Nombre = "Rol Test" };

            var controller = new RolesController(rolService);

            //ejecucion
            await controller.NuevoRol(model);
            var context2 = BuildContext(nombreBd);
            var lista = await context2.Roles.ToListAsync();
            var resultado = lista.Count;

            //validacion
            Assert.AreEqual(1, resultado);


        }

        [TestMethod]

        public async Task ActualizarRol()

        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rolService = new RolRepositorio(context);
            var rol = new Rol() {Nombre="Rol Test" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var model = new RolEdicionModel() { Id=1, Nombre = "Rol Test Modificado" };
            var controller = new RolesController(rolService);

            //ejecucion
            await controller.ActualizarRol(model);
            var context2 = BuildContext(nombreBd);
            var rolDb = await context2.Roles.FirstOrDefaultAsync(x => x.Id == 1);
            var resultado = rolDb.Nombre;

            //validacion
            Assert.AreEqual("Rol Test Modificado", resultado);
            


        }

    }
}
