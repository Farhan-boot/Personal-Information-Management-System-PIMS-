using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class PresentAddressVM : BaseModel
    {
        [MaxLength(1000)]
        public string VillageHouseNoAndRoadInEnglish { get; set; }
        [MaxLength(1000)]
        public string VillageHouseNoAndRoadInBangla { get; set; }
        public long DivisionId { get; set; }
        public long DistrictId { get; set; }
        public long PoliceStationId { get; set; }
        public long EmployeeInformationId { get; set; }
        [MaxLength(400)]
        public string OtherThana { get; set; }
        [MaxLength(200)]
        public string PostOfficeInEnglish { get; set; }
        [MaxLength(200)]
        public string PostOfficeInBangla { get; set; }
        [MaxLength(60)]
        public string TelephoneNo { get; set; }
        public virtual DivisionVM DivisionDTO { get; set; }
        public virtual DistrictVM DistrictDTO { get; set; }
        public virtual PoliceStationVM PoliceStationDTO { get; set; }
        public virtual EmployeeInformationVM EmployeeInformationDTO { get; set; }

        //Add New
        public long? UpazillaId { get; set; }
        public virtual UpazillaVM Upazilla { get; set; }
        public long? UnionId { get; set; }
        public virtual UnionVM Union { get; set; }
    }
}
