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
    }
}
