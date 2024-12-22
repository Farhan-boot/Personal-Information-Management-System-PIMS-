using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class JobCategoryVM : BaseModel
    {
        public string JobCategoryName { get; set; }
        public string JobCategoryNameBn { get; set; }
        public IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}
