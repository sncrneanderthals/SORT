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
    public class GISReqsController : BaseDocumentController<GISReqs>
    {
        protected override DbSet<GISReqs> getDbSet()
        {
            return db.GISReqs;
        }

        // POST: GISReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,GISQAPersonnel,GISArchReview,GISSecInfra,GISVulnerabilityScan,GISEventTool,GISIntrusionDetect,GISHardening,GISAdditional,GISDataClassification,GISEncryption,GISProcess,GISAccess,GISSourceAssure,GISPenetration,GISComments")] GISReqs gISReqs)
        {
            return BaseCreate(gISReqs);
        }

        // POST: GISReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,GISQAPersonnel,GISArchReview,GISSecInfra,GISVulnerabilityScan,GISEventTool,GISIntrusionDetect,GISHardening,GISAdditional,GISDataClassification,GISEncryption,GISProcess,GISAccess,GISSourceAssure,GISPenetration,GISComments")] GISReqs gISReqs)
        {
            return BaseEdit(gISReqs);
        }
    }
}
