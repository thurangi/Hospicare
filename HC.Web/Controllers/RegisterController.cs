using System.Text;
using HC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HC.Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", registerModel);
            }
            using (var _httpClient = new HttpClient())
            {
                RegisterModel model  = new()
                {
                    UserName = registerModel.UserName,
                    Password = registerModel.Password,
                    ConfirmPassword = registerModel.ConfirmPassword,
                    FullName = registerModel.FullName,
                    Email = registerModel.Email,
                    Gender = registerModel.Gender,
                    PhoneNumber = registerModel.PhoneNumber,
                    RoleID = registerModel.RoleID
                };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var res = await _httpClient.PostAsync("http://localhost:5123/api/Register/register", jsonContent))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        // Handle successful authentication
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Handle failed authentication
                        ModelState.AddModelError("", "Could not create User");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
