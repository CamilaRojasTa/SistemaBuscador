using Microsoft.EntityFrameworkCore;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        private readonly ISeguridad _seguridad;

        public UsuarioRepository(AplicationDbContext context, ISeguridad seguridad)
        {
            _context = context;
            _seguridad = seguridad;
        }
        public async Task InsertarUsuario(UsuarioCreacionModel model)
        {
            var nuevoUsuario = new Usuario()
            {
                NombreUsuario = model.NombreUsuario,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                RolId = (int)model.RolId,
                Password = _seguridad.Encriptar(model.Password)
            };
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();


        }

        public async Task<List<UsuarioListaModel>> ObtenerListaUsuarios()
        {
            var respuesta = new List<UsuarioListaModel>();
            var listaDelaBd = await _context.Usuarios.ToListAsync();

            foreach(var usuariobd in listaDelaBd)
            {
                //Mapeo de entidades
                var newUsuarioLista = new UsuarioListaModel()
                {
                    Id = usuariobd.Id,
                    Nombres = usuariobd.Nombres,
                    Apellidos = usuariobd.Apellidos,
                    NombreUsuario = usuariobd.NombreUsuario,
                    Rol = usuariobd.RolId
                };
                respuesta.Add(newUsuarioLista);
            }

            return respuesta;

        }
        public async Task<UsuarioEdicionModel> ObtenerUsuarioPorId(int id)
        {
            var respuesta = new UsuarioEdicionModel() { };
            var usuariodb = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if(usuariodb != null)
            {
                respuesta.Id = usuariodb.Id;
                respuesta.Nombres = usuariodb.Nombres;
                respuesta.Apellidos = usuariodb.Apellidos;
                respuesta.NombreUsuario = usuariodb.NombreUsuario;
                respuesta.RolId = usuariodb.RolId;
            }
            return respuesta;
        }
       

        public async Task ActualizarUsuario(UsuarioEdicionModel model)
        {
            var usuariodb = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == model.Id);
            usuariodb.Nombres = model.Nombres;
            usuariodb.Apellidos = model.Apellidos;
            usuariodb.RolId = (int)model.RolId;
            await _context.SaveChangesAsync();


        }

        public async Task ActualizarPassword(UsuarioCambioPasswordModel model)
        {
            var usuariodb = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == model.Id);
            usuariodb.Password = _seguridad.Encriptar(model.Password);

            
            await _context.SaveChangesAsync();


        }
    }
}
