using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class EducationalQualificationVM : BaseModel
    {
        [MaxLength(1000)]
        public string NameOfTheInstitute { get; set; }
        [MaxLength(1000)]
        public string PrincipalSubject { get; set; }
        public long DegreeId { get; set; }
        [MaxLength(10)]
        public string PassingYear { get; set; }
        [MaxLength(50)]
        public string ResultOrDivision { get; set; }
        [MaxLength(50)]
        public string GPAOrCGPA { get; set; }
        [MaxLength(100)]
        public string Distinction { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
        public virtual DegreeVM DegreeDTO { get; set; }

        //New
        public long? UniversityInformationId { get; set; }
    }
}
