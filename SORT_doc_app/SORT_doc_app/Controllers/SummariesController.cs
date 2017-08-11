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
    public class SummariesController : BaseDocumentController<Summary>
    {
        protected override DbSet<Summary> getDbSet()
        {
            return db.Summaries;
        }

        // POST: Summaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,ServiceName,Description,ProductName,ServiceDelivery,CostCentre,ProjectManagers,PCISOX,GoLiveDate,ArchLeadTeams,SupportTeams,SummaryComments")] Summary summary)
        {
            return BaseCreate(summary);
        }
        
        // POST: Summaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,ServiceName,Description,ProductName,ServiceDelivery,CostCentre,ProjectManagers,PCISOX,GoLiveDate,ArchLeadTeams,SupportTeams,SummaryComments")] Summary summary)
        {
            return BaseEdit(summary);
        }
    }
}
