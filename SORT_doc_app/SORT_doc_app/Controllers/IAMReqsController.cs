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
    public class IAMReqsController : BaseDocumentController<IAMReqs>
    {
        protected override DbSet<IAMReqs> getDbSet()
        {
            return db.IAMReqs;
        }

        // POST: IAMReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,IAMContacts,IAMTraining,IAMSummary,IAMApproval,IAMUserAccess,IAMUrls,IAMPassword,IAMAccLockout,IAMOLA,IAMPermission,IAMComments")] IAMReqs iAMReqs)
        {
            return BaseCreate(iAMReqs);
        }

        // POST: IAMReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,IAMContacts,IAMTraining,IAMSummary,IAMApproval,IAMUserAccess,IAMUrls,IAMPassword,IAMAccLockout,IAMOLA,IAMPermission,IAMComments")] IAMReqs iAMReqs)
        {
            return BaseEdit(iAMReqs);
        }
    }
}
