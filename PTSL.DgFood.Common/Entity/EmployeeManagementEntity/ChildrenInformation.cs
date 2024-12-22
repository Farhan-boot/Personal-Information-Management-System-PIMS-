using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class ChildrenInformation : BaseEntity
    { 
        public int SlNo { get; set; }
        public string NameInEnglish { get; set; }
        public string NameInBangla { get; set; }
        //public long GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
        public Gender GenderId { get; set; }

    }
}
