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
    public class ProjectsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,AuthorName,Title,_Date")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                // when a new project is created, create all corresponding entities
                AppsSupportReqs appsSupportReqs = new AppsSupportReqs();
                appsSupportReqs.ProjectID = project.ID;
                db.AppsSupportReqs.Add(appsSupportReqs);
                ChangeManagementReqs changeManagementReqs = new ChangeManagementReqs();
                changeManagementReqs.ProjectID = project.ID;
                db.ChangeManagementReqs.Add(changeManagementReqs);
                DBAReqs dbaReqs = new DBAReqs();
                dbaReqs.ProjectID = project.ID;
                db.DBAReqs.Add(dbaReqs);
                EOCReqs eocReqs = new EOCReqs();
                eocReqs.ProjectID = project.ID;
                db.EOCReqs.Add(eocReqs);
                GISReqs gisReqs = new GISReqs();
                gisReqs.ProjectID = project.ID;
                db.GISReqs.Add(gisReqs);
                ITCS itcs = new ITCS();
                itcs.ProjectID = project.ID;
                db.ITCS.Add(itcs);
                NEReqs neReqs = new NEReqs();
                neReqs.ProjectID = project.ID;
                db.NEReqs.Add(neReqs);
                PBX pbx = new PBX();
                pbx.ProjectID = project.ID;
                db.PBX.Add(pbx);
                QAReqs qaReqs = new QAReqs();
                qaReqs.ProjectID = project.ID;
                db.QAReqs.Add(qaReqs);
                Risks risks = new Risks();
                risks.ProjectID = project.ID;
                db.Risks.Add(risks);
                SCVReqs scvReqs = new SCVReqs();
                scvReqs.ProjectID = project.ID;
                db.SCVReqs.Add(scvReqs);
                ServiceSpecifics serviceSpecifics = new ServiceSpecifics();
                serviceSpecifics.ProjectID = project.ID;
                db.ServiceSpecifics.Add(serviceSpecifics);
                SignOff signOff = new SignOff();
                signOff.ProjectID = project.ID;
                db.SignOffs.Add(signOff);
                SMOReqs smoReqs = new SMOReqs();
                smoReqs.ProjectID = project.ID;
                db.SMOReqs.Add(smoReqs);
                SREReqs sreReqs = new SREReqs();
                sreReqs.ProjectID = project.ID;
                db.SREReqs.Add(sreReqs);
                Summary summary = new Summary();
                summary.ProjectID = project.ID;
                db.Summaries.Add(summary); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,AuthorName,Title,_Date")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
