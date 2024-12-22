using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class Division : BaseEntity
    {
        public string DivisionName { get; set; }
        public string DivisionNameBangla { get; set; }
        public IList<District> Districts { get; set; }
        public IList<PermanentAddress> PermanentAddresses { get; set; }
        public IList<PresentAddress> PresentAddresses { get; set; }
        public IList<SpouseInformation> SpouseInformation { get; set; }
        public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<PostingRecords> TransferFromPostingRecords { get; set; }
        public IList<PostingRecords> TransferToPostingRecords { get; set; }


        //Add New
        public string? GeoCode { get; set; }
    }
}
