using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class AppsSupportReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string SupContacts { get; set; }
        public string SupAccountsAccess { get; set; }
        public string SupToolsA { get; set; }
        public string SupToolsB { get; set; }
        public string SupToolsC { get; set; }
        public string SupToolsD { get; set; }
        public string SupDemoTraining { get; set; }
        public string SupContactsProvided { get; set; }
        public string SupCustContact { get; set; }

        public virtual Project Project { get; set; }

    }
}