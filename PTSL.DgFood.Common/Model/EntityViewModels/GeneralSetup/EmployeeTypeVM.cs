using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class EmployeeTypeVM : BaseModel
    {
        public string EmployeeTypeName { get; set; }
        public string EmployeeTypeNameBn { get; set; }
        public IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}
