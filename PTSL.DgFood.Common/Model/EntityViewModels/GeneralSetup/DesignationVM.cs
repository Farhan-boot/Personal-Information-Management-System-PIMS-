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
    public class DesignationVM : BaseModel
    {
        public string DesignationName { get; set; }
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
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
        public virtual IList<OrganogramVM> OrganogramList { get; set; }
    }
}
