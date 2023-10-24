using Microsoft.AspNetCore.Mvc;

namespace AniProject.Controllers
{
    public class AccountController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
