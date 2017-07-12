using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SMOReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string SMOContracts { get; set; }
        public string SMOTemplates { get; set; }
        public string SMODocuments { get; set; }
        public string SMOBusinessContacts { get; set; }
        public string SMOChangeManagement { get; set; }
        public string SMOIncidentManagement { get; set; }
        public string SMOUsage { get; set; }
        public string SMOKPIsSLAs { get; set; }
        public string SMOSLMReporting { get; set; }
        public string SMOChReports{ get; set; }
        public string SMOIPMRdefined { get; set; }
        public string SMOProgManagement { get; set; }
        public string SMOChManagementTicketing { get; set; }
        public string SMOKPIProbes { get; set; }

        public virtual Project Project { get; set; }
    }
}