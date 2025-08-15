using Microsoft.AspNetCore.Mvc;

namespace HC.Web.Controllers
{
    public class ForgotPasswordController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public  async Task<ActionResult> ResetPassword()
        {
            return View();
        }

    }


}
