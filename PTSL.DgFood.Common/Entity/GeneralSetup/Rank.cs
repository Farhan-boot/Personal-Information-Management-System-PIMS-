using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Rank : BaseEntity
    {
        public string RankName { get; set; }
        public string RankNameBangla { get; set; }
        public IList<Designation> Designations { get; set; }
        public IList<PromotionPartculars> PromotionPartculars { get; set; }
        public IList<PostingRecords> PostingRecords { get; set; }
        public IList<OfficialInformation> PresentPostingDetails { get; set; }
        public IList<OfficialInformation> JoiningPostingDetails { get; set; }
        public IList<PayScalePerGrade> PayScalePerGrades { get; set; }
        public IList<PromotionManagement> PromotionManagement { get; set; }
        public IList<EmployeeInformationCount> EmployeeInformationCount { get; set; }
    }
}
