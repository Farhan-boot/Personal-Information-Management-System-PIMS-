using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class LanguageInformationVM : BaseModel
    {
        public long LanguageId { get; set; }
        [MaxLength(100)]
        public string Listening { get; set; }
        [MaxLength(100)]
        public string Reading { get; set; }
        [MaxLength(100)]
        public string Writing { get; set; }
        public string Comments { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual LanguageVM LanguageDTO { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }
    }
}
