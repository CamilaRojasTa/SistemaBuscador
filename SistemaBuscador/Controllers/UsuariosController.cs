using Microsoft.AspNetCore.Mvc;
using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class UsuariosController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NuevoUsuario()
        {
            return View();

        }
        [HttpPost]
        public IActionResult NuevoUsuario(UsuarioCreacionModel model)
        {
            return View();
        }
    }
}
