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
    public class DBAReqsController : BaseDocumentController<DBAReqs>
    {
        protected override DbSet<DBAReqs> getDbSet()
        {
            return db.DBAReqs;
        }

        // POST: DBAReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,DBAYesNo,DBAContacts,DBADbInstance,DBADbVersion,DBADbOS,DBAUserIDs,DBALinks,DBAFeatures,DBAAppTouchPoints,DBADbTouchPoints,DBAVolumeEstimates,DBAUserVolume,DBAArchPurging,DBAPools,DBACRUDMatrix,DBAPerformance,DBADBMSJobs,DBARollback,DBARollbackTest,DBABRProcess,DBABackupReqs,DBARecoveryReqs,DBARetentionReqs,DBAComments")] DBAReqs dBAReqs)
        {
            return BaseCreate(dBAReqs);
        }

        // POST: DBAReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,DBAYesNo,DBAContacts,DBADbInstance,DBADbVersion,DBADbOS,DBAUserIDs,DBALinks,DBAFeatures,DBAAppTouchPoints,DBADbTouchPoints,DBAVolumeEstimates,DBAUserVolume,DBAArchPurging,DBAPools,DBACRUDMatrix,DBAPerformance,DBADBMSJobs,DBARollback,DBARollbackTest,DBABRProcess,DBABackupReqs,DBARecoveryReqs,DBARetentionReqs,DBAComments")] DBAReqs dBAReqs)
        {
            return BaseEdit(dBAReqs);
        }
    }
}
