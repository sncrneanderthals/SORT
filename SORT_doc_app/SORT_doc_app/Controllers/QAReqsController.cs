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
using Microsoft.AspNet.Identity;

namespace SORT_doc_app.Controllers
{
    public class QAReqsController : BaseDocumentController<QAReqs>
    {
        protected override DbSet<QAReqs> getDbSet()
        {
            return db.QAReqs;
        }

        // POST: QAReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,QAContacts,QATeam,QAFramework,QASmokeTest,QALocation,QAHandestsSIMs,QAIssues,QAJira,QAPlan,Comments")] QAReqs qAReqs)
        {
            return BaseCreate(qAReqs);
        }
        
        // POST: QAReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,QAContacts,QATeam,QAFramework,QASmokeTest,QALocation,QAHandestsSIMs,QAIssues,QAJira,QAPlan,Comments")] QAReqs qAReqs)
        {
            return BaseEdit(qAReqs);
        }
    }
}
