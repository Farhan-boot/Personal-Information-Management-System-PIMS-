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
    public class DesignationClassVM : BaseModel
    {
        public string DesignationClassName { get; set; }
        public string DesignationClassNameBn { get; set; }
        public IList<DesignationVM> DesignationList { get; set; }
        public IList<PostingRecordsVM> PostingRecordList { get; set; }
        public IList<PostingRecordsVM> CurrPostingRecordList { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<OfficialInformationVM> PresentPostingDetailList { get; set; }
        public IList<OfficialInformationVM> JoiningPostingDetailList { get; set; }
        public IList<OfficialInformationVM> CurrPostingDetailList { get; set; }
        public IList<EmployeeInformationCountVM> EmployeeInformationList { get; set; }
    }
}
