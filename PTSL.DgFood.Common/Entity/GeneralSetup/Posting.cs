using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Posting : BaseEntity
    {
        public string PostingName { get; set; }
        public string PostingNameBangla { get; set; }
        public long? DivisionId { get; set; }
        public long? DistrictId { get; set; }
        public long? ThanaId { get; set; }
        public long PostingTypeId { get; set; }
        public virtual PostingType PostingType { get; set; }
        public IList<PostingRecords> PostingRecords { get; set; }
        public IList<PostingRecords> DepPostingRecords { get; set; }
        public IList<EmployeeTransfer> EmployeeTransfer { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<OfficialInformation> PresentPostingDetails { get; set; }
        public IList<OfficialInformation> DepPostingDetails { get; set; }
        public virtual IList<Organogram> ParentOrganograms { get; set; }
        public virtual IList<Organogram> Organograms { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }

    }

}
