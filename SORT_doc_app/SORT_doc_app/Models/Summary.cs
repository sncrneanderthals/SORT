using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SORT_doc_app.Models
{
    public class Summary
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        [Display(Name = "Service Name (include also any Project names)")]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product Name and Release Number")]
        public string ProductName { get; set; }
        [Display(Name = "Service Delivery Manager / Business Team")]
        public string ServiceDelivery { get; set; }
        [Display(Name = "Cost Centre")]
        public string CostCentre { get; set; }
        [Display(Name = "Project Managers")]
        public string ProjectManagers { get; set; }
        [Display(Name = "PCI or SOX application?")]
        public string PCISOX { get; set; }
        [Display(Name = "Go Live Date(s)")]
        public DateTime? GoLiveDate { get; set; }
        [Display(Name = "Primary Architecture Tech Leads and Teams")]
        public string ArchLeadTeams { get; set; }
        [Display(Name = "Primary Technical IT Leads & Teams supporting the environment once live")]
        public string SupportTeams { get; set; }

        public virtual Project Project { get; set; }
    }
}