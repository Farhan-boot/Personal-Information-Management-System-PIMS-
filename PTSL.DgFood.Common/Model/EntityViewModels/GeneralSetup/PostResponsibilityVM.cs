using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PostResponsibilityVM : BaseModel
    {
        public string PostResponsibilityName { get; set; }
        public string PostResponsibilityNameBn { get; set; }
        ////public IEnumerable<EmployeeInformation> EmployeeInformation { get; set; }
        //public virtual IEnumerable<PostingRecords> PostingRecords { get; set; }
        //public virtual IEnumerable<PresentPostingDetails> PresentPostingDetails { get; set; }
    }
}
