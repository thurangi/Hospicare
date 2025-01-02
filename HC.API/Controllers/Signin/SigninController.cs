using HC.API.Model;
using HC_DataAccess.Models;
using HC_DataAccess.Signin;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace HC.API.Controllers.Signin;

[ApiController]
[Route("api/[controller]")]
public class SigninController : ControllerBase
{
    //private static List<Users> users =
    //[
    //    new Users
    //    {
    //        Username = "testuser",
    //        Password = "testpassword"
    //    }
    //];
    private readonly IConfiguration _configuration;
    public SigninController(IConfiguration configuration)
    {
        _configuration = configuration;
    }


#if false
    [HttpPost("signin")]
    public static Task<HttpResponseMessage> UserSignIn1(SigninModel signinModel)
    {
        try
        {
            HttpResponseMessage responseMessage = new();
            if (signinModel is null)
            {

                responseMessage = new()
                {
                    Content = new StringContent("Resource not found", Encoding.UTF8, "application/json"),
                    StatusCode = System.Net.HttpStatusCode.NoContent
                };
            }
            GetUsersMain getUsersMain = new();
            string result = string.Empty;
            getUsersMain.GetEntities(signinModel!, out result);

            if (result != null)
            {
                responseMessage = new()
                {
                    Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json"),
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            return Task.FromResult(responseMessage);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

#endif



    [HttpPost("signin")]
    public async Task<IActionResult> UserSignIn([FromBody] SigninModel signinModel)
    {
        try
        {
            if (signinModel is null)
            {
                return NoContent();
            }

            GetUsersMain getUsersMain = new();
            string result = string.Empty;
            getUsersMain.GetEntities(signinModel, out result);
            if (result == "not success")
            {
                // Return Unauthorized if credentials are invalid
                return Unauthorized("Invalid username or password.");
            }
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Resource not found");
            }
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return StatusCode(500, "Internal server error");
        }
    }

}
