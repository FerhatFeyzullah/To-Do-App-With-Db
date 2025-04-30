using Microsoft.AspNetCore.Mvc;

namespace ToDoAppWithDb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()         
        {
            return View();
        }
    }
}
