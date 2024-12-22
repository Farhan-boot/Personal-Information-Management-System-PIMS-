using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class CategoryVM : BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryNameBn { get; set; }
        //public IEnumerable<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecution { get; set; }
    }
}
