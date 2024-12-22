using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class ChildrenInformationListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string NameInBangla {get;set;}
        public string NameInEnglish { get; set; } 
        public DateTime DOB { get; set; }
    }
}
