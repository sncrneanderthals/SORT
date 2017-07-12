using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SORT_doc_app.Models
{
    public class PBX
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string PBXContacts { get; set; }
        public string PBXPhysAddress { get; set; }
        public string PBXTestPhone { get; set; }
        public string PBXShipSend { get; set; }
        public string PBXExtConf { get; set; }
        public string PBX911 { get; set; }
        public string PBXDisconnect { get; set; }
        public string PBXAuthorised { get; set; }
        public string PBXCollab { get; set; }
        public string PBXDSCIMSA { get; set; }

        public virtual Project Project { get; set; }

    }
}