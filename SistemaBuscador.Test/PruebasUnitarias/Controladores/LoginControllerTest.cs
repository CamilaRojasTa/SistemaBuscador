using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Controladores
{
    [TestClass]
     public  class LoginControllerTest
    {
        [TestMethod]
        public async Task LoginModeloInvalido()
        {
            //Preparacion
            var loginRepository = new LoginRepositoryEFFalse();
            var model = new LoginViewModel() {Usuario="", Password="" };

            //Ejecucion
            var controller = new LoginController(loginRepository);
            controller.ModelState.AddModelError(string.Empty, "Datos invalidos");
            var resultado = await controller.Login(model)as ViewResult;

            //Verificacion
            Assert.AreEqual(resultado.ViewName, "Index");
        }

        [TestMethod]
        public async Task  LoginUsuarioNoExiste()
        {
            //Preparacion           
            var loginService = new Mock<ILoginRepository>();
            loginService.Setup(x => 
            x.UserExist(
                It.IsAny<string>(), 
                It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            var model = new LoginViewModel() { Usuario = "Usuario1", Password = "Password1" };

            //Ejecucion
            var controller = new LoginController(loginService.Object);
            var resultado = await controller.Login(model) as ViewResult;

            //Validacion
            Assert.AreEqual(resultado.ViewName, "Index");

        }

        [TestMethod]
        public async Task LoginUsuarioExiste()
        {
            //Preparacion           
            var loginService = new Mock<ILoginRepository>();
            loginService.Setup(x=>
            x.UserExist(
                It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var model = new LoginViewModel() { Usuario = "Usuario1", Password = "Password1" };

            //Ejecucion
            var controller = new LoginController(loginService.Object);
            var resultado = await controller.Login(model) as RedirectToActionResult;

            //Validacion
            Assert.AreEqual(resultado.ActionName, "Index");
            Assert.AreEqual(resultado.ControllerName, "Home");
        }
    }
}
