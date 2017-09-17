using MyToDoList.db;
using MyToDoList.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using System;

namespace MyToDoList.Controllers
{
    public class MyToDoesController : Controller
    {
        private ToDoDbContext db = new ToDoDbContext();

        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult List()
        {                        
            return Json(db.MyToDoLists.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(string Text)
        {
            var newTodo = new Todo
            {
                Text = Text,
                done = false,
                Created = DateTime.Now

            };
            db.MyToDoLists.Add(newTodo);
            db.SaveChanges();
            return Json(newTodo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Guid? Id)
        {
            var todo = db.MyToDoLists.SingleOrDefault(x => x.Id == Id);
            if (todo == null)
            {
                return Json("Failed.", JsonRequestBehavior.AllowGet);
            }
            db.MyToDoLists.Remove(todo);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Done(Guid? Id)
        {
            var todo = db.MyToDoLists.SingleOrDefault(x => x.Id == Id);
            if (todo == null)
            {
                return Json("Failed.", JsonRequestBehavior.AllowGet);
            }
            if (todo.done == true)
            {
                todo.done = false;
            }
            else
            {
                todo.done = true;
            }
            return Json(todo, JsonRequestBehavior.AllowGet);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
