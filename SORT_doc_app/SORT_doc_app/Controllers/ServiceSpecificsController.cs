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
    public class ServiceSpecificsController : BaseDocumentController<ServiceSpecifics>
    {
        protected override DbSet<ServiceSpecifics> getDbSet()
        {
            return db.ServiceSpecifics;
        }

        // POST: ServiceSpecifics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,Links,VPN,HostPlatform,BackupRecovery,NotesAndGrid,Changes,GoLiveReqs,SLAsSOW,LicensingAndHardware,BCorDR,SSComments")] ServiceSpecifics serviceSpecifics)
        {
            return BaseCreate(serviceSpecifics);
        }

        // POST: ServiceSpecifics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,Links,VPN,HostPlatform,BackupRecovery,NotesAndGrid,Changes,GoLiveReqs,SLAsSOW,LicensingAndHardware,BCorDR,SSComments")] ServiceSpecifics serviceSpecifics)
        {
            return BaseEdit(serviceSpecifics);
        }
    }
}
