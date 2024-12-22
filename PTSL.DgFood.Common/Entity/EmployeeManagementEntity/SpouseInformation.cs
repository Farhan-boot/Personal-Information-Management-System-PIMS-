using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class SpouseInformation : BaseEntity
    {
        public string NameInBangla {get;set;}
        public string NameInEnglish { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long EmployeeInformationId { get; set; }
        public string Occupation { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public virtual Division Division { get; set; }
        public virtual District District { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}
