using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class UsuarioCreacionModel
    {
        [Display(Name="Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Display(Name = "Rol")]
        public int RolId { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Repetir Contraseña")]
        public string RePassword { get; set; }
    }
}
