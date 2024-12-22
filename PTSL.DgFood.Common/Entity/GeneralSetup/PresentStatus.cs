using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PresentStatus : BaseEntity
    {
        public string PresentStatusName { get; set; }
        public string PresentStatusNameBn { get; set; }
        public IList<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecution { get; set; }
        public IList<DisciplinaryHistory> DisciplinaryHistories { get; set; }
    }
}