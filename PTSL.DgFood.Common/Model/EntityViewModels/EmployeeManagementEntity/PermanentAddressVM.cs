using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class PermanentAddressVM : BaseModel
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

        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        public virtual PoliceStationVM PoliceStationDTO { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

        //Add New
        public long? UpazillaId { get; set; }
        public virtual UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public virtual UnionVM? Union { get; set; }
    }
}
