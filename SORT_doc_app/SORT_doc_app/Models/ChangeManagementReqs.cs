using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ChangeManagementReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string ChCustomerClarity { get; set; }
        public string ChCMReqs { get; set; }
        public string ChReleases { get; set; }

        public virtual Project Project { get; set; }
    }
}