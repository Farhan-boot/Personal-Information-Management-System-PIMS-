using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class LanguageInformationVM : BaseModel
    {
        public long LanguageId { get; set; }
        public string Listening { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }
        public string Comments { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual LanguageVM LanguageDTO { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}
