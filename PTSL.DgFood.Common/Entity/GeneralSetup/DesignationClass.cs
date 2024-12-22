
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class DesignationClass : BaseEntity
    {
        public string DesignationClassName { get; set; }
        public string DesignationClassNameBn { get; set; }
        public ICollection<Designation> Designations { get; set; }
        public IList<PostingRecords> PostingRecords { get; set; }
        public IList<PostingRecords> CurrPostingRecords { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<OfficialInformation> PresentPostingDetails { get; set; }
        public IList<OfficialInformation> JoiningPostingDetails { get; set; }
        public IList<OfficialInformation> CurrPostingDetails { get; set; }
        public IList<EmployeeInformationCount> EmployeeInformationCount { get; set; }


        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }


    }
}
