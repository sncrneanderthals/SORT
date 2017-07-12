using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SREReqs
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string SREYesNo { get; set; }
        public string SREYContacts { get; set; }
        public string SREDocument{ get; set; }
        public string SREPasswords { get; set; }

        public virtual Project Project { get; set; }

    }
}