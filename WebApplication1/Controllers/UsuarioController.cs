using APIOAPE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using System.Reflection.Metadata.Ecma335;

namespace APIOAPE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetAll();
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _usuarioServices.GetbyId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create (UsuarioRequest request)
        {
            var response = await _usuarioServices.Create(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser (string request)
        {
            var response = await _usuarioServices.DeleteUser(request);
            return Ok(response);
        }
            
    }
}
