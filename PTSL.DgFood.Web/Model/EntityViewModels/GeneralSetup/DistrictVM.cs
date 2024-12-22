using PTSL.DgFood.Web.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class DistrictVM : BaseModel
    {
        [MaxLength(100)]
        public string DistrictName { get; set; }
        [MaxLength(100)]
        public string DistrictNameBangla { get; set; }
        public long DivisionId { get; set; }
        public DivisionVM DivisionDTO { get; set; }
        public IList<PoliceStationVM> PoliceStationList { get; set; }
        public IList<UpazillaVM> UpazillaList { get; set; }
        //public IList<PermanentAddressVM> PermanentAddresses { get; set; }
        //public IList<PresentAddressVM> PresentAddresses { get; set; }
        //public IList<SpouseInformationVM> SpouseInformation { get; set; }
        //public IList<EmployeeInformationVM> EmployeeInformation { get; set; }

        //public string DistrictName { get; set; }
        //public long DivisionId { get; set; }
        //public virtual Division Division { get; set; }
        //public IList<PoliceStation> PoliceStations { get; set; }
        //public IList<PermanentAddress> PermanentAddresses { get; set; }
        //public IList<PresentAddress> PresentAddresses { get; set; }
        //public IList<SpouseInformation> SpouseInformation { get; set; }
        //public IList<EmployeeInformation> EmployeeInformation { get; set; }

        //Add New
        public string GeoCode { get; set; }
    }
}
