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

namespace SORT_doc_app.Controllers
{
    public class PBXesController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: PBXes
        public ActionResult Index()
        {
            var pBX = db.PBX.Include(p => p.Project);
            return View(pBX.ToList());
        }

        // GET: PBXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBX pBX = db.PBX.Find(id);
            if (pBX == null)
            {
                return HttpNotFound();
            }
            return View(pBX);
        }

        // GET: PBXes/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: PBXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,PBXContacts,PBXPhysAddress,PBXTestPhone,PBXShipSend,PBXExtConf,PBX911,PBXDisconnect,PBXAuthorised,PBXCollab,PBXDSCIMSA,PBXComments")] PBX pBX)
        {
            if (ModelState.IsValid)
            {
                db.PBX.Add(pBX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", pBX.ProjectID);
            return View(pBX);
        }

        // GET: PBXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBX pBX = db.PBX.Find(id);
            if (pBX == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", pBX.ProjectID);
            return View(pBX);
        }

        // POST: PBXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,PBXContacts,PBXPhysAddress,PBXTestPhone,PBXShipSend,PBXExtConf,PBX911,PBXDisconnect,PBXAuthorised,PBXCollab,PBXDSCIMSA,PBXComments")] PBX pBX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", pBX.ProjectID);
            return View(pBX);
        }

        // GET: PBXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBX pBX = db.PBX.Find(id);
            if (pBX == null)
            {
                return HttpNotFound();
            }
            return View(pBX);
        }

        // POST: PBXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBX pBX = db.PBX.Find(id);
            db.PBX.Remove(pBX);
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
