using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ITCS
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string ITCSContacts { get; set; }
        public string ITCSEmail { get; set; }
        public string ITCSDomains { get; set; }
        public string ITCSSoftware { get; set; }
        public string ITCSBuying { get; set; }
        public string ITCSOwner { get; set; }
        public string ITCSEmailConfig { get; set; }
        public string ITCSInventory { get; set; }
        public string ITCSListing { get; set; }

        public virtual Project Project { get; set; }
    }
}