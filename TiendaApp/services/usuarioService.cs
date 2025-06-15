using System.Collections.Generic;
using System.Linq;
using TiendaApp.Models;

namespace TiendaApp.Services
{
    public class UsuarioService
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private const int MaxUsuarios = 15;

        public List<Usuario> ObtenerTodos() => _usuarios;
        
        public void Crear(Usuario usuario)
        {
            if (_usuarios.Count >= MaxUsuarios)
                throw new System.Exception("No se pueden crear más usuarios. Límite alcanzado.");
                
            if (_usuarios.Any(u => u.Identificacion == usuario.Identificacion))
                throw new System.Exception("Ya existe un usuario con esta identificación.");
                
            _usuarios.Add(usuario);
        }
        
        public Usuario BuscarPorId(string identificacion) => 
            _usuarios.FirstOrDefault(u => u.Identificacion == identificacion);
            
        public void Actualizar(Usuario usuarioActualizado)
        {
            var usuario = BuscarPorId(usuarioActualizado.Identificacion);
            if (usuario == null) throw new System.Exception("Usuario no encontrado");
            
            usuario.Nombres = usuarioActualizado.Nombres;
            usuario.Apellidos = usuarioActualizado.Apellidos;
            usuario.Telefono = usuarioActualizado.Telefono;
            usuario.Direccion = usuarioActualizado.Direccion;
        }
    }
}