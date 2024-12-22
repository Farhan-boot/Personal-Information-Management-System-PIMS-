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
    public class SpouseInformationListVM
    {
        public long Id { get; set; }
        public string NameInBangla {get;set;}
        public string NameInEnglish { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public long EmployeeInformationId { get; set; }
        public string Occupation { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
    }
}
