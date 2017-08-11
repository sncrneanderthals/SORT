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
    public class AppsSupportReqsController : BaseDocumentController<AppsSupportReqs>
    {
        protected override DbSet<AppsSupportReqs> getDbSet()
        {
            return db.AppsSupportReqs;
        }

        // POST: /Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SupContacts,SupAccountsAccess,SupToolsA,SupToolsB,SupToolsC,SupToolsD,SupDemoTraining,SupContactsProvided,SupCustContact,SupComments")] AppsSupportReqs appsSupportReqs)
        {
            return BaseCreate(appsSupportReqs);
        }

        // POST: Edit/{ID}
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SupContacts,SupAccountsAccess,SupToolsA,SupToolsB,SupToolsC,SupToolsD,SupDemoTraining,SupContactsProvided,SupCustContact,SupComments")] AppsSupportReqs appsSupportReqs)
        {
            return BaseEdit(appsSupportReqs);
        }
    }
}
