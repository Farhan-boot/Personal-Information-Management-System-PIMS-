using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class DisciplinaryHistoryVM : BaseModel
    {
        public DateTime SubmissonDate { get; set; }
        public string Description { get; set; }
        public IList<DocumentVM> Documents { get; set; }
        public HttpPostedFileBase[] DocumentFile { get; set; }
        public long? PresentStatusId { get; set; }
        public virtual PresentStatusVM PresentStatus { get; set; }
        public long? DisciplinaryAndCriminalId { get; set; }
        public virtual DisciplinaryActionsAndCriminalProsecutionVM DisciplinaryAndCriminal { get; set; }
    }
}