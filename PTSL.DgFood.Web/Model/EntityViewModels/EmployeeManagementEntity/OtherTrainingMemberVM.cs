using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class OtherTrainingMemberVM : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressOrWorkplace { get; set; }
        public Gender GenderId { get; set; }
        public long TrainingManagementTypeId { get; set; }
        public virtual TrainingManagementTypeVM TrainingManagementType { get; set; }
    }
}