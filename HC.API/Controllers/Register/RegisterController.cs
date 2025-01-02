using HC_DataAccess.Models;
using HC_DataAccess.Signin;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterUserMain _registerUser;

        public RegisterController(RegisterUserMain registerUser)
        {
            _registerUser = registerUser;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _registerUser.RegisterUserAsync(model);

            if (user == null)
            {
                return BadRequest("User is already taken.");
            }
            return Ok(new { message = "User registered successfully" });
        }
    }
}
