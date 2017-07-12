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
    }
}