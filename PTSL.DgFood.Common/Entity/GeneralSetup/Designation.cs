
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Designation : BaseEntity
    {

        public string DesignationName { get; set; }
        public string DesignationNameBangla { get; set; }
        public long RankId { get; set; }
        public virtual Rank Rank { get; set; }
        public long DesignationClassId { get; set; }
        public virtual DesignationClass DesignationClasses { get; set; }
        public IList<PromotionPartculars> PromotionPartculars { get; set; }
        //[InverseProperty(nameof(PostingRecords.Designation))]
        public virtual IList<PostingRecords> PostingRecords { get; set; }
        //[InverseProperty(nameof(PostingRecords.CrntDesg))]
        public virtual IList<PostingRecords> CrntPostingRecords { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<OfficialInformation> PresentPostingDetails { get; set; }
        public IList<OfficialInformation> JoiningPostingDetails { get; set; }
        public IList<OfficialInformation> CrntPostingDetails { get; set; }
        public IList<PromotionManagement> PromotionManagement { get; set; }
        public IList<EmployeeInformationCount> EmployeeInformationCount { get; set; }
        public virtual IList<Organogram> Organograms { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }
    }
}
