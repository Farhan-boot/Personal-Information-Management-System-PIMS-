using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class OtherTrainingMember : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressOrWorkplace { get; set; }
        public Gender? GenderId { get; set; }
        public long? TrainingManagementTypeId { get; set; }
        public virtual TrainingManagementType TrainingManagementType { get; set; }
    }
}
