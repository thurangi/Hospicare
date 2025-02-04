using HC_DataAccess.Data;
using HC_DataAccess.Models;
using HC_DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserServices _userServices;

        public RegisterController(UserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _userServices.RegisterUserAsync(model);

            if (user == null)
            {
                return BadRequest("User is already taken.");
            }
            return Ok(new { message = "User registered successfully" });
        }


        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var  role = await _userServices.GetAllRolesAsync();
            return Ok(role);
        }
    }
}
