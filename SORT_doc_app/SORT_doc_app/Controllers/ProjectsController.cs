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
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace SORT_doc_app.Controllers
{
    public class ProjectsController : Controller
    {
        private SORT_doc_appContext db = new SORT_doc_appContext();

        // GET: Projects
        public ActionResult Index(string sortOrder)
        {
         ViewBag.NumberSortParm = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
         ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
         ViewBag.TitleSortParm = sortOrder == "Name" ? "name_desc" : "Name";
         var projects = from s in db.Projects
                  select s;
        switch (sortOrder)
            {
                case "number_desc":
                    projects = projects.OrderByDescending(s => s.ID);
                    break;
                case "Name":
                    projects = projects.OrderBy(s => s.Title);
                    break;
                case "name_desc":
                    projects = projects.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    projects = projects.OrderBy(s => s._Date);
                    break;
                case "date_desc":
                    projects = projects.OrderByDescending(s => s._Date);
                    break;
                default:
                    projects = projects.OrderBy(s => s.ID);
                    break;
            }
            return View(projects.ToList());
        }

        // filter projects by live SORT
        public ActionResult Live()
        {
            var projects = db.Projects.Where(s => s.Open.Equals(true));
            return View("Index", projects);
        }

        // filter projects by closed SORT
        public ActionResult Closed()
        {
            var projects = db.Projects.Where(s => s.Open.Equals(false));
            return View("Index", projects);
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

            // get any assignees for each section
            var assignments = db.Assignments.Where(s => s.ProjectID.Equals(project.ID));
            List<string> sectionsList = new List<string>() { "summary", "servspec", "eoc", "appsupport","changeman", "gis",  "ne", "scv", "sre", "dba", "qa", "iam",  "pbx", "itcs",  "smo", "risks", "signoff"}; 
            foreach (var section in sectionsList)
            {
                var assigned = assignments.Where(s => s.Section.Equals(section));
                // use viewdata to populate viewbag key-value pairs                
                if (assigned.Any())
                { 
                    ViewData.Add(section, assigned);
                }
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
        public ActionResult Create([Bind(Include = "ID,UserID,AuthorName,Title,Description,_Date,Open,SummaryDone,ServSpecDone,EOCDone,AppSupportDone,ChangeManDone,GISDone,NEDone,SCVDone,SREDone,DBADone,QADone,IAMDone,PBXDone,ITCSDone,SMODone,RisksDone,SignOffDone")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                project.Open = true;
                db.SaveChanges();
                // when a new project is created, create all corresponding entities
                AppsSupportReqs appsSupportReqs = new AppsSupportReqs();
                appsSupportReqs.ProjectID = project.ID;
                appsSupportReqs.ID = project.ID;
                db.AppsSupportReqs.Add(appsSupportReqs);
                ChangeManagementReqs changeManagementReqs = new ChangeManagementReqs();
                changeManagementReqs.ProjectID = project.ID;
                changeManagementReqs.ID = project.ID;
                db.ChangeManagementReqs.Add(changeManagementReqs);
                DBAReqs dbaReqs = new DBAReqs();
                dbaReqs.ProjectID = project.ID;
                dbaReqs.ID = project.ID;
                db.DBAReqs.Add(dbaReqs);
                EOCReqs eocReqs = new EOCReqs();
                eocReqs.ProjectID = project.ID;
                eocReqs.ID = project.ID;
                db.EOCReqs.Add(eocReqs);
                GISReqs gisReqs = new GISReqs();
                gisReqs.ProjectID = project.ID;
                gisReqs.ID = project.ID;
                db.GISReqs.Add(gisReqs);
                IAMReqs iamReqs = new IAMReqs();
                iamReqs.ProjectID = project.ID;
                iamReqs.ID = project.ID;
                db.IAMReqs.Add(iamReqs);
                ITCS itcs = new ITCS();
                itcs.ProjectID = project.ID;
                itcs.ID = project.ID;
                db.ITCS.Add(itcs);
                NEReqs neReqs = new NEReqs();
                neReqs.ProjectID = project.ID;
                neReqs.ID = project.ID;
                db.NEReqs.Add(neReqs);
                PBX pbx = new PBX();
                pbx.ProjectID = project.ID;
                pbx.ID = project.ID;
                db.PBX.Add(pbx);
                QAReqs qaReqs = new QAReqs();
                qaReqs.ProjectID = project.ID;
                qaReqs.ID = project.ID;
                db.QAReqs.Add(qaReqs);
                Risks risks = new Risks();
                risks.ProjectID = project.ID;
                // dates set to +1 month in the future
                // this is done to avoid null dates
                risks.RisksWarrantyDate = DateTime.Now.AddMonths(1);
                risks.RisksPreDate = DateTime.Now.AddMonths(1);
                risks.ID = project.ID;
                db.Risks.Add(risks);
                SCVReqs scvReqs = new SCVReqs();
                scvReqs.ProjectID = project.ID;
                scvReqs.ID = project.ID;
                db.SCVReqs.Add(scvReqs);
                ServiceSpecifics serviceSpecifics = new ServiceSpecifics();
                serviceSpecifics.ProjectID = project.ID;
                serviceSpecifics.ID = project.ID;
                db.ServiceSpecifics.Add(serviceSpecifics);
                SignOff signOff = new SignOff();
                signOff.ProjectID = project.ID;
                // signoff date set to +1 month in the future
                // this is done to avoid null dates
                signOff.SignOffDate = DateTime.Now.AddMonths(1);
                signOff.ID = project.ID;
                db.SignOffs.Add(signOff);
                SMOReqs smoReqs = new SMOReqs();
                smoReqs.ProjectID = project.ID;
                smoReqs.ID = project.ID;
                db.SMOReqs.Add(smoReqs);
                SREReqs sreReqs = new SREReqs();
                sreReqs.ProjectID = project.ID;
                sreReqs.ID = project.ID;
                db.SREReqs.Add(sreReqs);
                Summary summary = new Summary();
                summary.ProjectID = project.ID;
                summary.ID = project.ID;
                // default go live date set to +1 month in the future
                // this is done to avoid null dates
                summary.GoLiveDate = DateTime.Now.AddMonths(1);
                db.Summaries.Add(summary);
                //generate history event recording project creation
                Event newEvent = new Event();
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "New SORT Project \"" + project.Title + "\" with Number " + project.ID + " created by " + project.AuthorName;
                db.Events.Add(newEvent);
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
        public ActionResult Edit([Bind(Include = "ID,UserID,AuthorName,Title,Description,_Date,Open,SummaryDone,ServSpecDone,EOCDone,AppSupportDone,ChangeManDone,GISDone,NEDone,SCVDone,SREDone,DBADone,QADone,IAMDone,PBXDone,ITCSDone,SMODone,RisksDone,SignOffDone")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                // enter history event of edit
                Event newEvent = new Event();
                newEvent.ProjectID = project.ID;
                newEvent.EventBody = "SORT Project \"" + project.Title + "\" with Number " + project.ID + " was edited by " + project.AuthorName;
                db.Events.Add(newEvent);
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

        [HttpGet]
        public ActionResult Assign(int? id, string section)
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

            string sectionTitle = null;
            switch (section)
            {
                case "summary":
                    sectionTitle = "Service / Environment Summary Overview";
                    break;
                case "servspec":
                    sectionTitle = "High Level Service Specifics";
                    break;
                case "eoc":
                    sectionTitle = "EOC Requirements";
                    break;
                case "appsupport":
                    sectionTitle = "Apps Support Management";
                    break;
                case "changeman":
                    sectionTitle = "Change Management Requirements";
                    break;
                case "gis":
                    sectionTitle = "GIS Requirements";
                    break;
                case "ne":
                    sectionTitle = "NE Requirements";
                    break;
                case "scv":
                    sectionTitle = "SCV Requirements";
                    break;
                case "sre":
                    sectionTitle = "SRE Requirements";
                    break;
                case "dba":
                    sectionTitle = "DBA Requirements";
                    break;
                case "qa":
                    sectionTitle = "QA & Test Requirements";
                    break;
                case "iam":
                    sectionTitle = "IAM Requirements";
                    break;
                case "pbx":
                    sectionTitle = "PBX / Telephony Requirements";
                    break;
                case "itcs":
                    sectionTitle = "ITCS Requirements";
                    break;
                case "smo":
                    sectionTitle = "SMO Requirements";
                    break;
                case "risks":
                    sectionTitle = "Risks Identified / Outstanding at Sign Off";
                    break;
                case "signoff":
                    sectionTitle = "Sign Off Post Warranty Phase of live service";
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.sectionTitle = sectionTitle;
            ViewBag.section = section;
            return View(project);
        }

        [HttpPost]
        public ActionResult Assign(int? id, string section, string assignee)
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

            Assignment assignment = new Assignment();
            assignment.ProjectID = project.ID;
            assignment.Section = section;
            assignment.Assignee = assignee;
            db.Assignments.Add(assignment);
            db.SaveChanges();

            // mailer for invitation
            var author = project.AuthorName;
            var title = project.Title;
            string assignedSectionUrl = null;
            string assignedSectionName = null;
            switch (section)
            {
                case "summary":
                    assignedSectionName = "Service / Environment Summary Overview";
                    assignedSectionUrl = "Summaries";
                    break;
                case "servspec":
                    assignedSectionName = "High Level Service Specifics";
                    assignedSectionUrl = "ServiceSpecifics";
                    break;
                case "eoc":
                    assignedSectionName = "EOC Requirements";
                    assignedSectionUrl = "EOCReqs";
                    break;
                case "appsupport":
                    assignedSectionName = "Apps Support Management";
                    assignedSectionUrl = "AppsSupportReqs";
                    break;
                case "changeman":
                    assignedSectionName = "Change Management Requirements";
                    assignedSectionUrl = "ChangeManagementReqs";
                    break;
                case "gis":
                    assignedSectionName = "GIS Requirements";
                    assignedSectionUrl = "GISReqs";
                    break;
                case "ne":
                    assignedSectionName = "NE Requirements";
                    assignedSectionUrl = "NEReqs";
                    break;
                case "scv":
                    assignedSectionName = "SCV Requirements";
                    assignedSectionUrl = "SCVReqs";
                    break;
                case "sre":
                    assignedSectionName = "SRE Requirements";
                    assignedSectionUrl = "SREReqs";
                    break;
                case "dba":
                    assignedSectionName = "DBA Requirements";
                    assignedSectionUrl = "DBAReqs";
                    break;
                case "qa":
                    assignedSectionName= "QA & Test Requirements";
                    assignedSectionUrl = "QAReqs";
                    break;
                case "iam":
                    assignedSectionName = "IAM Requirements";
                    assignedSectionUrl = "IAMReqs";
                    break;
                case "pbx":
                    assignedSectionName = "PBX / Telephony Requirements";
                    assignedSectionUrl = "PBX";
                    break;
                case "itcs":
                    assignedSectionName = "ITCS Requirements";
                    assignedSectionUrl = "ITCS";
                    break;
                case "smo":
                    assignedSectionName = "SMO Requirements";
                    assignedSectionUrl = "SMOReqs";
                    break;
                case "risks":
                    assignedSectionName = "Risks Identified / Outstanding at Sign Off";
                    assignedSectionUrl = "Risks";
                    break;
                case "signoff":
                    assignedSectionName = "Sign Off Post Warranty Phase of live service";
                    assignedSectionUrl = "SignOffs";
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var baseUrl = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            var fullUrl = baseUrl + assignedSectionUrl + "/Edit/" + project.ID;
            var body = "<p>You have been invited by " + author + " to complete the SORT document \"" + title + "\" " + assignedSectionName + " section at </p>" + fullUrl;
            var message = new MailMessage();
            message.To.Add(new MailAddress(assignee));
            message.From = new MailAddress("sncrneanderthals@gmail.com");
            message.Subject = title + " - Invitation to complete " + assignedSectionName;
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sncrneanderthals@gmail.com",
                    // gmail security restrictions requires generated google app password for gmail account
                    Password = "bazoafgcduzqkweq"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);

            }
            // track assignment with an entry in SORT history
            Event newEvent = new Event();
            newEvent.ProjectID = project.ID;
            newEvent.EventBody = assignedSectionName + " section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been assigned to " + assignee;
            db.Events.Add(newEvent);
            db.SaveChanges();
            return RedirectToAction("Details",project);
        }

        public ActionResult Approve(int? id, string section)
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
            string sectionTitle = "";
            switch (section)
            {
                case "summary":
                    project.SummaryDone = true;
                    db.SaveChanges();
                    sectionTitle = "Service / Environment Summary";
                    break;
                case "servspec":
                    project.ServSpecDone = true;
                    db.SaveChanges();
                    sectionTitle = "High Level Service Specifics";
                    break;
                case "eoc":
                    project.SummaryDone = true;
                    db.SaveChanges();
                    sectionTitle = "EOC Requirements";
                    break;
                case "appsupport":
                    project.AppSupportDone = true;
                    db.SaveChanges();
                    sectionTitle = "Apps Support Management";
                    break;
                case "changeman":
                    project.ChangeManDone = true;
                    db.SaveChanges();
                    sectionTitle = "Change Management Requirements";
                    break;
                case "gis":
                    project.GISDone = true;
                    db.SaveChanges();
                    sectionTitle = "GIS Requirements";
                    break;
                case "ne":
                    project.NEDone = true;
                    db.SaveChanges();
                    sectionTitle = "NE Requirements";
                    break;
                case "scv":
                    project.SCVDone = true;
                    db.SaveChanges();
                    sectionTitle = "SCV Requirements";
                    break;
                case "sre":
                    project.SREDone = true;
                    db.SaveChanges();
                    sectionTitle = "SRE Requirements";
                    break;
                case "dba":
                    project.DBADone = true;
                    db.SaveChanges();
                    sectionTitle = "DBA Requirements";
                    break;
                case "qa":
                    project.QADone = true;
                    db.SaveChanges();
                    sectionTitle = "QA & Test Requirements";
                    break;
                case "iam":
                    project.IAMDone = true;
                    db.SaveChanges();
                    sectionTitle = "IAM Requirements";
                    break;
                case "pbx":
                    project.PBXDone = true;
                    db.SaveChanges();
                    sectionTitle = "PBX / Telephony Requirements";
                    break;
                case "itcs":
                    project.ITCSDone = true;
                    db.SaveChanges();
                    sectionTitle = "ITCS Requirements";
                    break;
                case "smo":
                    project.SMODone = true;
                    db.SaveChanges();
                    sectionTitle = "SMO Requirements";
                    break;
                case "risks":
                    project.RisksDone = true;
                    db.SaveChanges();
                    sectionTitle = "Risks Identified / Outstanding at Sign Off";
                    break;
                case "signoff":
                    project.SignOffDone = true;
                    db.SaveChanges();
                    sectionTitle = "Sign Off Post Warranty Phase of live service";
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // enter approval in event history
            var user = User.Identity.GetUserName();
            if (user == "") user = "Guest User";
            Event newEvent = new Event();
            newEvent.ProjectID = project.ID;
            newEvent.EventBody = sectionTitle + " section of SORT Project \"" + project.Title + "\" with Number " + project.ID + " has been approved by " + user;
            db.Events.Add(newEvent);
            db.SaveChanges();
            return RedirectToAction("Details", project);

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
