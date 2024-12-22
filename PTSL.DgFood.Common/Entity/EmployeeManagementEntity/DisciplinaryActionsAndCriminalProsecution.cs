using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class DisciplinaryActionsAndCriminalProsecution : BaseEntity
    {
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public long? PresentStatusId { get; set; }
        public string Judgement { get; set; }
        public string FinalJudgement { get; set; }
        public string Remark { get; set; }
        public string Document { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public virtual Category Category { get; set; }
        public virtual PresentStatus PresentStatus { get; set; }
        public IList<DisciplinaryHistory> DisciplinaryHistories { get; set; }
    }
}