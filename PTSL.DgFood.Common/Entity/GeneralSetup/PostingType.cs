using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class PostingType : BaseEntity
    {
        public string PostingTypeName { get; set; }
        public string PostingTypeNameBangla { get; set; }
        public IList<Posting> Postings { get; set; }
        public IList<EmployeeTransfer> EmployeeTransfer { get; set; }
        public virtual IList<PostingRecords> MainPostingRecords { get; set; }
        public virtual IList<PostingRecords> DepPostingRecords { get; set; }
        public virtual IList<OfficialInformation> PresentPostingDetails { get; set; }
        public virtual IList<OfficialInformation> DepPostingDetails { get; set; }
        public virtual IList<Organogram> Organograms { get; set; }

        //new
        public IList<EmployeePostingDetails> EmployeePostingDetails { get; set; }


    }
}


