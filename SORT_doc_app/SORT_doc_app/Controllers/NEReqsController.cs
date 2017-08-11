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
    public class NEReqsController : BaseDocumentController<NEReqs>
    {
        protected override DbSet<NEReqs> getDbSet()
        {
            return db.NEReqs;
        }

        // POST: NEReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,NEYesNo,NEChangeContact,NEChangeDescription,NEChangeLocation,NEChangeIPInfo,NEChangeReasonResult,NEChangeSummary,NEServiceContact,NEServiceDescription,NEServiceLocation,NEServiceIPInfo,NEServiceResult,NEServiceSummary,NEAcqMigrDomain,NEAcqMigrDNS,NEAcqTunnels,NEAcqSummary,NENewConfirmConnectivity,NENewSummary,NEEnvironment,NEComments")] NEReqs nEReqs)
        {
            return BaseCreate(nEReqs);
        }

        // POST: NEReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,NEYesNo,NEChangeContact,NEChangeDescription,NEChangeLocation,NEChangeIPInfo,NEChangeReasonResult,NEChangeSummary,NEServiceContact,NEServiceDescription,NEServiceLocation,NEServiceIPInfo,NEServiceResult,NEServiceSummary,NEAcqMigrDomain,NEAcqMigrDNS,NEAcqTunnels,NEAcqSummary,NENewConfirmConnectivity,NENewSummary,NEEnvironment,NEComments")] NEReqs nEReqs)
        {
            return BaseEdit(nEReqs);
        }
    }
}
