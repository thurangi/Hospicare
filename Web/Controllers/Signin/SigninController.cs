using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers.Signin;

public class SigninController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public SigninController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View(new LoginModel());
    }
}
