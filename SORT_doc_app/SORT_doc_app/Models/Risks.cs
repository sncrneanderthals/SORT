using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class Risks
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string RisksPrePlan { get; set; }
        public string RisksPreAccept { get; set; }
        public string RisksPreOwner { get; set; }
        public DateTime? RisksPreDate { get; set; }
        public string RisksWarrantyPlan { get; set; }
        public string RisksWarrantyAccept { get; set; }
        public string RisksWarrantyOwner { get; set; }
        public DateTime? RisksWarrantyDate { get; set; }

        public virtual Project Project { get; set; }
    }
}