using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class CadreVM : BaseModel
    {
        public string CadreNameEnglish { get; set; }
        public string CadreNameBangla { get; set; }
        public string ClassType { get; set; }
    }
}
