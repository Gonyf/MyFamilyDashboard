using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFamilyDashboard.Data;

namespace MyFamilyDashboard.Controllers
{
    public class TodoController : Controller
    {
        #region protected members
        protected ApplicationDbContext applicationDbContext;

        #endregion

        public TodoController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }
        public IActionResult Index()
        {
            return View(applicationDbContext.TodoLists);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoListDataModel todoList)
        {
            applicationDbContext.TodoLists.Add(todoList);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todoList = applicationDbContext.TodoLists.Include(t => t.TodoItems).FirstOrDefault(t => t.Id == id);
            return View(todoList);
        }
        [HttpPost]
        public IActionResult Edit(TodoListDataModel todoList)
        {
            //var todoListExisting = applicationDbContext.TodoLists.Include(tdl => tdl.TodoItems).FirstOrDefault(tdl => tdl.Id == todoList.Id);
            //todoListExisting.TodoItems = new List<TodoItemDataModel>();
            //applicationDbContext.TodoLists.Update(todoListExisting);
            //applicationDbContext.SaveChanges();
            foreach (var item in todoList.TodoItems)
            {
                if (item.Text == null && item.ID != Guid.Empty)
                {
                    applicationDbContext.Entry(item).State = EntityState.Deleted;
                }
            }
            applicationDbContext.TodoLists.Update(todoList);
            applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}