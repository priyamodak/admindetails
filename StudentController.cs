using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_EF_CRUD_PostgreSQL.DataContext1;
using MVC_EF_CRUD_PostgreSQL.Models;

namespace MVC_EF_CRUD_PostgreSQL.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext1 db = new ApplicationDbContext1();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.students.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            return View(studentClass);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,studentname,email")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(studentClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentClass);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.students.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            return View(studentClass);
        }

        // POST: Student/Edit/5
          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,studentname,email")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentClass);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass studentClass = db.students.Find(id);
            if (studentClass == null)
            {
                return HttpNotFound();
            }
            return View(studentClass);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClass studentClass = db.students.Find(id);
            db.students.Remove(studentClass);
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
