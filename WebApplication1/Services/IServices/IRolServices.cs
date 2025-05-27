using Domain.Entities;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIOAPE.Services.IServices
{
    public interface IRolServices
    {
        //Interfaz de Rol para que se acceda a los metodos por exterior sin ver directamente los servicios
        public Task<Response<List<Rol>>> GetAll();
        public Task<Response<Rol>> GetbyId(int id);
        public Task<Response<Rol>> Create(RolRequest request);

        public Task<Response<Rol>> DeleteRol(string request);

        public Task<Response<Rol>> UpdateRol(string request, RolRequest request2);
    }
}
