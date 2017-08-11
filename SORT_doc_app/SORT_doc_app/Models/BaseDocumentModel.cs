using System.ComponentModel.DataAnnotations.Schema;

namespace SORT_doc_app.Models
{
    public class BaseDocumentModel
    {
        public int ID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}