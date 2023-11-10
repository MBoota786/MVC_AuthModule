using Microsoft.AspNetCore.Mvc;

namespace _3_Auth_Module_AtoZ.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
