using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAppWithDb.Data;
using ToDoAppWithDb.Models;
using ToDoAppWithDb.ViewModel;

namespace ToDoAppWithDb.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext dbcontext;

        public TodoController(AppDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult ToDoAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ToDoAdd(TodoTaskModel td)
        {
            var aktifUserId = HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid)
            {
                var newTodo = new ToDo
                {
                    Task = td.Task,
                    UserId = aktifUserId.Value
                };
                dbcontext.ToDos.Add(newTodo);
                dbcontext.SaveChanges();
                return RedirectToAction("ToDoList");
            }


            return View();

        }
        [HttpGet]
        public IActionResult ToDoList()
        {
            var aktifUserId = HttpContext.Session.GetInt32("UserId");
            var list = dbcontext.ToDos.Include(u => u.User).Where(u => u.UserId == aktifUserId).ToList();
            return View(list);
        }
    }
}
