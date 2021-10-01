using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class RolRepositorioTest: TestBase
    {
        [TestMethod]
        public async Task InsertarRol()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var repo = new RolRepositorio(context);
            var modelo = new RolCreacionModel() { Nombre = "Rol Test" };

            //ejecucion
            await repo.InsertarRol(modelo);
            var context2 = BuildContext(nombreBd);
            var list = await context2.Roles.ToListAsync();
            var resultado = list.Count();

            //Verificacion
            Assert.AreEqual(1, resultado);


        }

        [TestMethod]
        public async Task ObtenerRolPorId()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);

            //ejecucion
            var rolDeLaBd = await repo.ObtenerRolPorId(1);

            //verificacion
            Assert.IsNotNull(rolDeLaBd);
        }

        [TestMethod]
        public async Task ActualizarRol()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);
            var model = new RolEdicionModel() { Id = 1, Nombre = "Rol 1 Modificado" };
            //ejecucion
            await repo.ActualizarRol(model);
            var context3 = BuildContext(nombreBd);
            var rolModificada = await context3.Roles.FirstOrDefaultAsync(x => x.Id == 1);
            var resultado = rolModificada.Nombre;

            //verificacion
            Assert.AreEqual("Rol 1 Modificado", resultado);
        }


        [TestMethod]
        public async Task EliminarRol()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuildContext(nombreBd);
            var repo = new RolRepositorio(context2);

            //ejecucion
            await repo.EliminarRol(1);
            var context3 = BuildContext(nombreBd);
            var listaRoles = await context3.Roles.ToListAsync();
            var resultado = listaRoles.Count;

            //verificacion
            Assert.AreEqual(0, resultado);
        }



    }
}
