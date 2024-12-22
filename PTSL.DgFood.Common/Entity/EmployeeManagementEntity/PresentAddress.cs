using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class PresentAddress : BaseEntity
    {
        public string VillageHouseNoAndRoadInEnglish { get; set; }
        public string VillageHouseNoAndRoadInBangla { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long PoliceStationId { get; set; }
        public long EmployeeInformationId { get; set; }
        public string OtherThana { get; set; }
        public string PostOfficeInEnglish { get; set; }
        public string PostOfficeInBangla { get; set; }
        public string TelephoneNo { get; set; }
        public virtual Division Division { get; set; }
        public virtual District District { get; set; }
        public virtual PoliceStation PoliceStation { get; set; }
        public virtual EmployeeInformation EmployeeInformation { get; set; }

        //Add New
        public long? UpazillaId { get; set; }
        public virtual Upazilla? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public virtual Union? Union { get; set; }

    }
}
