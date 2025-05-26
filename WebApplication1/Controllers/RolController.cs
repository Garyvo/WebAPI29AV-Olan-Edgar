using APIOAPE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using System.Reflection.Metadata.Ecma335;

namespace APIOAPE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;
        
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _rolServices.GetAll();
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _rolServices.GetbyId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create (RolRequest request)
        {
            var response = await _rolServices.Create(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRol (string request)
        {
            var response = await _rolServices.DeleteRol(request);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateRol(string request, RolRequest request2)
        {
            var response = await _rolServices.UpdateRol(request, request2);
            return Ok(response);
        }



    }
}
