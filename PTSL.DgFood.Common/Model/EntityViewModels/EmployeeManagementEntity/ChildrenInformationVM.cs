using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class ChildrenInformationVM : BaseModel
    { 
        public int SlNo { get; set; }
        public string NameInEnglish { get; set; }
        public string NameInBangla { get; set; }
        //public long GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public Gender GenderId { get; set; }

    }
}
