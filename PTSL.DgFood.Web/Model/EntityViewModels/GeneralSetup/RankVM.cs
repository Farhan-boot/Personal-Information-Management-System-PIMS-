using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class RankVM : BaseModel
    {
        [MaxLength(100)]
        public string RankName { get; set; }
        [MaxLength(100)]
        public string RankNameBangla { get; set; }
        public IList<DesignationVM> DesignationList { get; set; }
        public IList<PromotionPartcularsVM> PromotionPartcularList { get; set; }
        public IList<PostingRecordsVM> PostingRecordList { get; set; }
        public IList<OfficialInformationVM> PresentPostingDetailList { get; set; }
        public IList<OfficialInformationVM> JoiningPostingDetailList { get; set; }
        public IList<PayScalePerGradeVM> PayScalePerGradeList { get; set; }
        public IList<PromotionManagementVM> PromotionManagementList { get; set; }
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
    }
}
