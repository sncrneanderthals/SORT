using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class NEReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string NEYesNo { get; set; }
        public string NEChangeContact { get; set; }
        public string NEChangeDescription { get; set; }
        public string NEChangeLocation { get; set; }
        public string NEChangeIPInfo { get; set; }
        public string NEChangeReasonResult { get; set; }
        public string NEChangeSummary { get; set; }
        public string NEServiceContact { get; set; }
        public string NEServiceDescription { get; set; }
        public string NEServiceLocation { get; set; }
        public string NEServiceIPInfo { get; set; }
        public string NEServiceResult { get; set; }
        public string NEServiceSummary { get; set; }
        public string NEAcqMigrDomain { get; set; }
        public string NEAcqMigrDNS { get; set; }
        public string NEAcqTunnels { get; set; }
        public string NEAcqSummary { get; set; }
        public string NENewConfirmConnectivity{ get; set; }
        public string NENewSummary { get; set; }
        public string NEEnvironment { get; set; }

        public virtual Project Project { get; set; }
    }
}