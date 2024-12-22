
using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;

namespace PTSL.DgFood.Web.Model
{
    public class DisciplinaryActionsAndCriminalProsecutionVM : BaseModel
    {
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public long? PresentStatusId { get; set; }
        public string Judgement { get; set; }
        public string FinalJudgement { get; set; }
        public string Remark { get; set; }
        public string Document { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual CategoryVM CategoryDTO { get; set; }
        public virtual PresentStatusVM PresentStatusDTO { get; set; }
        public IList<DisciplinaryHistoryVM> DisciplinaryHistories { get; set; }

    }
}
