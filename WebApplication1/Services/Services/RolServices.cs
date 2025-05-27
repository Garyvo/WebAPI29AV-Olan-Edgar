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
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de roles que obtiene todos los roles en un arreglo
        public async Task<Response<List<Rol>>> GetAll()
        {
            try
            {

                List<Rol> response = await _context.Roles.ToListAsync();

                return new Response<List<Rol>>(response, "Lista de Roles");

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        //Busca el Rol por el id que contiene, el primero en encontrar es el que buscara
        public async Task<Response<Rol>> GetbyId(int id)
        {
            try
            {
                Rol rol = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);

                return new Response<Rol>(rol, "Rol encontrado");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        //Crea un nuevo rol con base a su parametro de tipo rol nuevo
        public async Task<Response<Rol>> Create(RolRequest request)
        {
            try
            {
                Rol rol1 = new Rol()
                {
                    Nombre = request.Nombre,
                };

                _context.Roles.Add(rol1);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Rol>(rol1, "Rol Creado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

        //Elimina el rol por el nombre que le dieron, busca el nombre por el primero en coincidir y lo elimina
        public async Task<Response<Rol>> DeleteRol(string request)
        {
            try
            {
                Rol rol = await _context.Roles.FirstOrDefaultAsync(x => x.Nombre == request);

                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Rol>(rol, "Rol Eliminado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        } 

        //Usa 2 parametros, tipo texto uno tipo otro tipo rol 

        public async Task<Response< Rol>> UpdateRol(string request, RolRequest request2)
        {
            try
            {

                Rol rol = await _context.Roles.FirstOrDefaultAsync(x => x.Nombre == request);


                rol.Nombre = request2.Nombre;
                
                _context.Roles.Update(rol);
                await _context.SaveChangesAsync(); //Se guarda cambios

                return new Response<Rol>(rol, "Rol editado exitosamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }

    }
}