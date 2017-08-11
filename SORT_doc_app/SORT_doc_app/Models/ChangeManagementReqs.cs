using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class ChangeManagementReqs : BaseDocumentModel
    {
        [DataType(DataType.MultilineText)]
        public string ChCustomerClarity { get; set; }
        [DataType(DataType.MultilineText)]
        public string ChCMReqs { get; set; }
        [DataType(DataType.MultilineText)]
        public string ChReleases { get; set; }
        [DataType(DataType.MultilineText)]
        public string ChComments { get; set; }
    }
}