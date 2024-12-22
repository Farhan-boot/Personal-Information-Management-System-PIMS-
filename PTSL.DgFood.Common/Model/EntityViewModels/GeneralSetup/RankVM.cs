using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class RankVM : BaseModel
    {
        public string RankName { get; set; }
        public string RankNameBangla { get; set; }
        public IList<DesignationVM> DesignationList { get; set; }
        public IList<PromotionPartcularsVM> PromotionPartcularList { get; set; }
        public IList<PostingRecordsVM> PostingRecordList { get; set; }
        public IList<OfficialInformationVM> PresentPostingDetailList { get; set; }
        public IList<OfficialInformationVM> JoiningPostingDetailList { get; set; }
        public IList<PayScalePerGradeVM> PayScalePerGradeList { get; set; }
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
    }
}
