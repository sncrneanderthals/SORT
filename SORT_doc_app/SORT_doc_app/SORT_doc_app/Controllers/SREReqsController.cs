﻿using System;
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
    public class SREReqsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: SREReqs
        public ActionResult Index()
        {
            var sREReqs = db.SREReqs.Include(s => s.Project);
            return View(sREReqs.ToList());
        }

        // GET: SREReqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SREReqs sREReqs = db.SREReqs.Find(id);
            if (sREReqs == null)
            {
                return HttpNotFound();
            }
            return View(sREReqs);
        }

        // GET: SREReqs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: SREReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SREYesNo,SREYContacts,SREDocument,SREPasswords")] SREReqs sREReqs)
        {
            if (ModelState.IsValid)
            {
                db.SREReqs.Add(sREReqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sREReqs.ProjectID);
            return View(sREReqs);
        }

        // GET: SREReqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SREReqs sREReqs = db.SREReqs.Find(id);
            if (sREReqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sREReqs.ProjectID);
            return View(sREReqs);
        }

        // POST: SREReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SREYesNo,SREYContacts,SREDocument,SREPasswords")] SREReqs sREReqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sREReqs).State = EntityState.Modified;
                // track assignment with an entry in SORT history
                var user = User.Identity.GetUserName();
                if (user == "") user = "Guest User";
                Event newEvent = new Event();
                var project = db.Projects.Find(sREReqs.ProjectID);
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "SRE Requirements section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been edited by " + user;
                db.Events.Add(newEvent);
                db.SaveChanges();
                return RedirectToAction("Detaisl", sREReqs);
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", sREReqs.ProjectID);
            return View(sREReqs);
        }

        // GET: SREReqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SREReqs sREReqs = db.SREReqs.Find(id);
            if (sREReqs == null)
            {
                return HttpNotFound();
            }
            return View(sREReqs);
        }

        // POST: SREReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SREReqs sREReqs = db.SREReqs.Find(id);
            db.SREReqs.Remove(sREReqs);
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