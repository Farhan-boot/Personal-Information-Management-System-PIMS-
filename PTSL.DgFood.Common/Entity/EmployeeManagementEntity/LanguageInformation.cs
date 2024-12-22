using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class LanguageInformation : BaseEntity
    {
        public long LanguageId { get; set; }
        public string Listening { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }
        public string Comments { get; set; }
        public long EmployeeInformationId { get; set; }
        public virtual Language Language { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }
    }
}
