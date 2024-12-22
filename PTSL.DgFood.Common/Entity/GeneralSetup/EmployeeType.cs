using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class EmployeeType : BaseEntity
    {
        public string EmployeeTypeName { get; set; }
        public string EmployeeTypeNameBn { get; set; }
        public IList<OfficialInformation> OfficialInformations { get; set; }
        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }
    }
}
