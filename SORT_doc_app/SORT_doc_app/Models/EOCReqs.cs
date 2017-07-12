using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class EOCReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string EOCContacts { get; set; }
        public string EOCLocation { get; set; }
        public string EOCPOCs { get; set; }
        public string EOCDocsAndDemo { get; set; }
        public string EOCProcessFlows { get; set; }
        public string EOCMonitoring { get; set; }
        public string EOCSignOff { get; set; }
        public string EOCCustomers { get; set; }
        public string EOCSevEmail { get; set; }
        public string EOCCrisis { get; set; }
        public string EOCProcess { get; set; }
        public string EOCExceptions { get; set; }

        public virtual Project Project { get; set; }
    }
}