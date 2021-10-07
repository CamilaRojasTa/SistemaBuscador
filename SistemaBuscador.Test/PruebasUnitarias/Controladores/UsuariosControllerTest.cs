using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class UsuariosControllerTest
    {
        
        [TestMethod]
        public async Task NuevoUsuario_modelo_invalido()
        {
            //preparacion
            var usuarioService = new Mock<IUsuarioRepository>();
            var model = new UsuarioCreacionModel();
            var controller = new UsuariosController(usuarioService.Object);         

            //ejecucion
            controller.ModelState.AddModelError(string.Empty, "Datos invalidos");
            var resultado = await controller.NuevoUsuario(model) as ViewResult;

            //verificacion
            Assert.AreEqual(resultado.ViewName, "NuevoUsuario");
        }

        [TestMethod]
        public async Task NuevoUsuario_modelo_valido()
        {
             //preparacion
             var usuarioService = new Mock<IUsuarioRepository>();
             var model = new UsuarioCreacionModel();
             var controller = new UsuariosController(usuarioService.Object);

             //ejecucion           
             var resultado = await controller.NuevoUsuario(model) as RedirectToActionResult;

             //verificacion
             Assert.AreEqual(resultado.ActionName, "Index");
        }
    }
}
