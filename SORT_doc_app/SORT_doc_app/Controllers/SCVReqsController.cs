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
    public class SCVReqsController : BaseDocumentController<SCVReqs>
    {
        protected override DbSet<SCVReqs> getDbSet()
        {
            return db.SCVReqs;
        }
        // POST: SCVReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,SCVYesNo,SCVIpsCreds,SCVNetwork,SCVInventory,SCVSupport,SCVChangeControl,SCVSecurity,SCVSPOC,SCVCapacity,SCVForecast,SCVTraining,SCVComments")] SCVReqs sCVReqs)
        {
            return BaseCreate(sCVReqs);
        }
        
        // POST: SCVReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,SCVYesNo,SCVIpsCreds,SCVNetwork,SCVInventory,SCVSupport,SCVChangeControl,SCVSecurity,SCVSPOC,SCVCapacity,SCVForecast,SCVTraining,SCVComments")] SCVReqs sCVReqs)
        {
            return BaseEdit(sCVReqs);
        }
    }
}
