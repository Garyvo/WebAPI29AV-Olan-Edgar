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
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario1, "Usuario Creado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public async Task<Response<Usuario>> DeleteUser(string request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == request);

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Usuario Eliminado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

    }
}