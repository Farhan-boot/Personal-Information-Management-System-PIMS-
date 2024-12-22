using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class EducationalQualificationListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        [MaxLength(1000)]
        public string NameOfTheInstitute { get; set; }
        [MaxLength(1000)]
        public string PrincipalSubject { get; set; }
        public string GpaOrCGPA { get; set; }
        public string Distinction { get; set; }
        public string Degree { get; set; }
        public DateTime PassingYear { get; set; }
        public string ResultOrDivision { get; set; }
    }
}
