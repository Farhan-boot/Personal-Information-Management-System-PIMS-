using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PresentStatusVM : BaseModel
    {
        public string PresentStatusName { get; set; }
        public string PresentStatusNameBn { get; set; }

        //public IEnumerable<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecution { get; set; }
    }
}
