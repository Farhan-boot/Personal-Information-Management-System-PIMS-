using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class DesignationClassVM : BaseModel
    {
        [MaxLength(100)]
        public string DesignationClassName { get; set; }
        public string DesignationClassNameBn { get; set; }
        public IList<DesignationVM> DesignationList { get; set; }
        public IList<PostingRecordsVM> PostingRecordList { get; set; }
        public IList<PostingRecordsVM> CurrPostingRecordList { get; set; }
        public IList<OfficialInformationVM> PresentPostingDetailList { get; set; }
        public IList<OfficialInformationVM> JoiningPostingDetailList { get; set; }
        public IList<OfficialInformationVM> CurrPostingDetailList { get; set; }
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
    }
}
