using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class OtherServiceInfo : BaseEntity
    {  
        public string EmployerName { get; set; }
        public string EmpAddress { get; set; }
        public string OtherServiceType { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}
