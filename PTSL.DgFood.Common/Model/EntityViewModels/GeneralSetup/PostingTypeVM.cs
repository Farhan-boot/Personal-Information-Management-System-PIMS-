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
    public class PostingTypeVM : BaseModel
    {
        public string PostingTypeName { get; set; }
        public string PostingTypeNameBangla { get; set; }
        public IList<PostingVM> PostingList { get; set; }
        public virtual IList<OrganogramVM> OrganogramList { get; set; }
    }
}
