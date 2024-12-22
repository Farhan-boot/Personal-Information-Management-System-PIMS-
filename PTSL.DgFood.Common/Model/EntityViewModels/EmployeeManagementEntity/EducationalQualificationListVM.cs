using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class EducationalQualificationListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string NameOfTheInstitute { get; set; }
        public string PrincipalSubject { get; set; }
        public string GpaOrCGPA { get; set; }
        public string Distinction { get; set; }
    }
}
