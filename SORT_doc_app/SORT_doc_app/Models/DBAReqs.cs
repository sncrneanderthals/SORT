using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class DBAReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string DBAYesNo { get; set; }
        public string DBAContacts { get; set; }
        public string DBADbInstance { get; set; }
        public string DBADbVersion { get; set; }
        public string DBADbOS { get; set; }
        public string DBAUserIDs { get; set; }
        public string DBALinks { get; set; }
        public string DBAFeatures { get; set; }
        public string DBAAppTouchPoints { get; set; }
        public string DBADbTouchPoints { get; set; }
        public string DBAVolumeEstimates { get; set; }
        public string DBAUserVolume{ get; set; }
        public string DBAArchPurging { get; set; }
        public string DBAPools { get; set; }
        public string DBACRUDMatrix { get; set; }
        public string DBAPerformance { get; set; }
        public string DBADBMSJobs { get; set; }
        public string DBARollback { get; set; }
        public string DBARollbackTest { get; set; }
        public string DBABRProcess { get; set; }
        public string DBABackupReqs { get; set; }
        public string DBARecoveryReqs { get; set; }
        public string DBARetentionReqs { get; set; }

        public virtual Project Project { get; set; }
    }
}