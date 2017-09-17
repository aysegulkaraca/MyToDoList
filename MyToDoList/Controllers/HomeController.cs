using MyToDoList.db;
using MyToDoList.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyToDoList.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private PrjContext db = new PrjContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(db.MyToDoLists.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(string info)
        {
            var newTodo = new MyTodo
            {
                Info = info,
                IsConclude = false,
                CrtDate = DateTime.Now

            };
            db.MyToDoLists.Add(newTodo);
            db.SaveChanges();
            return Json(newTodo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Guid? Id)
        {
            var todo = db.MyToDoLists.SingleOrDefault(x => x.Id == Id);
            if (todo == null)
                return Json("Failed.", JsonRequestBehavior.AllowGet);

            db.MyToDoLists.Remove(todo);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsConclude(Guid? Id)
        {
            var todo = db.MyToDoLists.SingleOrDefault(x => x.Id == Id);
            if (todo == null)
                return Json("Failed.", JsonRequestBehavior.AllowGet);

            if (todo.IsConclude == true)
                todo.IsConclude = false;
            else
                todo.IsConclude = true;

            return Json(todo, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}