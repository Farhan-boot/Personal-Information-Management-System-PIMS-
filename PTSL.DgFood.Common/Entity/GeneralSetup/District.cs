using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.GeneralSetup
{
    public class District : BaseEntity
    {
        public string DistrictName { get; set; }
        public string DistrictNameBangla { get; set; }
        public long DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public ICollection<PoliceStation> PoliceStations { get; set; }
        public IList <Upazilla> Upazillas { get; set; }
        public IList <PermanentAddress> PermanentAddresses { get; set; }
        public IList<PresentAddress> PresentAddresses { get; set; }
        public IList<SpouseInformation> SpouseInformation { get; set; }
        public IList<EmployeeInformation> EmployeeInformation { get; set; }
        public IList<PostingRecords> TransferFromPostingRecords { get; set; }
        public IList<PostingRecords> TransferToPostingRecords { get; set; }

        //Add New
        public string? GeoCode { get; set; }
    }
}
