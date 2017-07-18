using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class Risks
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksPrePlan { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksPreAccept { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksPreOwner { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RisksPreDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksWarrantyPlan { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksWarrantyAccept { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksWarrantyOwner { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RisksWarrantyDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string RisksComments { get; set; }

        public virtual Project Project { get; set; }
    }
}