using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class RecruitPromo : BaseEntity
    {
        public string RecruitPromoEnglish { get; set; }
        public string RecruitPromoBangla { get; set; }
        public virtual IList<OfficialInformation> OfficialInformations { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }


    }
}
