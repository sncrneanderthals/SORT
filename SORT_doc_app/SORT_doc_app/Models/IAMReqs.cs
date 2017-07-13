using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class IAMReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string IAMContacts { get; set; }
        public string IAMTraining { get; set; }
        public string IAMSummary { get; set; }
        public string IAMApproval { get; set; }
        public string IAMUserAccess { get; set; }
        public string IAMUrls { get; set; }
        public string IAMPassword { get; set; }
        public string IAMAccLockout { get; set; }
        public string IAMOLA { get; set; }
        public string IAMPermission { get; set; }

        public virtual Project Project { get; set; }
    }
}