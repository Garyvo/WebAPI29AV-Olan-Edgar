using APIOAPE.Context;
using APIOAPE.Services.IServices;
using Azure.Core;
using Domain.DTO;
using Domain.Entities;
using APIOAPE.Context;
using APIOAPE.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace APIOAPE.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        //Incluye los nombres de los roles para no ver el id foreaneo directamente
        public async Task<Response<List<Usuario>>> GetAll()
        {
            try
            {

                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response, "Lista de Usuarios");

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }


        //Usuario individual buscado por el id que le corresponde
        public async Task<Response<Usuario>> GetbyId(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);

                return new Response<Usuario>(usuario, "Usuario encontrado");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        //  La creacion del usuario utilizando parametros que contiene el usuario nuevo
        public async Task<Response<Usuario>> Create(UsuarioRequest request)
        {
            try
            {
                Usuario usuario1 = new Usuario()
                {
                    Nombre = request.Nombre,
                    Password = request.Password,
                    UserName = request.UserName,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario1);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Usuario>(usuario1, "Usuario Creado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

        //Eliminar un usuario en base a su nombre de usuario siendo el primero en buscarlo en la base de datos
        public async Task<Response<Usuario>> DeleteUser(string request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == request);

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Usuario>(usuario, "Usuario Eliminado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

        //Actualizando el usuario con ayuda de 2 parametros, uno que es el nombre de usuario y otro que son los datos nuevos
        //que el administrador quiere actualizar
        public async Task<Response<Usuario>> UpdateUser(string request, UsuarioRequest request2)
        {
            try
            {

                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == request);


                usuario.Nombre = request2.Nombre;
                    usuario.Password = request2.Password;
                    usuario.UserName = request2.UserName;
                    usuario.FkRol = request2.FkRol;
                
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Usuario>(usuario, "Usuario editado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

    }
}