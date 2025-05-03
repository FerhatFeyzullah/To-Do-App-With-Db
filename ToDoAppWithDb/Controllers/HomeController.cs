using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoAppWithDb.Data;
using ToDoAppWithDb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;
using ToDoAppWithDb.ViewModel;



namespace ToDoAppWithDb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()         
        {
            return View();
        }
       

        private readonly AppDbContext dbcontext;

        public HomeController(AppDbContext context)
        {
            dbcontext = context;
        }

        [HttpPost]
        public IActionResult SignUp(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();               
            return RedirectToAction("SignIn","Home");           
            
        }

        [HttpPost]
        public IActionResult SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var kullanici = dbcontext.Users
                .SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (kullanici == null)
            {
                ViewBag.LoginError = "Email veya şifre yanlış.";
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", kullanici.Id);
            HttpContext.Session.SetString("Username", kullanici.Username);


            return RedirectToAction("ToDoAdd","Todo");
   
        }
        
        

    }


}
