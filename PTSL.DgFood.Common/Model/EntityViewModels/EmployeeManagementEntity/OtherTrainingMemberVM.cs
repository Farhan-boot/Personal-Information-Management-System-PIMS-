using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
   public class OtherTrainingMemberVM : BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressOrWorkplace { get; set; }
        public Gender? GenderId { get; set; }
        public long? TrainingManagementTypeId { get; set; }
        [SwaggerExclude]
        public virtual TrainingManagementTypeVM TrainingManagementType { get; set; }
    }
}
