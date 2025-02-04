using System.Text;
using HC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HC.Web.Controllers;

public class SigninController : Controller
{

    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Authenticate(Users usersModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", usersModel);
        }
        using (var _httpClient = new HttpClient())
        {
            Users users = new()
            {
                Username = usersModel.Username,
                Password = usersModel.Password,
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");
            Console.WriteLine(jsonContent);
            using (var res = await _httpClient.PostAsync("http://localhost:5123/api/Signin/authenticate", jsonContent))
            {
                if (res.IsSuccessStatusCode)
                {
                    // Handle successful authentication
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle failed authentication
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
        }
        return View("Index", usersModel);
    }
}
