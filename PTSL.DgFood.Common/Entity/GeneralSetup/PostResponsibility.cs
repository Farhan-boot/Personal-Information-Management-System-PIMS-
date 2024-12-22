using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PostResponsibility : BaseEntity
    {
        public string PostResponsibilityName { get; set; }
        public string PostResponsibilityNameBn { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public virtual IList<PostingRecords> PostingRecords { get; set; }
        public virtual IList<OfficialInformation> PresentPostingDetails { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }

    }
}
