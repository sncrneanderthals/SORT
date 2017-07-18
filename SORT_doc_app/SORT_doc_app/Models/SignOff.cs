using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class SignOff
    {
        //probably did this wrong, needs to be checked
        public int ID { get; set; }
        public int ProjectID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SignOffDate { get; set; }
        public string SignOffPM { get; set; }
        public string SignOffSRE { get; set; }
        public string SignOffGIS { get; set; }
        public string SignOffEOC { get; set; }
        public string SignOffSupport { get; set; }
        public string SignOffCCT { get; set; }
        public string SignOffSDM { get; set; }

        public virtual Project Project { get; set; }
    }
}