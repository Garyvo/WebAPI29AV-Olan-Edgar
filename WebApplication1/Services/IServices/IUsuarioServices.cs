using Domain.Entities;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIOAPE.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetAll();
        public Task<Response<Usuario>> GetbyId(int id);
        public Task<Response<Usuario>> Create(UsuarioRequest request);

        public Task<Response<Usuario>> DeleteUser(string request);

        public Task<Response<Usuario>> UpdateUser(string request, UsuarioRequest request2);
    }
}
