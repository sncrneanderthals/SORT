using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SCVReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string SCVYesNo { get; set; }
        public string SCVIpsCreds { get; set; }
        public string SCVNetwork { get; set; }
        public string SCVInventory { get; set; }
        public string SCVSupport { get; set; }
        public string SCVChangeControl { get; set; }
        public string SCVSecurity { get; set; }
        public string SCVSPOC { get; set; }
        public string SCVCapacity { get; set; }
        public string SCVForecast { get; set; }
        public string SCVTraining { get; set; }

        public virtual Project Project { get; set; }
    }
}