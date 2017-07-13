using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SORT_doc_app.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Created At")]
        private DateTime Date = DateTime.Now;

        [Display(Name = "Created At")]
        public DateTime _Date
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }

        public bool SummaryDone { get; set; }
        public bool ServSpecDone { get; set; }
        public bool EOCDone { get; set; }
        public bool AppSupportDone { get; set; }
        public bool ChangeManDone { get; set; }
        public bool GISDone { get; set; }
        public bool NEDone { get; set; }
        public bool SCVDone { get; set; }
        public bool SREDone { get; set; }
        public bool DBADone { get; set; }
        public bool QADone { get; set; }
        public bool IAMDone { get; set; }
        public bool PBXDone { get; set; }
        public bool ITCSDone { get; set; }
        public bool SMODone { get; set; }
        public bool RisksDone { get; set; }
        public bool SignOffDone { get; set; }
    }
}