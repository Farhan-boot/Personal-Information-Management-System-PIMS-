using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class JobCategory : BaseEntity
    {
        public string JobCategoryName { get; set; }
        public string JobCategoryNameBn { get; set; }
        public IList<OfficialInformation> OfficialInformations { get; set; }
    }
}
