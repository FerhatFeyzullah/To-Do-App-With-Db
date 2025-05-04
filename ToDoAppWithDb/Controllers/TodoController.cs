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

            ViewBag.LoginError = "Elbet Yazacak Birşey Bulunur.";
            return View();

        }
        [HttpGet]
        public IActionResult ToDoList()
        {
            var aktifUserId = HttpContext.Session.GetInt32("UserId");
            var list = dbcontext.ToDos.Include(u => u.User).Where(u => u.UserId == aktifUserId).ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult ToggleComplete([FromBody] ToDo todoUpdate)
        {
            var todo = dbcontext.ToDos.FirstOrDefault(t => t.ID == todoUpdate.ID);
            if (todo == null) return NotFound();

            todo.IsComp = todoUpdate.IsComp;
            dbcontext.SaveChanges();

            return Ok();
        }

        public IActionResult Delete(int id) 
        {
        var tod = dbcontext.ToDos.Find(id);
            if (tod != null)
            {
                dbcontext.ToDos.Remove(tod);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("ToDoList", "Todo");
        }

        [HttpGet]
        public IActionResult ToDoEdit(int id)
        {
            var todo = dbcontext.ToDos.FirstOrDefault(t => t.ID == id);
            if (todo == null) return NotFound();

            return View(todo);
        }

        [HttpPost]
        public IActionResult ToDoEdit(ToDo updatedTodo)
        {
            if (!string.IsNullOrWhiteSpace(updatedTodo.Task))
            {
                var todo = dbcontext.ToDos.FirstOrDefault(t => t.ID == updatedTodo.ID);
                if (todo == null) return NotFound();

                todo.Task = updatedTodo.Task;
                todo.IsComp = false;
                dbcontext.SaveChanges();

                return RedirectToAction("ToDoList");
            }
            ViewBag.EditError = "Elbet Yazacak Birşey Bulunur.";
            return View();
            


        }

    }
}
