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
    public class ChangeManagementReqsController : BaseDocumentController<ChangeManagementReqs>
    {

        protected override DbSet<ChangeManagementReqs> getDbSet()
        {
            return db.ChangeManagementReqs;
        }

        // POST: ChangeManagementReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,ChCustomerClarity,ChCMReqs,ChReleases,ChComments")] ChangeManagementReqs changeManagementReqs)
        {
            return BaseCreate(changeManagementReqs);
        }
        
        // POST: ChangeManagementReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,ChCustomerClarity,ChCMReqs,ChReleases,ChComments")] ChangeManagementReqs changeManagementReqs)
        {
            return BaseEdit(changeManagementReqs);
        }
    }
}
