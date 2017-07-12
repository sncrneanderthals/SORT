using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class GISReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string GISQAPersonnel { get; set; }
        public string GISArchReview { get; set; }
        public string GISSecInfra { get; set; }
        public string GISVulnerabilityScan { get; set; }
        public string GISEventTool { get; set; }
        public string GISIntrusionDetect { get; set; }
        public string GISHardening { get; set; }
        public string GISAdditional { get; set; }
        //public string GISProcessReview { get; set; }
        public string GISDataClassification { get; set; }
        public string GISEncryption { get; set; }
        public string GISProcess { get; set; }
        public string GISAccess { get; set; }
        public string GISSourceAssure { get; set; }
        public string GISPenetration { get; set; }

        public virtual Project Project { get; set; }
    }
}