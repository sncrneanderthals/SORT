using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class QAReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string QAContacts { get; set; }
        public string QATeam { get; set; }
        public string QAFramework { get; set; }
        public string QASmokeTest { get; set; }
        public string QALocation { get; set; }
        public string QAHandestsSIMs { get; set; }
        public string QAIssues { get; set; }
        public string QAJira { get; set; }
        public string QAPlan { get; set; }

        public virtual Project Project { get; set; }
    }
}