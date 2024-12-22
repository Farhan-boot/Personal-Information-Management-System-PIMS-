using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class DegreeVM : BaseModel
    {
        public string DegreeName { get; set; }
        public string DegreeNameBn { get; set; }
        //public IEnumerable<EducationalQualification> EducationalQualifications { get; set; }

    }
}
