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
    public class EducationalQualificationVM : BaseModel
    {
        public string? NameOfTheInstitute { get; set; }
        public string PrincipalSubject {get;set;}
        public long DegreeId { get; set; }
        public string PassingYear { get; set; }
        public string ResultOrDivision { get; set; }
        public string GPAOrCGPA { get; set; }
        public string Distinction { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual DegreeVM DegreeDTO { get; set; }
        //New
        public long? UniversityInformationId { get; set; }
    }
}
