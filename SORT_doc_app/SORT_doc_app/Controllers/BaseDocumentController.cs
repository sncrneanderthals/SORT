using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SORT_doc_app.Context;
using SORT_doc_app.Models;
using Microsoft.AspNet.Identity;

namespace SORT_doc_app.Controllers
{
    public abstract class BaseDocumentController<T> : Controller where T : BaseDocumentModel
    {
        protected SORT_doc_appContext db = new SORT_doc_appContext();

        protected abstract DbSet<T> getDbSet();

        // GET: Index
        public ActionResult Index()
        {
            var retList = getDbSet().Include(a => a.Project);
            return View(retList.ToList());
        }

        // GET: Details/{ID}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T found = getDbSet().Find(id);
            if (found == null)
            {
                return HttpNotFound();
            }
            return View(found);
        }

        // GET: Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        public ActionResult BaseCreate(T t)
        {
            if(ModelState.IsValid)
            {
                getDbSet().Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", t.ProjectID);
            return View(t);
        }

        // GET: Edit/{ID}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T t = getDbSet().Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", t.ProjectID);
            return View(t);
        }

        public ActionResult BaseEdit(T t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(t.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "";
                newEvent.EventType = "Edit";
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Details", t);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", t.ProjectID);
            return View(t);
        }

        // GET: Delete/{ID}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T t = getDbSet().Find(id);
            if(t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        // POST: Delete/{ID}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T t = getDbSet().Find(id);
            getDbSet().Remove(t);
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