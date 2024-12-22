using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class PostingVM : BaseModel
    {
        public string PostingName { get; set; }
        public string PostingNameBangla { get; set; }
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? ThanaId { get; set; }
        public long PostingTypeId { get; set; }
        public virtual PostingTypeVM PostingTypeDTO { get; set; }
        public virtual IList<OrganogramVM> ParentOrganogramDTO { get; set; }
        public virtual IList<OrganogramVM> OrganogramDTO { get; set; }
        //public IList<PostingRecords> PostingRecords { get; set; }
        //public IList<PostingRecords> DepPostingRecords { get; set; }
        //public IList<EmployeeTransfer> EmployeeTransfer { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        //public IList<PresentPostingDetails> PresentPostingDetails { get; set; }
        //public IList<PresentPostingDetails> DepPostingDetails { get; set; }

    }
}
