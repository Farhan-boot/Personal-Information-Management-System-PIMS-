using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Degree : BaseEntity
    {
        public string DegreeName { get; set; }
        public string DegreeNameBn { get; set; }
        public IList<EducationalQualification> EducationalQualifications { get; set; }

    }
}
