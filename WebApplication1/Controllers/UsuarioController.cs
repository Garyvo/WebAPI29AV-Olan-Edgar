using APIOAPE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using System.Reflection.Metadata.Ecma335;

namespace APIOAPE.Controllers
{     //Se hace route para añadir el apartado en el api
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        //Se usa el controlador para inicializar los metodos en el swagger
        private readonly IUsuarioServices _usuarioServices;
        
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

        }
        //Metodo Get para obtener datos de la API
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetAll();
            return Ok(response);
        }

        //Metodo Get para obtener datos de la API con un parametro 
        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _usuarioServices.GetbyId(id);
            return Ok(response);
        }

        //Metodo Get para subir datos de la API
        [HttpPost]
        public async Task<IActionResult> Create (UsuarioRequest request)
        {
            var response = await _usuarioServices.Create(request);
            return Ok(response);
        }

        //Metodo Delete para eliminar datos de la API
        [HttpDelete]
        public async Task<IActionResult> DeleteUser (string request)
        {
            var response = await _usuarioServices.DeleteUser(request);
            return Ok(response);
        }


        //Metodo Put para hacer cambios datos de la API
        [HttpPut]

        public async Task<IActionResult> UpdateUser(string request, UsuarioRequest request2)
        {
            var response = await _usuarioServices.UpdateUser(request, request2);
            return Ok(response);
        }



    }
}
