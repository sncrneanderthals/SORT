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
    public class RisksController : BaseDocumentController<Risks>
    {
        protected override DbSet<Risks> getDbSet()
        {
            throw new NotImplementedException();
        }

        // POST: Risks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,RisksPrePlan,RisksPreAccept,RisksPreOwner,RisksPreDate,RisksWarrantyPlan,RisksWarrantyAccept,RisksWarrantyOwner,RisksWarrantyDate,RisksComments")] Risks risks)
        {
            return BaseCreate(risks);
        }

        // POST: Risks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,RisksPrePlan,RisksPreAccept,RisksPreOwner,RisksPreDate,RisksWarrantyPlan,RisksWarrantyAccept,RisksWarrantyOwner,RisksWarrantyDate,RisksComments")] Risks risks)
        {
            return BaseEdit(risks);
        }
    }
}
