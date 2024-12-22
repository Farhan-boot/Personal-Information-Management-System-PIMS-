using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class RecruitPromoVM : BaseModel
    {
        [MaxLength(100)]
        public string RecruitPromoEnglish { get; set; }
        [MaxLength(100)]
        public string RecruitPromoBangla { get; set; }
        public virtual IList<OfficialInformationVM> OfficialInformationList { get; set; }
    }
}
