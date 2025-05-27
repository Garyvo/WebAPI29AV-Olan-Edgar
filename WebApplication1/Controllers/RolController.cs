using APIOAPE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using System.Reflection.Metadata.Ecma335;

namespace APIOAPE.Controllers
{
    //Se hace route para añadir el apartado en el api
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        //Se usa el controlador para inicializar los metodos en el swagger
        private readonly IRolServices _rolServices;
        
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;

        }

        //Metodo Get para obtener datos de la API
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _rolServices.GetAll();
            return Ok(response);
        }


        //Metodo Get para obtener datos de la API con un parametro 

        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _rolServices.GetbyId(id);
            return Ok(response);
        }



        //Metodo Get para subir datos de la API
        [HttpPost]
        public async Task<IActionResult> Create (RolRequest request)
        {
            var response = await _rolServices.Create(request);
            return Ok(response);
        }


        //Metodo Delete para eliminar datos de la API
        [HttpDelete]
        public async Task<IActionResult> DeleteRol (string request)
        {
            var response = await _rolServices.DeleteRol(request);
            return Ok(response);
        }


        //Metodo Put para hacer cambios datos de la API
        [HttpPut]

        public async Task<IActionResult> UpdateRol(string request, RolRequest request2)
        {
            var response = await _rolServices.UpdateRol(request, request2);
            return Ok(response);
        }



    }
}
