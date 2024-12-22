using PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class DesignationVM : BaseModel
    {
        [MaxLength(100)]
        public string DesignationName { get; set; }
        [MaxLength(100)]
        public string DesignationNameBangla { get; set; }
        public long RankId { get; set; }
        public virtual RankVM RankDTO { get; set; }
        public long DesignationClassId { get; set; }
        public virtual DesignationClassVM DesignationClassDTO { get; set; }
        public IList<PromotionPartcularsVM> PromotionPartcularList { get; set; }
        //[InverseProperty(nameof(PostingRecords.Designation))]
        public virtual IList<PostingRecordsVM> PostingRecordList { get; set; }
        //[InverseProperty(nameof(PostingRecords.CrntDesg))]
        public virtual IList<PostingRecordsVM> CrntPostingRecordList { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<OfficialInformationVM> PresentPostingDetailList { get; set; }
        public IList<OfficialInformationVM> JoiningPostingDetailList { get; set; }
        public IList<OfficialInformationVM> CrntPostingDetailList { get; set; }
        public IList<PromotionManagementVM> PromotionManagementList { get; set; }
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
    }
}
