using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Cadre : BaseEntity
    {
        public string CadreNameEnglish { get; set; }
        public string CadreNameBangla { get; set; }
        public string ClassType { get; set; }
    }
}
