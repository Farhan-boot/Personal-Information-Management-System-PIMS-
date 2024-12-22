using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class DisciplinaryActionsAndCriminalProsecutionVM : BaseModel
    {
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public long PresentStatusId { get; set; }
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
