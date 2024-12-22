using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class SpouseInformationVM : BaseModel
    {
        public string NameInBangla {get;set;}
        public string NameInEnglish { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long EmployeeInformationId { get; set; }
        public string Occupation { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        //public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}
