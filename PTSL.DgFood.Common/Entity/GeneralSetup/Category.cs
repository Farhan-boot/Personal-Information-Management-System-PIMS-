using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryNameBn { get; set; }
        //public ICollection<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecution { get; set; }
        public IList<DisciplinaryActionsAndCriminalProsecution> DisciplinaryActionsAndCriminalProsecution { get; set; }
    }
}
