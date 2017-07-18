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

namespace SORT_doc_app.Controllers
{
    public class ServiceSpecificsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: ServiceSpecifics
        public ActionResult Index()
        {
            var serviceSpecifics = db.ServiceSpecifics.Include(s => s.Project);
            return View(serviceSpecifics.ToList());
        }

        // GET: ServiceSpecifics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSpecifics serviceSpecifics = db.ServiceSpecifics.Find(id);
            if (serviceSpecifics == null)
            {
                return HttpNotFound();
            }
            return View(serviceSpecifics);
        }

        // GET: ServiceSpecifics/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID");
            return View();
        }

        // POST: ServiceSpecifics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,Links,VPN,HostPlatform,BackupRecovery,NotesAndGrid,Changes,GoLiveReqs,SLAsSOW,LicensingAndHardware,BCorDR,SSComments")] ServiceSpecifics serviceSpecifics)
        {
            if (ModelState.IsValid)
            {
                db.ServiceSpecifics.Add(serviceSpecifics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", serviceSpecifics.ProjectID);
            return View(serviceSpecifics);
        }

        // GET: ServiceSpecifics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSpecifics serviceSpecifics = db.ServiceSpecifics.Find(id);
            if (serviceSpecifics == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", serviceSpecifics.ProjectID);
            return View(serviceSpecifics);
        }

        // POST: ServiceSpecifics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,Links,VPN,HostPlatform,BackupRecovery,NotesAndGrid,Changes,GoLiveReqs,SLAsSOW,LicensingAndHardware,BCorDR,SSComments")] ServiceSpecifics serviceSpecifics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceSpecifics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "UserID", serviceSpecifics.ProjectID);
            return View(serviceSpecifics);
        }

        // GET: ServiceSpecifics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSpecifics serviceSpecifics = db.ServiceSpecifics.Find(id);
            if (serviceSpecifics == null)
            {
                return HttpNotFound();
            }
            return View(serviceSpecifics);
        }

        // POST: ServiceSpecifics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSpecifics serviceSpecifics = db.ServiceSpecifics.Find(id);
            db.ServiceSpecifics.Remove(serviceSpecifics);
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
