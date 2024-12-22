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
    public class UniversityInformationVM : BaseModel
    {
        public string? UniversityName { get; set; }
        public string? UniversityNameBn { get; set; }
        public string? Acronym { get; set; }
        public long? EstablishedYear { get; set; }
        public string? Location { get; set; }
    }
}
