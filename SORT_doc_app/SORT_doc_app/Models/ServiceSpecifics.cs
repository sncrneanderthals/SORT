using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ServiceSpecifics
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Links { get; set; }
        public string VPN { get; set; }
        public string HostPlatform { get; set; }
        public string BackupRecovery { get; set; }
        public string NotesAndGrid { get; set; }
        public string Changes { get; set; }
        public string GoLiveReqs { get; set; }
        public string SLAsSOW { get; set; }
        public string LicensingAndHardware { get; set; }
        public string BCorDR { get; set; }

        public virtual Project Project { get; set; }
    }
}