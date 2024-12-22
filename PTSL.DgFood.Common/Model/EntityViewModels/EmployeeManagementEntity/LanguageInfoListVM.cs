using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class LanguageInfoListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string Language { get; set; }
        public string Listening { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }
    }
}
