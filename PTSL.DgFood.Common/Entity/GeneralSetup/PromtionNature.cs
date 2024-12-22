using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PromtionNature : BaseEntity
    {
        public string PromtionNatureName { get; set; }
        public string PromtionNatureNameBangla { get; set; }
        public IList<PromotionPartculars> PromotionPartculars { get; set; }
        public IList<OfficialInformation> PresentPostingDetails { get; set; }
        public IList<PromotionManagement> PromotionManagement { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }
    }
}
