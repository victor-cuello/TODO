using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models;
using MVCWebApp.Models.UserTasks;

namespace MVCWebApp.Controllers
{
    public class UserTasksController : Controller
    {
        private MVCWebAppContext db = new MVCWebAppContext();

        // GET: UserTasks
        public ActionResult Index()
        {
            return View(db.UserTasks.ToList());
        }

        // GET: UserTasks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTasks userTasks = db.UserTasks.Find(id);
            if (userTasks == null)
            {
                return HttpNotFound();
            }
            return View(userTasks);
        }

        // GET: UserTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,Tittle,UserID,DateCreation,DateDue")] UserTasks userTasks)
        {
            if (ModelState.IsValid)
            {
                db.UserTasks.Add(userTasks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTasks);
        }

        // GET: UserTasks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTasks userTasks = db.UserTasks.Find(id);
            if (userTasks == null)
            {
                return HttpNotFound();
            }
            return View(userTasks);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,Tittle,UserID,DateCreation,DateDue")] UserTasks userTasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTasks);
        }

        // GET: UserTasks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTasks userTasks = db.UserTasks.Find(id);
            if (userTasks == null)
            {
                return HttpNotFound();
            }
            return View(userTasks);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UserTasks userTasks = db.UserTasks.Find(id);
            db.UserTasks.Remove(userTasks);
            db.SaveChanges();
            return RedirectToAction("Index");
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
