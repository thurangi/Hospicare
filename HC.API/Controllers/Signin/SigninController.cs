using HC_DataAccess.Models;
using HC_DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC.API.Controllers.Signin;

[ApiController]
[Route("api/[controller]")]
public class SigninController : ControllerBase
{

    private readonly UserServices _userServices;

    public SigninController(UserServices userServices)
    {
        _userServices = userServices;
    }
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] SigninModel login)
    {
        if (login is null)
        {
            return NoContent();
        }
        string result = string.Empty;
        _userServices.GetEntities(login, out result);
        if (!string.IsNullOrEmpty(result) && result != "not success")
        {
            return Ok(result);
        }
        // Return Unauthorized if credentials are invalid
        return Unauthorized("Invalid username or password.");
    }
}
